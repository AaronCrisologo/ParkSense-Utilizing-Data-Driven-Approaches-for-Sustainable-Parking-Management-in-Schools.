using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ParkingManagementSystem
{
    class DatabaseOperations : IDisposable
    {
        private MySqlConnection connection;

        public DatabaseOperations(string connectionString)
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        public void SynchronizeSlotsWithDatabase(List<ParkingSlot> slots)
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

        public void Dispose()
        {
            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }
}
