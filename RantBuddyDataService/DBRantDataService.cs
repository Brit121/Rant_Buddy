using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RantBuddyDataService
{
    public class RBDataService
    {
        private string _connectionString = "Data Source=VERSOZA\\SQLEXPRESS;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        public bool ValidateAccount(string username, string pin)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Pin = @Pin";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Pin", pin);

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during login: " + ex.Message);
                return false;
            }
        }

        public List<string> GetAllRants()
        {
            List<string> rants = new List<string>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    string query = "SELECT Text FROM Rants";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rants.Add(reader.GetString(0));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting rants: " + ex.Message);
            }

            return rants;
        }

        public bool AddRant(string text)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    string query = "INSERT INTO Rants (Text) VALUES (@Text)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Text", text);
                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding rant: " + ex.Message);
                return false;
            }
        }
    }
}
