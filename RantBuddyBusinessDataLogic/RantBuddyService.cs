using RantBuddyDataService;
using System.Collections.Generic;

namespace RantBuddyService
{
    public class RantBuddyService
    {
        public List<string> rantEntries = new List<string>();
        private RBDataService rbDataService = new RBDataService();

        public List<string> GetEntries() => rantEntries;

        public bool HasEntries() => rantEntries.Count > 0;

        public void AddEntry(string entry)
        {
            rantEntries.Add(entry);
        }

        public bool DeleteEntry(int index)
        {
            if (index >= 0 && index < rantEntries.Count)
            {
                rantEntries.RemoveAt(index);
                return true;
            }
            return false;
        }

        public bool UpdateEntry(int index, string newEntry)
        {
            if (index >= 0 && index < rantEntries.Count)
            {
                rantEntries[index] = newEntry;
                return true;
            }
            return false;
        }

        public bool SearchEntry(string keyword)
        {
            keyword = keyword.ToLower();
            foreach (var entry in rantEntries)
            {
                if (entry.ToLower().Contains(keyword))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ValidateAccount(string userName, string pin)
        {
            return rbDataService.ValidateAccount(userName, pin);
        }
    }
}
