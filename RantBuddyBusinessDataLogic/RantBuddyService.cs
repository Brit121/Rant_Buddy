using RantBuddyDataService;

namespace RantBuddyService
{
    public class RantBuddyService
    {
        public List<string> rantEntries = new List<string>();
        // stores the rant entries.
        public List<String> GetEntries()
        // returns the list of rant entries.
        {
            return rantEntries;
        }
        public bool HasEntries()
        // checks if there are any entries in the rantEntries list.
        {
            return rantEntries.Count > 0;
        }
        public void AddEntry(string entry)
        // adds a new entry to the rantEntries list.
        {
            rantEntries.Add(entry);
        }
        public bool DeleteEntry(int index)
        // deletes an entry from the rantEntries list based on the index specified.
        {
            if (index >= 0 && index < rantEntries.Count)
            {
                rantEntries.RemoveAt(index);
                return true;
            }
            return false;
        }
        public bool UpdateEntry(int index, string newEntry)
        // updates an entry in the rantEntries list based on the index specified.
        {
            if (index >= 0 && index < rantEntries.Count)
            {
                rantEntries[index] = newEntry;
                return true;
            }
            return false;
        }
        public bool SearchEntry(string keyWord)
        {
            keyWord = keyWord.ToLower();
            foreach (string entry in rantEntries)
            {
                if (entry.ToLower().Contains(keyWord))
                {
                    return true;
                }
            }
            return false;
        }
        public bool ValidateAccount(string UserName, string Pin)
        // checks if the account exists in the accounts list and if the pin is correct.
        {
            RBDataService rbDataService = new RBDataService();
           return rbDataService.ValidateAccount(UserName, Pin);
        }
    }
}