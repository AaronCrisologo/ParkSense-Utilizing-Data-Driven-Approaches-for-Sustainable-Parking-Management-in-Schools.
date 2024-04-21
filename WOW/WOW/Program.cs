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

        public bool ParkVehicle(string fullName, string vehicleType, string vehicleNumber)
        {
            // Find an empty slot
            var emptySlot = slots.FirstOrDefault(slot => !slot.IsOccupied);
            if (emptySlot != null)
            {
                emptySlot.IsOccupied = true;
                emptySlot.FullName = fullName;
                emptySlot.VehicleType = vehicleType;
                emptySlot.VehicleNumber = vehicleNumber;
                emptySlot.EntryTime = DateTime.Now;

                // Insert data into the database
                string query = "INSERT INTO ParkingEvents (slotNumber, fullName, vehicleType, vehicleNumber, entryTime, isPaid) " +
                            "VALUES (@slotNumber, @fullName, @vehicleType, @vehicleNumber, @entryTime, FALSE);";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@slotNumber", slots.IndexOf(emptySlot) + 1);
                    command.Parameters.AddWithValue("@fullName", fullName);
                    command.Parameters.AddWithValue("@vehicleType", vehicleType);
                    command.Parameters.AddWithValue("@vehicleNumber", vehicleNumber);
                    command.Parameters.AddWithValue("@entryTime", emptySlot.EntryTime);

                    command.ExecuteNonQuery();
                }

                Console.WriteLine($"Vehicle {vehicleNumber} (Driver: {fullName}) parked at slot {slots.IndexOf(emptySlot) + 1}.");
                return true;
            }
            else
            {
                Console.WriteLine("Parking lot is full.");
                return false;
            }
        }


        public bool LeaveParking(string vehicleNumber)
        {
            // Find the parking slot with the given vehicle number
            var occupiedSlot = slots.FirstOrDefault(slot => slot.IsOccupied && slot.VehicleNumber == vehicleNumber);
            if (occupiedSlot != null)
            {
                // Calculate the duration and total cost
                occupiedSlot.ExitTime = DateTime.Now;
                TimeSpan duration = occupiedSlot.ExitTime - occupiedSlot.EntryTime;
                double totalCost = CalculateTotalCost(duration);

                // Update the ParkingEvents table with the exit time, duration, and total cost
                string query = "UPDATE ParkingEvents SET exitTime = @exitTime, duration = @duration, totalCost = @totalCost, isPaid = @isPaid " +
                            "WHERE vehicleNumber = @vehicleNumber AND exitTime IS NULL;";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@exitTime", occupiedSlot.ExitTime);
                    command.Parameters.AddWithValue("@duration", duration);
                    command.Parameters.AddWithValue("@totalCost", totalCost);
                    command.Parameters.AddWithValue("@isPaid", false); // Set this to true if the payment is confirmed
                    command.Parameters.AddWithValue("@vehicleNumber", vehicleNumber);

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        // Reset the parking slot
                        occupiedSlot.IsOccupied = false;
                        occupiedSlot.FullName = null;
                        occupiedSlot.VehicleType = null;
                        occupiedSlot.VehicleNumber = null;
                        occupiedSlot.EntryTime = DateTime.MinValue;
                        occupiedSlot.ExitTime = DateTime.MinValue;

                        Console.WriteLine($"Vehicle {vehicleNumber} has left the parking lot. Duration: {duration}, Total Cost: {totalCost:C}.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Error: No record was updated. Please check the vehicle number and try again.");
                        return false;
                    }
                }
            }
            else
            {
                Console.WriteLine($"Vehicle {vehicleNumber} not found in the parking lot.");
                Console.WriteLine($"DEBUG: Vehicle number entered: {vehicleNumber}");
                return false;
            }
        }

        private double CalculateTotalCost(TimeSpan duration)
        {
            // Assuming the parking rate per hour is defined
            double totalHours = duration.TotalHours;
            return totalHours * parkingRatePerHour; // Replace 'parkingRatePerHour' with your actual rate
        }

        public void DisplayParkingStatus()
        {
            Console.WriteLine("Parking Status:");
            Console.WriteLine("+-------------+-----------+----------------+-----------------+----------------------+");
            Console.WriteLine("| Slot Number |  Status   | Vehicle Number |  Vehicle Type  |     Driver's Name    |");
            Console.WriteLine("+-------------+-----------+----------------+-----------------+----------------------+");

            string query = "SELECT slotNumber, fullName, vehicleType, vehicleNumber, entryTime FROM ParkingEvents WHERE exitTime IS NULL;";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int slotNumber = reader.GetInt32("slotNumber");
                        string fullName = reader.GetString("fullName");
                        string vehicleType = reader.GetString("vehicleType");
                        string vehicleNumber = reader.GetString("vehicleNumber");
                        DateTime entryTime = reader.GetDateTime("entryTime");

                        Console.WriteLine($"| {slotNumber,-11} | {"Occupied",-9} | {vehicleNumber,-14} | {vehicleType,-15} | {fullName,-20} |");
                    }
                }
            }

            Console.WriteLine("+-------------+-----------+----------------+-----------------+----------------------+");
        }

        public void DisplayParkingLog()
        {
            Console.WriteLine("Parking Log:");
            Console.WriteLine("+----+-------------+----------------+-----------------+----------------+-----------------+----------+-----------+--------+");
            Console.WriteLine("| ID | Slot Number | Vehicle Number | Vehicle Type    | Driver's Name  | Entry Time      | Exit Time| Duration  | Cost   |");
            Console.WriteLine("+----+-------------+----------------+-----------------+----------------+-----------------+----------+-----------+--------+");

            string query = "SELECT * FROM ParkingEvents;";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("id");
                        int slotNumber = reader.GetInt32("slotNumber");
                        string fullName = reader.GetString("fullName");
                        string vehicleType = reader.GetString("vehicleType");
                        string vehicleNumber = reader.GetString("vehicleNumber");
                        DateTime entryTime = reader.GetDateTime("entryTime");
                        DateTime? exitTime = reader.IsDBNull(reader.GetOrdinal("exitTime")) ? (DateTime?)null : reader.GetDateTime("exitTime");
                        string duration = reader.IsDBNull(reader.GetOrdinal("duration")) ? "-" : reader.GetTimeSpan(reader.GetOrdinal("duration")).ToString();
                        double totalCost = reader.IsDBNull(reader.GetOrdinal("totalCost")) ? 0 : reader.GetDouble("totalCost");
                        bool isPaid = reader.GetBoolean("isPaid");

                        Console.WriteLine($"| {id,-2} | {slotNumber,-11} | {vehicleNumber,-14} | {vehicleType,-15} | {fullName,-14} | {entryTime,-15:yyyy-MM-dd HH:mm:ss} | {exitTime?.ToString("yyyy-MM-dd HH:mm:ss") ?? "-",-9} | {duration,-9} | {totalCost,-6:0.00} |");
                    }
                }
            }

            Console.WriteLine("+----+-------------+----------------+-----------------+----------------+-----------------+----------+-----------+--------+");
        }

        public void InsertParkingReceipt(string fullName, string vehicleType, string vehicleNumber, DateTime entryTime, DateTime? exitTime, TimeSpan duration, double totalCost)
        {
            string query = "INSERT INTO ParkingReceipts (fullName, vehicleType, vehicleNumber, entryTime, exitTime, duration, totalCost) " +
                        "VALUES (@fullName, @vehicleType, @vehicleNumber, @entryTime, @exitTime, @duration, @totalCost);";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@fullName", fullName);
                command.Parameters.AddWithValue("@vehicleType", vehicleType);
                command.Parameters.AddWithValue("@vehicleNumber", vehicleNumber);
                command.Parameters.AddWithValue("@entryTime", entryTime);
                command.Parameters.AddWithValue("@exitTime", (object)exitTime ?? DBNull.Value);
                command.Parameters.AddWithValue("@duration", duration.ToString(@"hh\:mm\:ss"));
                command.Parameters.AddWithValue("@totalCost", totalCost);

                command.ExecuteNonQuery();
            }
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
