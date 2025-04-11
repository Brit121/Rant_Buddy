namespace RantBuddyBusinessDataLogic
{
    public class RantBuddyService
    {
        public List<string> rantEntries = new List<string>();
        // stores the rant entries.
        public List<String> GetEntries()
        {
            return rantEntries;
        }
         List<RBAccount> accounts = new List<RBAccount>();
        // stores the accounts of the users.
        private void CreateDummyAccounts()
        {
            // creates dummy accounts for testing purposes.(instantiate)
            RBAccount account1 = new RBAccount();
            account1.UserName = "Brit";
            account1.Pin = "1201";
            accounts.Add(account1);

            RBAccount account2 = new RBAccount();
            account2.UserName = "Taniah";
            account2.Pin = "1234";
            accounts.Add(account2);
        }
        public RantBuddyService()
        {
            CreateDummyAccounts();
            // creates dummy accounts when the service is instantiated.
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
        {
            foreach (var account in accounts)
            {
                if (account.UserName == UserName && account.Pin == Pin)
                {
                    return true;
                }
            }
            return false;
        }
    }
}