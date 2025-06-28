using RantBuddyCommon;
using RantBuddyDataService;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RantBuddy_DataService
{
    public class DBRantDataService : IRantDataService
    {
        private string connectionString = "Data Source=VERSOZA\\sqlexpress;Initial Catalog=Rant_Buddy;Integrated Security=True";

        public void AddEntry(Rant rant)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Rants (Username, Content) VALUES (@Username, @Content)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", rant.Username);
                cmd.Parameters.AddWithValue("@Content", rant.Content);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteEntry(int index)
        {
            List<Rant> rants = LoadRants();
            if (index >= 0 && index < rants.Count)
            {
                Rant rantToDelete = rants[index];

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Rants WHERE Username = @Username AND Content = @Content";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", rantToDelete.Username);
                    cmd.Parameters.AddWithValue("@Content", rantToDelete.Content);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool HasEntries()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Rants";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public List<Rant> LoadRants()
        {
            List<Rant> rants = new List<Rant>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Username, Content FROM Rants";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Rant r = new Rant();
                    r.Username = reader["Username"].ToString();
                    r.Content = reader["Content"].ToString();
                    rants.Add(r);
                }
            }

            return rants;
        }

        public void SaveRants()
        {
          
        }

        public List<Rant> SearchEntry(string keyword)
        {
            List<Rant> results = new List<Rant>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Username, Content FROM Rants WHERE Content LIKE @keyword";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Rant r = new Rant();
                    r.Username = reader["Username"].ToString();
                    r.Content = reader["Content"].ToString();
                    results.Add(r);
                }
            }

            return results;
        }

        public void UpdateEntry(int index, Rant rant)
        {
            List<Rant> rants = LoadRants();
            if (index >= 0 && index < rants.Count)
            {
                Rant oldRant = rants[index];

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Rants SET Username = @NewUsername, Content = @NewContent WHERE Username = @OldUsername AND Content = @OldContent";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NewUsername", rant.Username);
                    cmd.Parameters.AddWithValue("@NewContent", rant.Content);
                    cmd.Parameters.AddWithValue("@OldUsername", oldRant.Username);
                    cmd.Parameters.AddWithValue("@OldContent", oldRant.Content);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool ValidateAccount(string username, string pin)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Accounts WHERE Username = @username AND Pin = @pin";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@pin", pin);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }
}
