using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Mysqlx.Session;

namespace ParkingManagementSystem
{
    public class ParkingLot : IDisposable
    {
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

        public bool ParkVehicle(string fullName, string vehicleType, string vehicleNumber, bool isPWD, string department)
        {
            int slotNumber = 1; // Start checking from the first slot

            if(isPWD == true)
            {
                slotNumber = 9;

            }

            bool slotFound = false;
            ParkingSlot emptySlot = null;

            // Loop through the parking slots to find the first unoccupied slot
            while (slotNumber <= slots.Count && !slotFound)
            {
                string query;
                
                if (department == "cics")
                {
                    query = "SELECT isOccupied FROM cics WHERE parkingSlot = @slotNumber;";
                }
                else if (department == "ceafa")
                {
                    query = "SELECT isOccupied FROM ceafa WHERE parkingSlot = @slotNumber;";
                }
                else if (department == "cit")
                {
                    query = "SELECT isOccupied FROM cit WHERE parkingSlot = @slotNumber;";
                }
                else if (department == "coe")
                {
                    query = "SELECT isOccupied FROM coe WHERE parkingSlot = @slotNumber;";
                }
                else {
                    continue;
                }
                
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@slotNumber", slotNumber);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Check for DBNull before casting
                            bool isOccupied = !reader.IsDBNull(reader.GetOrdinal("isOccupied")) && reader.GetBoolean("isOccupied");
                            if (!isOccupied)
                            {
                                // Slot is not occupied, use this slot
                                emptySlot = slots[slotNumber - 1];
                                slotFound = true;
                            }
                        }
                    }
                }
                if (!slotFound)
                {
                    slotNumber++; // Increment slot number and check the next slot
                }
            }

            if (slotFound && emptySlot != null)
            {
                // Park the vehicle in the found slot and update the database
                emptySlot.IsOccupied = true;
                emptySlot.FullName = fullName;
                emptySlot.VehicleType = vehicleType;
                emptySlot.VehicleNumber = vehicleNumber;
                emptySlot.EntryTime = DateTime.Now;

                // Update the ParkingEvents table with the new parking information
                string updateQuery;

                if (department == "cics")
                {
                    updateQuery = "UPDATE cics SET isOccupied = @isOccupied, fullName = @fullName, vehicleType = @vehicleType, vehicleNumber = @vehicleNumber, entryTime = @entryTime WHERE parkingSlot = @slotNumber;";
                }
                else if (department == "ceafa")
                {
                    updateQuery = "UPDATE ceafa SET isOccupied = @isOccupied, fullName = @fullName, vehicleType = @vehicleType, vehicleNumber = @vehicleNumber, entryTime = @entryTime WHERE parkingSlot = @slotNumber;";
                }
                else if (department == "cit")
                {
                    updateQuery = "UPDATE cit SET isOccupied = @isOccupied, fullName = @fullName, vehicleType = @vehicleType, vehicleNumber = @vehicleNumber, entryTime = @entryTime WHERE parkingSlot = @slotNumber;";
                }
                else if (department == "coe")
                {
                    updateQuery = "UPDATE coe SET isOccupied = @isOccupied, fullName = @fullName, vehicleType = @vehicleType, vehicleNumber = @vehicleNumber, entryTime = @entryTime WHERE parkingSlot = @slotNumber;";
                }
                else {
                    updateQuery = "UPDATE cics SET isOccupied = @isOccupied, fullName = @fullName, vehicleType = @vehicleType, vehicleNumber = @vehicleNumber, entryTime = @entryTime WHERE parkingSlot = @slotNumber;";
                }


                using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@isOccupied", true);
                    updateCommand.Parameters.AddWithValue("@fullName", fullName);
                    updateCommand.Parameters.AddWithValue("@vehicleType", vehicleType);
                    updateCommand.Parameters.AddWithValue("@vehicleNumber", vehicleNumber);
                    updateCommand.Parameters.AddWithValue("@entryTime", emptySlot.EntryTime);
                    updateCommand.Parameters.AddWithValue("@slotNumber", slotNumber);

                    updateCommand.ExecuteNonQuery();
                }

                databaseOperations.SynchronizeSlotsWithDatabase(this.slots);

                Console.WriteLine($"Vehicle {vehicleNumber} (Driver: {fullName}) parked at slot {slotNumber}.");
                return true;
            }
            else
            {
                if (isPWD == true)
                {
                    isPWD = false;
                    ParkVehicle(fullName, vehicleType, vehicleNumber, isPWD, department);
                }
                Console.WriteLine("Parking lot is full or no available slots.");
                return false;
            }
        }

        public bool LeaveParking(string vehicleNumber, string dep)
        {
            databaseOperations.SynchronizeSlotsWithDatabase(this.slots);

            // Check if the vehicle is in the parking lot by querying the database
            string checkQuery;
            if (dep == "cics") {
                checkQuery = "SELECT parkingSlot FROM cics WHERE vehicleNumber = @vehicleNumber AND isOccupied = TRUE;";

            } else if (dep == "coe") {
                checkQuery = "SELECT parkingSlot FROM coe WHERE vehicleNumber = @vehicleNumber AND isOccupied = TRUE;";

            } else if (dep =="ceafa") {
                checkQuery = "SELECT parkingSlot FROM ceafa WHERE vehicleNumber = @vehicleNumber AND isOccupied = TRUE;";

            } else if (dep == "cit") {
                checkQuery = "SELECT parkingSlot FROM cit WHERE vehicleNumber = @vehicleNumber AND isOccupied = TRUE;";

            }
            else {
                checkQuery = "SELECT parkingSlot FROM cics WHERE vehicleNumber = @vehicleNumber AND isOccupied = TRUE;";

            }


            int parkingSlotId = -1;
            using (MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection))
            {
                checkCommand.Parameters.AddWithValue("@vehicleNumber", vehicleNumber);
                using (MySqlDataReader reader = checkCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        parkingSlotId = reader.GetInt32("parkingSlot");
                    }
                }
            }

            if (parkingSlotId != -1)
            {
                // Vehicle found, proceed with leaving parking logic
                var occupiedSlot = slots.FirstOrDefault(slot => slot.IsOccupied && slot.VehicleNumber == vehicleNumber);
                if (occupiedSlot != null)
                {
                    // Calculate the duration and total cost
                    CostCalculator costCalculator = new CostCalculator();
                    occupiedSlot.ExitTime = DateTime.Now;
                    TimeSpan duration = occupiedSlot.ExitTime - occupiedSlot.EntryTime;
                    double totalCost = costCalculator.CalculateTotalCost(duration);

                    // Insert data into the ParkingReceipts table
                    databaseOperations.InsertParkingReceipt(parkingSlotId, occupiedSlot.FullName, occupiedSlot.VehicleType, vehicleNumber, occupiedSlot.EntryTime, occupiedSlot.ExitTime, duration, totalCost);

                    // Generate the PDF receipt
                    PDFReceiptGenerator.GenerateReceipt(occupiedSlot.FullName, occupiedSlot.VehicleType, vehicleNumber, occupiedSlot.EntryTime, occupiedSlot.ExitTime, duration, totalCost);

                    // Reset the parking slot
                    occupiedSlot.IsOccupied = false;
                    occupiedSlot.FullName = null;
                    occupiedSlot.VehicleType = null;
                    occupiedSlot.VehicleNumber = null;
                    occupiedSlot.EntryTime = DateTime.MinValue;
                    occupiedSlot.ExitTime = DateTime.MinValue;

                    // Update the ParkingEvents table to set all values to NULL
                    string updateQuery;
                    if (dep == "cics")
                    {
                        updateQuery = "UPDATE cics SET isOccupied = NULL, fullName = NULL, vehicleType = NULL, vehicleNumber = NULL, entryTime = NULL WHERE parkingSlot = @parkingSlotId;";

                    }
                    else if (dep == "coe")
                    {

                        updateQuery = "UPDATE coe SET isOccupied = NULL, fullName = NULL, vehicleType = NULL, vehicleNumber = NULL, entryTime = NULL WHERE parkingSlot = @parkingSlotId;";

                    }
                    else if (dep == "cit")
                    {
                        updateQuery = "UPDATE cit SET isOccupied = NULL, fullName = NULL, vehicleType = NULL, vehicleNumber = NULL, entryTime = NULL WHERE parkingSlot = @parkingSlotId;";

                    }
                    else if (dep == "ceafa")
                    {
                        updateQuery = "UPDATE ceafa SET isOccupied = NULL, fullName = NULL, vehicleType = NULL, vehicleNumber = NULL, entryTime = NULL WHERE parkingSlot = @parkingSlotId;";

                    }
                    else {
                        updateQuery = "UPDATE cics SET isOccupied = NULL, fullName = NULL, vehicleType = NULL, vehicleNumber = NULL, entryTime = NULL WHERE parkingSlot = @parkingSlotId;";

                    }

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
                    Console.WriteLine($"DEBUG: Vehicle {vehicleNumber} found in database but not in application memory.");
                    return false;
                }
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
