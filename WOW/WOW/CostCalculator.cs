using System;

namespace ParkingManagementSystem
{
    class CostCalculator
    {
        public double CalculateTotalCost(TimeSpan duration, string vehicleType)
        {
            // Set parking fee initially as 0
            int fee = 0;

            // Add +30 to fee for every hour consumed
            double totalHours = duration.TotalHours;
            while (totalHours > 0)
            {
                fee += 30;
                totalHours--;
            }

            if (vehicleType.ToLower() == "motor" || vehicleType.ToLower() == "motorcycle" || vehicleType.ToLower() == "bike")
            {
            fee /= 2; // Divide total cost by 2 for motor, motorcycle, or bike
            }

            return fee;
        }
    }
}
