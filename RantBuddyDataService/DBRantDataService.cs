using RantBuddyCommon;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace RantBuddyDataService
{
    public class DBRantDataService : IRantDataService
    {
        private static string connectionString =
            "Data Source=VERSOZA\\SQLEXPRESS;Initial Catalog=RantBuddyDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

        public DBRantDataService()
        {
            EnsureTablesExist();
        }

        private void EnsureTablesExist()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(@"
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Rants' AND xtype='U')
                    CREATE TABLE Rants (
                        Id INT IDENTITY PRIMARY KEY,
                        Username NVARCHAR(100),
                        Content NVARCHAR(MAX)
                    );

                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Accounts' AND xtype='U')
                    CREATE TABLE Accounts (
                        Username NVARCHAR(100) PRIMARY KEY,
                        Pin NVARCHAR(10)
                    );

                    IF NOT EXISTS (SELECT * FROM Accounts WHERE Username='taniah')
                    INSERT INTO Accounts (Username, Pin) VALUES ('taniah', '1234');

                    IF NOT EXISTS (SELECT * FROM Accounts WHERE Username='brit')
                    INSERT INTO Accounts (Username, Pin) VALUES ('brit', '1201');
                ", connection);
                command.ExecuteNonQuery();
            }
        }

        public List<Rant> LoadRants()
        {
            var rants = new List<Rant>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT Id, Username, Content FROM Rants", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        rants.Add(new Rant
                        {
                            Id = reader.GetInt32(0),
                            Username = reader.GetString(1),
                            Content = reader.GetString(2)
                        });
                    }
                }
            }
            return rants;
        }

        public void AddEntry(Rant rant)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Rants (Username, Content) VALUES (@username, @content)", connection);
                command.Parameters.AddWithValue("@username", rant.Username);
                command.Parameters.AddWithValue("@content", rant.Content);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateEntry(int id, Rant rant)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("UPDATE Rants SET Username = @username, Content = @content WHERE Id = @id", connection);
                command.Parameters.AddWithValue("@username", rant.Username);
                command.Parameters.AddWithValue("@content", rant.Content);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteEntry(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Rants WHERE Id = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

        public List<Rant> SearchEntry(string keyword)
        {
            var results = new List<Rant>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT Id, Username, Content FROM Rants WHERE Content LIKE @keyword", connection);
                command.Parameters.AddWithValue("@keyword", $"%{keyword}%");

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(new Rant
                        {
                            Id = reader.GetInt32(0),
                            Username = reader.GetString(1),
                            Content = reader.GetString(2)
                        });
                    }
                }
            }
            return results;
        }

        public bool HasEntries()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT COUNT(*) FROM Rants", connection);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        public bool ValidateAccount(string username, string pin)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT COUNT(*) FROM Accounts WHERE Username = @username AND Pin = @pin", connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@pin", pin);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        public void SaveRants() { }
    }
}
