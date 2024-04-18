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
                    string logEntry = $"Vehicle {vehicleNumber} parked at slot {slot.SlotNumber} at {slot.EntryTime}";
                    parkingLog.Add(logEntry);
                    Console.WriteLine(logEntry);
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
                    string logEntry = $"Vehicle {vehicleNumber} left the parking at {slot.ExitTime}. Duration: {slot.ExitTime - slot.EntryTime}";
                    parkingLog.Add(logEntry);
                    Console.WriteLine(logEntry);
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
            Console.WriteLine("+-------------+-----------+----------------+");
            Console.WriteLine("| Slot Number |  Status   | Vehicle Number |");
            Console.WriteLine("+-------------+-----------+----------------+");
            foreach (var slot in slots)
            {
                string status = slot.IsOccupied ? "Occupied" : "Empty";
                string vehicleNumber = slot.IsOccupied ? slot.VehicleNumber : "-";
                Console.WriteLine($"| {slot.SlotNumber,-11} | {status,-9} | {vehicleNumber,-14} |");
            }
            Console.WriteLine("+-------------+-----------+----------------+");
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

            // Example usage
            parkingLot.DisplayParkingStatus();

            parkingLot.ParkVehicle("ABC123");
            parkingLot.ParkVehicle("XYZ456");

            parkingLot.DisplayParkingStatus();

            parkingLot.LeaveParking("ABC123");

            parkingLot.DisplayParkingStatus();

            // Adding a car to the parking lot
            parkingLot.ParkVehicle("DEF789");

            // Removing a car from the parking lot
            parkingLot.LeaveParking("XYZ456");

            parkingLot.DisplayParkingStatus();
            parkingLot.ParkVehicle("12333");
            parkingLot.DisplayParkingStatus();
            parkingLot.LeaveParking("12333");
            parkingLot.DisplayParkingStatus();

            // Displaying parking log
            parkingLot.DisplayParkingLog();
        }
    }
}
