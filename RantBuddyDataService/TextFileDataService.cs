using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using RantBuddyCommon;

namespace RantBuddyDataService
{
    public class TextFileDataService : IRantDataService
    {
        private readonly string filePath = "userInputs.txt";

        private List<RBAccount> accounts = new List<RBAccount>
        {
            new RBAccount("brit", "1201"),
            new RBAccount("taniah", "1234")
        };

        public bool ValidateAccount(string username, string pin)
        {
            return accounts.Any(acc =>
                string.Equals(acc.UserName, username, StringComparison.OrdinalIgnoreCase)
                && acc.Pin == pin);
        }

        public void AddEntry(Rant rant)
        {
            string entry = $"Username: {rant.Username}\nContent: {rant.Content}\n---";
            File.AppendAllText(filePath, entry + Environment.NewLine);
        }

        public List<Rant> LoadRants()
        {
            var rants = new List<Rant>();
            if (!File.Exists(filePath)) return rants;

            var lines = File.ReadAllLines(filePath);
            string username = null;
            string content = null;

            foreach (var line in lines)
            {
                if (line.StartsWith("Username: "))
                {
                    username = line.Substring(10).Trim();
                }
                else if (line.StartsWith("Content: "))
                {
                    content = line.Substring(9).Trim();
                }
                else if (line.Trim() == "---" && username != null && content != null)
                {
                    rants.Add(new Rant { Username = username, Content = content });
                    username = null;
                    content = null;
                }
            }

            return rants;
        }

        public void DeleteEntry(int index)
        {
            var rants = LoadRants();
            if (index < 0 || index >= rants.Count) return;

            rants.RemoveAt(index);
            SaveAll(rants);
        }

        public void UpdateEntry(int index, Rant newRant)
        {
            var rants = LoadRants();
            if (index < 0 || index >= rants.Count) return;

            rants[index] = newRant;
            SaveAll(rants);
        }

        public List<Rant> SearchEntry(string keyword)
        {
            return LoadRants()
                .Where(r => r.Content.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        private void SaveAll(List<Rant> rants)
        {
            var entries = rants.Select(r => $"Username: {r.Username}\nContent: {r.Content}\n---");
            File.WriteAllLines(filePath, entries);
        }

        public void SaveRants(List<Rant> rants)
        {
            SaveAll(rants);
        }
    }
}
