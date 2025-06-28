using System;
using System.Collections.Generic;
using System.Linq;
using RantBuddyCommon;

namespace RantBuddyDataService
{
    public class InMemoryDataService : IRantDataService
    {
        private readonly List<Rant> rants = new List<Rant>();
        private readonly Dictionary<string, string> accounts = new()
        {
            { "brit", "1111" }, { "taniah", "5555" }
        };

        public List<Rant> LoadRants()
        {
            return rants;
        }

        public void SaveRants()
        {
        }
        public bool HasEntries()
        {
            return rants.Any();
        }

        public void AddEntry(Rant r)
        {
            rants.Add(r);
        }
        public void UpdateEntry(int i, Rant r)
        {
            if (i >= 0 && i < rants.Count) rants[i] = r;
        }
        public void DeleteEntry(int i)
        {
            if (i >= 0 && i < rants.Count) rants.RemoveAt(i);
        }
        public List<Rant> SearchEntry(string k)
        {
            return rants.Where(x => x.Content.Contains(k, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public bool ValidateAccount(string u, string p)
        {
            return accounts.ContainsKey(u) && accounts[u] == p;
        }
    }
}