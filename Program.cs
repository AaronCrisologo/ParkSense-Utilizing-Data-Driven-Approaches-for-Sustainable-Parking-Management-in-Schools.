using System;
using System.Collections.Generic;

namespace ParkingManagementSystem
{
    // Class representing a parking slot
    class ParkingSlot
    {
        public int SlotNumber { get; set; }
        public string VehicleNumber { get; set; } = ""; // Initialize to empty string
        public bool IsOccupied { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; }

        public ParkingSlot(int slotNumber)
        {
            SlotNumber = slotNumber;
            IsOccupied = false;
        }
    }

    // Class representing the Parking Lot
    class ParkingLot
    {
        private List<ParkingSlot> slots;
        private List<string> parkingLog;
        private double parkingRatePerHour = 30; // Parking rate per hour

        public ParkingLot(int capacity)
        {
            slots = new List<ParkingSlot>();
            parkingLog = new List<string>();
            for (int i = 1; i <= capacity; i++)
            {
                slots.Add(new ParkingSlot(i));
            }
        }

        // Method to park a vehicle
        public bool ParkVehicle(string vehicleNumber)
        {
            foreach (var slot in slots)
            {
                if (!slot.IsOccupied)
                {
                    slot.IsOccupied = true;
                    slot.VehicleNumber = vehicleNumber;
                    slot.EntryTime = DateTime.Now;
                    string logEntry = $"Vehicle {vehicleNumber} parked at slot {slot.SlotNumber} at {slot.EntryTime}.";
                    parkingLog.Add(logEntry);
                    Console.WriteLine(logEntry);
                    Console.WriteLine("Your car has been parked");
                    return true;
                }
            }
            Console.WriteLine("Parking lot is full");
            return false;
        }

        // Method to leave the parking
        public bool LeaveParking(string vehicleNumber)
        {
            foreach (var slot in slots)
            {
                if (slot.IsOccupied && slot.VehicleNumber == vehicleNumber)
                {
                    slot.IsOccupied = false;
                    slot.VehicleNumber = ""; // Assign empty string
                    slot.ExitTime = DateTime.Now;
                    TimeSpan duration = slot.ExitTime - slot.EntryTime;
                    double totalHours = duration.TotalHours;
                    double totalCost = totalHours < 1 ? parkingRatePerHour : totalHours * parkingRatePerHour;
                    string logEntry = $"Vehicle {vehicleNumber} left the parking at {slot.ExitTime}. Duration: {duration}. Total Cost: {totalCost} PHP";
                    parkingLog.Add(logEntry);
                    Console.WriteLine(logEntry);
                    Console.WriteLine("Drive safely");
                    return true;
                }
            }
            Console.WriteLine($"Vehicle {vehicleNumber} not found in the parking lot");
            return false;
        }

        // Method to display parking status
        public void DisplayParkingStatus()
        {
            Console.WriteLine("Parking Status:");
            Console.WriteLine("+-------------+-----------+----------------+-----------------+");
            Console.WriteLine("| Slot Number |  Status   | Vehicle Number |    Parking Rate |");
            Console.WriteLine("+-------------+-----------+----------------+-----------------+");
            foreach (var slot in slots)
            {
                string status = slot.IsOccupied ? "Occupied" : "Empty";
                string vehicleNumber = slot.IsOccupied ? slot.VehicleNumber : "-";
                string parkingRate = slot.IsOccupied ? parkingRatePerHour.ToString() : "-"; // Display parking rate only if occupied
                Console.WriteLine($"| {slot.SlotNumber,-11} | {status,-9} | {vehicleNumber,-14} | {parkingRate,-15} |");
            }
            Console.WriteLine("+-------------+-----------+----------------+-----------------+");
        }

        // Method to display parking log
        public void DisplayParkingLog()
        {
            Console.WriteLine("Parking Log:");
            foreach (var logEntry in parkingLog)
            {
                Console.WriteLine(logEntry);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a parking lot with 10 slots
            ParkingLot parkingLot = new ParkingLot(10);

            do
            {
                Console.WriteLine("-----Welcome to Parksense-----");
                Console.WriteLine("Would you like to park your car?,   press 1");
                Console.WriteLine("Do you want to take your car?,      press 2");
                Console.WriteLine("Display the parking area,           press 3");
                Console.WriteLine("Display the logs,                   press 4\n");
                Console.Write("What do you want to do: ");
                int dec = int.Parse(Console.ReadLine());
                Console.WriteLine(" ");
                switch (dec)
                {
                    case 1:
                        Console.Write("Enter your car's license number: ");
                        String num = Console.ReadLine();
                        parkingLot.ParkVehicle(num);
                        Console.WriteLine("++++++++++++++++++++++++++++\n");
                        break;
                    case 2:
                        Console.Write("Input your car's license number: ");
                        String car = Console.ReadLine();
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
                    default:
                        Console.WriteLine("Invalid input, please try again");
                        Console.WriteLine("++++++++++++++++++++++++++++\n");
                        break;
                }

            } while (true);

        }
    }
}
