using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using RantBuddyCommon;
using RantBuddyDataService;
using CommonRant = RantBuddyCommon.Rant;

namespace RantBuddyDataService
{
    public class JSONFileDataService : IRantDataService
    {
        private readonly string rantsFilePath = "rants.json";
        private readonly string accountsFilePath = "accounts.json";

        private List<CommonRant> rants = new List<CommonRant>();
        private List<RBAccount> accounts = new List<RBAccount>();

        public JSONFileDataService()
        {
            LoadAccounts();
            LoadRants();
        }

        public bool ValidateAccount(string username, string pin)
        {
            return accounts.Any(acc =>
                string.Equals(acc.UserName, username, StringComparison.OrdinalIgnoreCase) &&
                acc.Pin == pin);
        }

        public void AddEntry(CommonRant rant)
        {
            rants.Add(rant);
            SaveRants();
        }

        public void DeleteEntry(int index)
        {
            if (index >= 0 && index < rants.Count)
            {
                rants.RemoveAt(index);
                SaveRants();
            }
        }

        public void UpdateEntry(int index, CommonRant newRant)
        {
            if (index >= 0 && index < rants.Count)
            {
                rants[index] = newRant;
                SaveRants();
            }
        }

        public List<CommonRant> LoadRants()
        {
            if (File.Exists(rantsFilePath))
            {
                try
                {
                    string json = File.ReadAllText(rantsFilePath);
                    rants = JsonSerializer.Deserialize<List<CommonRant>>(json) ?? new List<CommonRant>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading rants: {ex.Message}");
                }
            }

            return rants;
        }

        public List<CommonRant> SearchEntry(string keyword)
        {
            return rants
                .Where(r => r.Content.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public void SaveRants(List<CommonRant> rants)
        {
            try
            {
                string json = JsonSerializer.Serialize(rants, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(rantsFilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving rants: {ex.Message}");
            }
        }

        private void SaveRants()
        {
            SaveRants(rants);
        }

        private void LoadAccounts()
        {
            if (File.Exists(accountsFilePath))
            {
                try
                {
                    string json = File.ReadAllText(accountsFilePath);
                    accounts = JsonSerializer.Deserialize<List<RBAccount>>(json) ?? new List<RBAccount>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading accounts: {ex.Message}");
                }
            }

            if (accounts.Count == 0)
            {
                CreateDefaultAccounts();
                SaveAccounts();
            }
        }

        private void SaveAccounts()
        {
            try
            {
                string json = JsonSerializer.Serialize(accounts, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(accountsFilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving accounts: {ex.Message}");
            }
        }

        private void CreateDefaultAccounts()
        {
            accounts = new List<RBAccount>
            {
                new RBAccount("Brit", "1201"),
                new RBAccount("Taniah", "1234")
            };
        }
    }
}
