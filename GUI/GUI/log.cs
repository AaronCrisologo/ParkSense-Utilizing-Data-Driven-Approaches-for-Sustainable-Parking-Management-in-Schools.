using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParkingManagementSystem;

namespace GUI
{
    public partial class log : Form
    {

        public log()
        {
            InitializeComponent();
        }
        private static string connectionString = "server=localhost;database=parkinglot1;uid=root;pwd=password;";

        private void log_Load(object sender, EventArgs e)
        {
            DisplayParkingLog(connectionString);
        }
        public void DisplayParkingLog(string connectionString)
        {
            try
            {
                
                string query = "SELECT * FROM ParkingReceipts;";

              
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open(); // Open the connection

                    // Execute the query and retrieve the data
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // Iterate through the result set
                            while (reader.Read())
                            {
                                // Retrieve each column value
                                int parkingSlot = reader.GetInt32("parkingSlot");
                                string fullName = reader.GetString("fullName");
                                string vehicleType = reader.GetString("vehicleType");
                                string vehicleNumber = reader.GetString("vehicleNumber");
                                DateTime entryTime = reader.GetDateTime("entryTime");
                                DateTime exitTime = reader.GetDateTime("exitTime");
                                TimeSpan duration = reader.GetTimeSpan("duration");
                                double totalCost = reader.GetDouble("totalCost");
                                string dep = reader.GetString("department");

                                // Add a new row to the DataGridView
                                datacics.Rows.Add(parkingSlot, fullName, vehicleType, vehicleNumber, entryTime, exitTime, duration, totalCost, dep);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }





        private void datacics_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void loadbtn_Click(object sender, EventArgs e)
        {
            DisplayParkingLog(connectionString);
        }
    }
}
