using System;
using System.IO;
using System.Collections.Generic;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.IO.Image;
using MySql.Data.MySqlClient;

namespace ParkingManagementSystem
{   
    class PDFReceiptGenerator
    {
        public static void GenerateReceipt(string fullName, string vehicleType, string vehicleNumber, DateTime entryTime, DateTime exitTime, TimeSpan duration, double totalCost)
        {
            string directoryPath = @"C:\Users\Nielle\Documents\Programming shit\C#\WOW\WOW\Receipts";
            Directory.CreateDirectory(directoryPath);

            string fileName = Path.Combine(directoryPath, $"{vehicleNumber}.pdf");

            // Create PDF document
            using (PdfWriter writer = new PdfWriter(fileName))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf);

                    // Add content to the PDF
                    Paragraph title = new Paragraph("Parking Receipt").SetFontSize(24).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    Paragraph line = new Paragraph("-------------------------------------------------------------").SetFontSize(14).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    Paragraph fullNameInfo = new Paragraph($"Driver's Full Name: {fullName}").SetFontSize(16).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    Paragraph vehicleTypeInfo = new Paragraph($"Vehicle Type: {vehicleType}").SetFontSize(16).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    Paragraph vehicleInfo = new Paragraph($"Vehicle License: {vehicleNumber}").SetFontSize(16).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    Paragraph entryInfo = new Paragraph($"Entry Time: {entryTime}").SetFontSize(16).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    Paragraph exitInfo = new Paragraph($"Exit Time: {exitTime}").SetFontSize(16).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    Paragraph durationInfo = new Paragraph($"Duration: {duration}").SetFontSize(16).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    Paragraph costInfo = new Paragraph($"Total Cost: {totalCost} PHP").SetFontSize(16).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    Paragraph additionalInfo = new Paragraph("Thank you for using our parking services.\nHave a safe journey!\n\nPlease keep this receipt for future reference.").SetFontSize(16).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);

                    // Load the logo
                    string logoPath = @"C:\Users\Nielle\Documents\Programming shit\C#\WOW\WOW\Logo.png";
                    iText.Layout.Element.Image logo = new iText.Layout.Element.Image(ImageDataFactory.Create(logoPath));
                    logo.SetWidth(200); // Adjust the width of the logo as needed
                    logo.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

