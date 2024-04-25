namespace ParkingManagementSystem
{
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
}
