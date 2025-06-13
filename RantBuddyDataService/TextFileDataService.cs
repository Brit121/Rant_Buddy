using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using RantBuddyCommon;

namespace RantBuddyDataService
{
    public class TextFileDataService : IRantDataService
    {
        private readonly string path = "userInputs.txt";
        private readonly List<Rant> rants = new();
        private readonly Dictionary<string, string> accounts = new()
        {
            { "brit", "1201" }, { "taniah", "1234" }
        };

        public TextFileDataService() { LoadRants(); }

        public List<Rant> LoadRants()
        {
            rants.Clear();
            if (!File.Exists(path)) return rants;

            foreach (var line in File.ReadAllLines(path))
            {
                var parts = line.Split('|');
                if (parts.Length == 2)
                    rants.Add(new Rant { Username = parts[0], Content = parts[1] });
            }
            return rants;
        }

        private void SaveRants()
        {
            File.WriteAllLines(path, rants.Select(x => $"{x.Username}|{x.Content}"));
        }

        public void AddEntry(Rant r) 
        {
            rants.Add(r); SaveRants(); 
        }
        public void UpdateEntry(int i, Rant r) 
        { if (i >= 0 && i < rants.Count) { rants[i] = r; SaveRants(); } 
        }
        public void DeleteEntry(int i) 
        { if (i >= 0 && i < rants.Count) { rants.RemoveAt(i); SaveRants(); } 
        }
        public List<Rant> SearchEntry(string k)
        {
            return rants.Where(x => x.Content.Contains(k, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public bool HasEntries()
        {
            return rants.Any();
        }

        public bool ValidateAccount(string u, string p)
        {
            return accounts.ContainsKey(u) && accounts[u] == p;
        }

        void IRantDataService.SaveRants()
        {
            SaveRants();
        }
    }
}
