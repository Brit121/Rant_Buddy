using RantBuddyCommon;
using System.Collections.Generic;

namespace RantBuddyDataService
{
    public class RBDataService
    {
        List<RBAccount> accounts = new List<RBAccount>();

        public RBDataService()
        {
            CreateDummyAccounts();
        }

        private void CreateDummyAccounts()
        {
            accounts.Add(new RBAccount("brit", "1111"));
            accounts.Add(new RBAccount("taniah", "5555"));
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