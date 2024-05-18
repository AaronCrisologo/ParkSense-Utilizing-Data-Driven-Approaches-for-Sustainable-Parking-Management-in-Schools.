using System;
using MySql.Data.MySqlClient;

public class CostCalculator
{
    private string connectionString;

    public CostCalculator(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public double CalculateTotalCost(TimeSpan duration, string vehicleType)
    {
        object queryResult;
        double fee = 30;
        double totalCost = 0;
        double totalHours = duration.TotalHours;

        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string vehicle = vehicleType.ToLower();
                string query = "SELECT fee FROM rates WHERE vehicletype = @VehicleType";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@VehicleType", vehicle);

                    queryResult = command.ExecuteScalar();

                    if (queryResult != null)
                    {
                        if (double.TryParse(queryResult.ToString(), out fee))
                        {
                            while (totalHours > 0)
                            {
                                totalCost += fee;
                                totalHours--;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Failed to convert fee to double for vehicle type: " + vehicleType);
                        }
                    }
                    else
                    {
                        while (totalHours > 0)
                        {
                            totalCost += fee;
                            totalHours--;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        return totalCost; // Return the total cost as a double
    }
    public double CalculateTotalCostForDepartment(string department, string connection1)
    {
        double totalCost = 0;

        try
        {
            using (MySqlConnection connection = new MySqlConnection(connection1))
            {
                connection.Open();

                string query = "SELECT totalcost FROM parkingreceipts WHERE department = @Department";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Department", department);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                totalCost += reader.GetDouble(0);
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        return totalCost;
    }


}