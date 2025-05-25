using RantBuddyCommon; 
using System;
using System.Collections.Generic;
using System.Linq;

namespace RantBuddyDataService
{
    public class InMemoryDataService : RantDataService
    {
        private List<Rant> rantEntries = new List<Rant>();
        private Dictionary<string, string> accounts = new Dictionary<string, string>();

        public InMemoryDataService()
        {
            // Initialize with some accounts
            accounts.Add("Brit", "1201");
            accounts.Add("Taniah", "1234");
        }

        public List<Rant> LoadRants() => rantEntries;
        public void SaveRants() { }
        public bool HasEntries() => rantEntries.Any();

        public void AddEntry(Rant entry) => rantEntries.Add(entry);

        public void DeleteEntry(int index)
        {
            if (index < 0 || index >= rantEntries.Count)
            {
                throw new IndexOutOfRangeException("Invalid rant index.");
            }
            rantEntries.RemoveAt(index);
        }

        public void UpdateEntry(int index, Rant newEntry)
        {
            if (index < 0 || index >= rantEntries.Count)
            {
                throw new IndexOutOfRangeException("Invalid rant index.");
            }
            rantEntries[index] = newEntry;
        }

        public List<Rant> SearchEntry(string keyWord) =>
            rantEntries.Where(entry => entry.Rants.ToLower().Contains(keyWord.ToLower())).ToList();


        public bool ValidateAccount(string userName, string pin) =>
            accounts.ContainsKey(userName) && accounts[userName] == pin;
    }
}