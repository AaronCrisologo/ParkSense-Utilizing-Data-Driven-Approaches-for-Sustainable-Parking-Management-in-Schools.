using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Intrinsics.Arm;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Mysqlx.Session;

namespace ParkingManagementSystem
{
    public class ParkingLot : IDisposable
    {
        private static string connectionString = "server=localhost;database=parkinglot1;uid=root;pwd=password;";

        private List<ParkingSlot> slots;
        private MySqlConnection connection;
        private DatabaseOperations databaseOperations;

        public ParkingLot(int capacity, string connectionString)
        {
            slots = new List<ParkingSlot>();
            for (int i = 1; i <= capacity; i++)
            {
                slots.Add(new ParkingSlot());
            }

            connection = new MySqlConnection(connectionString);
            connection.Open();

            // Initialize the DatabaseOperations instance
            databaseOperations = new DatabaseOperations(connectionString);
        }
        public int GetAvailableSlotsCount(string tableName)
        {
            int availableSlots = 0;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = $"SELECT COUNT(*) FROM {tableName} WHERE COALESCE(isOccupied, 0) = 0";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int count))
                        {
                            availableSlots = count;
                        }
                        else
                        {
                            Console.WriteLine("Failed to retrieve available slots count for table: " + tableName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return availableSlots;
        }
        public string GetVehicleFeeAsString(string vehicleType)
        {
            string fee = "";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT fee FROM rates WHERE vehicletype = @VehicleType";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@VehicleType", vehicleType);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        fee = result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return fee;
        }


