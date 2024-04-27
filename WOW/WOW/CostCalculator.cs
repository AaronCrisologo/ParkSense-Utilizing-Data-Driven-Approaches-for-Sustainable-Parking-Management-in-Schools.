using System;

namespace ParkingManagementSystem
{
    public class CostCalculator
    {
        public double CalculateTotalCost(TimeSpan duration)
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

            return fee;
        }
    }
}