                    document.Add(logo); // Add the logo to the document
                    document.Add(title);
                    document.Add(line);
                    document.Add(fullNameInfo);
                    document.Add(vehicleTypeInfo);
                    document.Add(vehicleInfo);
                    document.Add(entryInfo);
                    document.Add(exitInfo);
                    document.Add(durationInfo);
                    document.Add(costInfo);
                    document.Add(line); // Add another line
                    document.Add(additionalInfo); // Add additional information
                }
            }

            Console.WriteLine($"Receipt generated and saved in the Receipts Folder.");
        }
    }

    class ParkingSlot
    {
        public string FullName { get; set; }
        public string VehicleType { get; set; }
        public string VehicleNumber { get; set; }
        public bool IsOccupied { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; }

        public ParkingSlot()
        {
            IsOccupied = false;
        }
    }

    class ParkingLot : IDisposable
    {
        private List<ParkingSlot> slots;
        private MySqlConnection connection;
        private string filePath = @"C:\Users\Nielle\Downloads\Database_setup.csv";
        private double parkingRatePerHour = 30;

        public ParkingLot(int capacity, string connectionString)
        {
            slots = new List<ParkingSlot>();
            for (int i = 1; i <= capacity; i++)
            {
                slots.Add(new ParkingSlot());
            }

            // Initialize the MySQL connection
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        public void SynchronizeSlotsWithDatabase()
        {
            // Clear the current slots list
            slots.Clear();

            // Retrieve the current state from the database and update the slots list
            string query = "SELECT * FROM ParkingEvents WHERE isOccupied = TRUE;";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int slotNumber = reader.GetInt32("parkingSlot");
                        string fullName = reader.IsDBNull(reader.GetOrdinal("fullName")) ? null : reader.GetString("fullName");
                        string vehicleType = reader.IsDBNull(reader.GetOrdinal("vehicleType")) ? null : reader.GetString("vehicleType");
                        string vehicleNumber = reader.IsDBNull(reader.GetOrdinal("vehicleNumber")) ? null : reader.GetString("vehicleNumber");
                        DateTime entryTime = reader.IsDBNull(reader.GetOrdinal("entryTime")) ? DateTime.MinValue : reader.GetDateTime("entryTime");

                        // Create a new ParkingSlot object and add it to the slots list
                        ParkingSlot slot = new ParkingSlot
                        {
                            FullName = fullName,
                            VehicleType = vehicleType,
                            VehicleNumber = vehicleNumber,
                            IsOccupied = true,
                            EntryTime = entryTime
                        };

                        // Ensure the slots list has enough capacity
                        while (slots.Count < slotNumber)
                        {
                            slots.Add(new ParkingSlot()); // Add empty slots if necessary
                        }

                        // Update the slot at the correct index
                        slots[slotNumber - 1] = slot;
                    }
                }
            }
        }

        public bool ParkVehicle(string fullName, string vehicleType, string vehicleNumber)
        {
            int slotNumber = 1; // Start checking from the first slot
            bool slotFound = false;
            ParkingSlot emptySlot = null;

            // Loop through the parking slots to find the first unoccupied slot
            while (slotNumber <= slots.Count && !slotFound)
            {
                // Check if the slot is occupied by querying the database
                string query = "SELECT isOccupied FROM ParkingEvents WHERE parkingSlot = @slotNumber;";
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
                string updateQuery = "UPDATE ParkingEvents SET isOccupied = @isOccupied, fullName = @fullName, vehicleType = @vehicleType, vehicleNumber = @vehicleNumber, entryTime = @entryTime WHERE parkingSlot = @slotNumber;";
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

                Console.WriteLine($"Vehicle {vehicleNumber} (Driver: {fullName}) parked at slot {slotNumber}.");
                return true;
            }
            else
            {
                Console.WriteLine("Parking lot is full or no available slots.");
                return false;
            }
        }

        public bool LeaveParking(string vehicleNumber)
        {
            SynchronizeSlotsWithDatabase();

            // Check if the vehicle is in the parking lot by querying the database
            string checkQuery = "SELECT parkingSlot FROM ParkingEvents WHERE vehicleNumber = @vehicleNumber AND isOccupied = TRUE;";
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
                    occupiedSlot.ExitTime = DateTime.Now;
                    TimeSpan duration = occupiedSlot.ExitTime - occupiedSlot.EntryTime;
                    double totalCost = CalculateTotalCost(duration);

                    // Insert data into the ParkingReceipts table
                    InsertParkingReceipt(parkingSlotId, occupiedSlot.FullName, occupiedSlot.VehicleType, vehicleNumber, occupiedSlot.EntryTime, occupiedSlot.ExitTime, duration, totalCost);

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
                    string updateQuery = "UPDATE ParkingEvents SET isOccupied = NULL, fullName = NULL, vehicleType = NULL, vehicleNumber = NULL, entryTime = NULL WHERE parkingSlot = @parkingSlotId;";
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
            string query = "SELECT parkingSlot, isOccupied, fullName, vehicleType, vehicleNumber FROM ParkingEvents;";

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

        public void InsertParkingReceipt(int parkingSlotId, string fullName, string vehicleType, string vehicleNumber, DateTime entryTime, DateTime exitTime, TimeSpan duration, double totalCost)
        {
            string query = @"
                INSERT INTO ParkingReceipts (parkingSlot, fullName, vehicleType, vehicleNumber, entryTime, exitTime, duration, totalCost)
                VALUES (@parkingSlotId, @fullName, @vehicleType, @vehicleNumber, @entryTime, @exitTime, @duration, @totalCost);
            ";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@parkingSlotId", parkingSlotId);
                command.Parameters.AddWithValue("@fullName", fullName);
                command.Parameters.AddWithValue("@vehicleType", vehicleType);
                command.Parameters.AddWithValue("@vehicleNumber", vehicleNumber);
                command.Parameters.AddWithValue("@entryTime", entryTime);
                command.Parameters.AddWithValue("@exitTime", exitTime);
                command.Parameters.AddWithValue("@duration", duration.ToString(@"hh\:mm\:ss"));
                command.Parameters.AddWithValue("@totalCost", totalCost);

                command.ExecuteNonQuery();
            }
        }

        private double CalculateTotalCost(TimeSpan duration)
        {
            // Assuming the parking rate per hour is defined
            double totalHours = duration.TotalHours;
            return totalHours * parkingRatePerHour; // Replace 'parkingRatePerHour' with your actual rate
        }
        public void Dispose()
        {
            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }

    class Program
    {
        private static string connectionString = "server=localhost;database=parkinglot1;uid=root;pwd=password;";
        static void Main(string[] args)
        {
            using (ParkingLot parkingLot = new ParkingLot(10, connectionString))

            do
            {
                Console.WriteLine("-----Welcome to Parksense-----");
                Console.WriteLine("Would you like to park your car?,   press 1");
                Console.WriteLine("Do you want to take your car?,      press 2");
                Console.WriteLine("Display the parking area,           press 3");
                Console.WriteLine("Display the logs,                   press 4");
                Console.WriteLine("Exit the program,                   press 5\n");
                Console.Write("What do you want to do: ");

                if (!int.TryParse(Console.ReadLine(), out int dec))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                Console.WriteLine();

                switch (dec)
                {
                    case 1:
                        Console.Write("Enter your full name: ");
                        string fullName = Console.ReadLine();
                        Console.Write("Enter your vehicle type: ");
                        string vehicleType = Console.ReadLine();
                        Console.Write("Enter your car's license number: ");
                        string num = Console.ReadLine();
                        parkingLot.ParkVehicle(fullName, vehicleType, num);
                        Console.WriteLine("Your car has been parked");
                        Console.WriteLine("++++++++++++++++++++++++++++\n");
                        break;
                    case 2:
                        Console.Write("Input your car's license number: ");
                        string car = Console.ReadLine();
                        parkingLot.LeaveParking(car);
                        Console.WriteLine("++++++++++++++++++++++++++++\n");
                        break;
                    case 3:
                        parkingLot.DisplayParkingStatus();
                        break;
                    case 4:
                        parkingLot.DisplayParkingLog();
                        Console.WriteLine("++++++++++++++++++++++++++++\n");
                        break;
                    case 5:
                        Console.WriteLine("Exiting the program...");
                        return;
                    default:
                        Console.WriteLine("Invalid input, please try again");
                        Console.WriteLine("++++++++++++++++++++++++++++\n");
                        break;
                }

            } while (true);
        }
    }
}
