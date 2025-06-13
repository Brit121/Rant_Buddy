using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using RantBuddyCommon;

namespace RantBuddyDataService
{
    public class JSONFileDataService : IRantDataService
    {
        private readonly string path = "rants.json";
        private readonly List<Rant> rants = new();
        private readonly Dictionary<string, string> accounts = new()
        {
            { "brit", "1201" }, { "taniah", "1234" }
        };

        public JSONFileDataService() 
        { 
            LoadRants(); 
        }

        public List<Rant> LoadRants()
        {
            if (File.Exists(path))
            {
                try
                {
                    var j = File.ReadAllText(path);
                    var arr = JsonSerializer.Deserialize<List<Rant>>(j);
                    if (arr != null) { rants.Clear(); rants.AddRange(arr); }
                }
                catch { }
            }
            return rants;
        }

        private void SaveRants()
        {
            var j = JsonSerializer.Serialize(rants, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, j);
        }

        public void AddEntry(Rant r) 
        { 
            rants.Add(r); SaveRants(); 
        }
        public void UpdateEntry(int i, Rant r) 
        { 
            if (i >= 0 && i < rants.Count) { rants[i] = r; SaveRants(); } 
        }
        public void DeleteEntry(int i) 
        { 
            if (i >= 0 && i < rants.Count) { rants.RemoveAt(i); SaveRants(); } 
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