        public bool ParkVehicle(string fullName, string vehicleType, string vehicleNumber, string isPWD, string dep)
        {
            // Determine the initial slot number based on isPWD flag
            int slotNumber = isPWD == "yes" ? 9 : 1;

            bool slotFound = false;

            while (slotNumber <= 10 && !slotFound)
            {
                // Check if the slot is occupied by querying the database
                string query = $"SELECT isOccupied FROM {dep} WHERE parkingSlot = @slotNumber;";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@slotNumber", slotNumber);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bool isOccupied = !reader.IsDBNull(reader.GetOrdinal("isOccupied")) && reader.GetBoolean("isOccupied");

                            if (!isOccupied)
                            {
                                // Slot is not occupied, use this slot
                                reader.Close(); // Close the DataReader before executing a new command

                                // Check if the vehicle already exists in the parking area
                                string checkExistingQuery = $"SELECT COUNT(*) FROM {dep} WHERE vehicleNumber = @vehicleNumber;";

                                using (MySqlCommand checkExistingCommand = new MySqlCommand(checkExistingQuery, connection))
                                {
                                    checkExistingCommand.Parameters.AddWithValue("@vehicleNumber", vehicleNumber);

                                    int existingCount = Convert.ToInt32(checkExistingCommand.ExecuteScalar());

                                    if (existingCount > 0)
                                    {
                                        // Vehicle already exists in the parking area
                                        Console.WriteLine($"Vehicle {vehicleNumber} already exists in the parking area.");
                                        return false;
                                    }
                                }

                                // Park the vehicle in the slot
                                string updateQuery = $"UPDATE {dep} SET isOccupied = @isOccupied, fullName = @fullName, vehicleType = @vehicleType, vehicleNumber = @vehicleNumber, entryTime = @entryTime WHERE parkingSlot = @slotNumber;";

                                using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection))
                                {
                                    updateCommand.Parameters.AddWithValue("@isOccupied", true);
                                    updateCommand.Parameters.AddWithValue("@fullName", fullName);
                                    updateCommand.Parameters.AddWithValue("@vehicleType", vehicleType);
                                    updateCommand.Parameters.AddWithValue("@vehicleNumber", vehicleNumber);
                                    updateCommand.Parameters.AddWithValue("@entryTime", DateTime.Now);
                                    updateCommand.Parameters.AddWithValue("@slotNumber", slotNumber);

                                    updateCommand.ExecuteNonQuery();
                                }

                                Console.WriteLine($"Vehicle {vehicleNumber} (Driver: {fullName}) parked at slot {slotNumber}.");
                                return true;
                            }
                        }
                    }
                }

                slotNumber++; // Move to the next slot
            }

            if (isPWD == "yes")
            {
                isPWD = "no";
                return ParkVehicle(fullName, vehicleType, vehicleNumber, dep, isPWD);
            }
            Console.WriteLine("Parking lot is full or no available slots.");
            return false;
        }


        public bool LeaveParking(string vehicleNumber, string dep)
        {
            // Check if the vehicle is in the parking lot by querying the database
            string checkQuery = $"SELECT parkingSlot, fullName, vehicleType, entryTime FROM {dep} WHERE vehicleNumber = @vehicleNumber AND isOccupied = TRUE;";
            int parkingSlotId = -1;
            string fullName = "";
            string vehicleType = "";
            DateTime entryTime = DateTime.MinValue;

            using (MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection))
            {
                checkCommand.Parameters.AddWithValue("@vehicleNumber", vehicleNumber);

                using (MySqlDataReader reader = checkCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        parkingSlotId = reader.GetInt32("parkingSlot");
                        fullName = reader.GetString("fullName");
                        vehicleType = reader.GetString("vehicleType");
                        entryTime = reader.GetDateTime("entryTime");
                    }
                }
            }

            if (parkingSlotId != -1)
            {
                // Vehicle found, proceed with leaving parking logic
                DateTime exitTime = DateTime.Now;

                // Calculate duration of parking
                TimeSpan duration = exitTime - entryTime;

                // Instantiate CostCalculator to calculate total cost
                CostCalculator costCalculator = new CostCalculator(connectionString);
                double totalCost = costCalculator.CalculateTotalCost(duration, vehicleType);

                // Insert parking receipt into the database
                databaseOperations.InsertParkingReceipt(parkingSlotId, fullName, vehicleType, vehicleNumber, entryTime, exitTime, duration, totalCost, dep);

                // Generate PDF receipt
                PDFReceiptGenerator.GenerateReceipt(fullName, vehicleType, vehicleNumber, entryTime, exitTime, duration, totalCost, dep);

                // Reset the parking slot in memory
                string updateQuery = $"UPDATE {dep} SET isOccupied = NULL, fullName = NULL, vehicleType = NULL, vehicleNumber = NULL, entryTime = NULL WHERE parkingSlot = @parkingSlotId;";

                using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@parkingSlotId", parkingSlotId);
                    updateCommand.ExecuteNonQuery();
                }

                Console.WriteLine($"Vehicle {vehicleNumber} has left the parking lot. Duration: {duration}, Total Cost: {totalCost:C}.");
                return true;
            }
            else
            {
                Console.WriteLine($"Vehicle {vehicleNumber} not found in the parking lot.");
                return false;
            }
        }

        public void DisplayParkingStatus()
        {
            Console.WriteLine("Parking Status:");
            Console.WriteLine("+-------------+-----------+----------------+-----------------+----------------------+");
            Console.WriteLine("| Slot Number |  Status   | Vehicle Number |  Vehicle Type  |     Driver's Name    |");
            Console.WriteLine("+-------------+-----------+----------------+-----------------+----------------------+");

            // Query to select all records from the ParkingEvents table
            string query = "SELECT parkingSlot, isOccupied, fullName, vehicleType, vehicleNumber FROM cics;";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int slotNumber = reader.GetInt32("parkingSlot");
                        bool isOccupied = reader["isOccupied"] != DBNull.Value && (bool)reader["isOccupied"];
                        string status = isOccupied ? "Occupied" : "Available";
                        string fullName = isOccupied && !reader.IsDBNull(reader.GetOrdinal("fullName")) ? reader.GetString("fullName") : "";
                        string vehicleType = isOccupied && !reader.IsDBNull(reader.GetOrdinal("vehicleType")) ? reader.GetString("vehicleType") : "";
                        string vehicleNumber = isOccupied && !reader.IsDBNull(reader.GetOrdinal("vehicleNumber")) ? reader.GetString("vehicleNumber") : "";

                        // Display the status of each parking slot
                        Console.WriteLine($"| {slotNumber,-11} | {status,-9} | {vehicleNumber,-14} | {vehicleType,-15} | {fullName,-20} |");
                    }
                }
            }

            Console.WriteLine("+-------------+-----------+----------------+-----------------+----------------------+");
        }

        public void DisplayParkingLog()
        {
            // Define the SQL query to select all records from the 'ParkingReceipts' table
            string query = "SELECT * FROM ParkingReceipts;";
            
            // Execute the query and retrieve the data
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    // Print the header row
                    Console.WriteLine("{0,-12} | {1,-10} | {2,-12} | {3,-14} | {4,-19} | {5,-19} | {6,-9} | {7,-10}", 
                                    "ParkingSlot", "FullName", "VehicleType", "VehicleNumber", "EntryTime", "ExitTime", "Duration", "TotalCost");
                    Console.WriteLine(new string('-', 130));
                    
                    // Iterate through the result set
                    while (reader.Read())
                    {
                        // Retrieve each column value
                        int parkingSlot = reader.GetInt32("parkingSlot");
                        string fullName = reader.GetString("fullName");
                        string vehicleType = reader.GetString("vehicleType");
                        string vehicleNumber = reader.GetString("vehicleNumber");
                        DateTime entryTime = reader.GetDateTime("entryTime");
                        DateTime exitTime = reader.GetDateTime("exitTime");
                        TimeSpan duration = reader.GetTimeSpan("duration");
                        double totalCost = reader.GetDouble("totalCost");
                        
                        // Print the row data
                        Console.WriteLine("{0,-12} | {1,-10} | {2,-12} | {3,-14} | {4:yyyy-MM-dd HH:mm:ss} | {5:yyyy-MM-dd HH:mm:ss} | {6,-9} | {7,-10:N2}", 
                                        parkingSlot, fullName, vehicleType, vehicleNumber, entryTime, exitTime, duration, totalCost);
                        Console.WriteLine(new string('-', 130));
                    }
                }
            }
        }
        public (string, string, string) GetSlotStatus(int slotNumber, string dep)
        {
            string status = "Available";
            string vehicleNumber = "";
            string fullName = "";

           
            string query;
            if (dep == "cics")
            {
                query = "SELECT isOccupied, fullName, vehicleNumber FROM cics WHERE parkingSlot = @slotNumber;";
            }
            else if (dep == "coe")
            {
                query = "SELECT isOccupied, fullName, vehicleNumber FROM coe WHERE parkingSlot = @slotNumber;";
            }
            else if (dep == "cit")
            {
                query = "SELECT isOccupied, fullName, vehicleNumber FROM cit WHERE parkingSlot = @slotNumber;";
            }
            else if (dep == "ceafa")
            {
                query = "SELECT isOccupied, fullName, vehicleNumber FROM ceafa WHERE parkingSlot = @slotNumber;";
            }
            else {
                query = "SELECT isOccupied, fullName, vehicleNumber FROM cics WHERE parkingSlot = @slotNumber;";
            }

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@slotNumber", slotNumber);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        bool isOccupied = reader["isOccupied"] != DBNull.Value && (bool)reader["isOccupied"];
                        status = isOccupied ? "Occupied" : "Available";
                        fullName = isOccupied && !reader.IsDBNull(reader.GetOrdinal("fullName")) ? reader.GetString("fullName") : "";
                        vehicleNumber = isOccupied && !reader.IsDBNull(reader.GetOrdinal("vehicleNumber")) ? reader.GetString("vehicleNumber") : "";
                    }
                }
            }

            return (status, vehicleNumber, fullName);
        }

        public bool valueoverride(string connectionString, string vehicletype, int fee)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string vehicle = vehicletype.ToLower();

                    // Construct the update query with parameters
                    string updateQuery = "UPDATE rates SET fee = @Fee WHERE vehicletype = @VehicleType";

                    using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@Fee", fee);
                        updateCommand.Parameters.AddWithValue("@VehicleType", vehicle);

                        // Execute the update query
                        int rowsAffected = updateCommand.ExecuteNonQuery();

                        // Check if any rows were affected by the update
                        if (rowsAffected > 0)
                            return true;
                        else
                            return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                //Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }





        public void Dispose()
    {
        if (connection != null)
        {
            connection.Close();
            connection.Dispose();
        }

        // Dispose the DatabaseOperations instance
        databaseOperations.Dispose();
    }
    }
}
