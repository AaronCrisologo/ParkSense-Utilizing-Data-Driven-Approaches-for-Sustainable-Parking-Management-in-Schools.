using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    internal class accounts: Form
    {
        private static string connectionString = "server=localhost;database=parkinglot1;uid=root;pwd=password;";

        public bool RegisterUser(string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Check if the username already exists
                    string checkQuery = "SELECT COUNT(*) FROM login WHERE username = @username";
                    MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@username", username);
                    int existingUserCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (existingUserCount > 0)
                    {

                        return false;
                    }

                    // If the username doesn't exist, register the new user
                    string registerQuery = "INSERT INTO login (username, password) VALUES (@username, @password)";
                    MySqlCommand registerCommand = new MySqlCommand(registerQuery, connection);
                    registerCommand.Parameters.AddWithValue("@username", username);
                    registerCommand.Parameters.AddWithValue("@password", password);

                    int rowsAffected = registerCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {

                        return true;
                    }
                    else
                    {

                        return false;
                    }
                }
                catch (Exception ex)
                {

                    return false;
                }
            }
        }



        public bool CheckCredentials(string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM login WHERE username = @username AND password = @password";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count > 0)
                    {
                        // Username and password are correct
                        return true;
                    }
                    else
                    {
                        // Username or password is incorrect
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
