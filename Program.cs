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

        public ParkingLot(int capacity)
        {
            slots = new List<ParkingSlot>();
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
                    Console.WriteLine($"Vehicle {vehicleNumber} parked at slot {slot.SlotNumber}");
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
                    Console.WriteLine($"Vehicle {vehicleNumber} left the parking");
                    return true;
                }
            }
            Console.WriteLine($"Vehicle {vehicleNumber} not found in the parking lot");
            return false;
        }

        // Method to display parking status
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
        }
    }
}
