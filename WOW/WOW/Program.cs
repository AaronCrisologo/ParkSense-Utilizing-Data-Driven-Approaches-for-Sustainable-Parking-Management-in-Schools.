using System;
using System.IO;
using System.Collections.Generic;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.IO.Image;

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

    class ParkingLot
    {
        private List<ParkingSlot> slots;
        private string filePath = @"C:\Users\Nielle\Downloads\Database_setup.csv";
        private double parkingRatePerHour = 30;

        public ParkingLot(int capacity)
        {
            slots = new List<ParkingSlot>();
            for (int i = 1; i <= capacity; i++)
            {
                slots.Add(new ParkingSlot());
            }
        }

        public bool ParkVehicle(string fullName, string vehicleType, string vehicleNumber)
        {
            foreach (var slot in slots)
            {
                if (!slot.IsOccupied)
                {
                    slot.IsOccupied = true;
                    slot.FullName = fullName;
                    slot.VehicleType = vehicleType;
                    slot.VehicleNumber = vehicleNumber;
                    slot.EntryTime = DateTime.Now;

                    Console.WriteLine($"Vehicle {vehicleNumber} (Driver: {fullName}) parked at slot {slots.IndexOf(slot) + 1} at {slot.EntryTime}.");
                    return true;
                }
            }
            Console.WriteLine("Parking lot is full");
            return false;
        }

        public bool LeaveParking(string vehicleNumber)
        {
            foreach (var slot in slots)
            {
                if (slot.IsOccupied && slot.VehicleNumber == vehicleNumber)
                {
                    slot.IsOccupied = false;
                    slot.FullName = "";
                    slot.VehicleType = "";
                    slot.VehicleNumber = "";
                    slot.ExitTime = DateTime.Now;
                    TimeSpan duration = slot.ExitTime - slot.EntryTime;
                    double totalHours = duration.TotalHours;
                    double totalCost = totalHours < 1 ? parkingRatePerHour : totalHours * parkingRatePerHour;

                    PDFReceiptGenerator.GenerateReceipt(slot.FullName, slot.VehicleType, vehicleNumber, slot.EntryTime, slot.ExitTime, duration, totalCost);

                    Console.WriteLine($"Vehicle {vehicleNumber} left the parking at {slot.ExitTime}. Duration: {duration}. Total Cost: {totalCost} PHP");
                    return true;
                }
            }
            Console.WriteLine($"Vehicle {vehicleNumber} not found in the parking lot");
            return false;
        }

        public void DisplayParkingStatus()
        {
            Console.WriteLine("Parking Status:");
            Console.WriteLine("+-------------+-----------+----------------+-----------------+----------------------+");
            Console.WriteLine("| Slot Number |  Status   | Vehicle Number |  Vehicle Type  |     Driver's Name    |");
            Console.WriteLine("+-------------+-----------+----------------+-----------------+----------------------+");
            foreach (var slot in slots)
            {
                string status = slot.IsOccupied ? "Occupied" : "Empty";
                string vehicleNumber = slot.IsOccupied ? slot.VehicleNumber : "-";
                string vehicleType = slot.IsOccupied ? slot.VehicleType : "-";
                string fullName = slot.IsOccupied ? slot.FullName : "-";
                Console.WriteLine($"| {slots.IndexOf(slot) + 1,-11} | {status,-9} | {vehicleNumber,-14} | {vehicleType,-15} | {fullName,-20} |");
            }
            Console.WriteLine("+-------------+-----------+----------------+-----------------+----------------------+");
        }

        public void DisplayParkingLog()
        {
            Console.WriteLine("Parking Log:");
            // Display log from CSV
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading log: {ex.Message}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ParkingLot parkingLot = new ParkingLot(10);

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
