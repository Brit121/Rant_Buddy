using RantBuddyCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace RantBuddyDataService
{
    public class RBDataService
    {
        List<RBAccount> accounts = new List<RBAccount> ();
        // stores the accounts of the users.

        public RBDataService()
        {
            CreateDummyAccounts();
        }
        private void CreateDummyAccounts()
        {
            // creates dummy accounts for testing purposes.(instantiate)
            RBAccount account1 = new RBAccount("Brit", "1201");
            RBAccount account2 = new RBAccount("Taniah", "1234");
        }

        public bool ValidateAccount(string UserName, string Pin)
        // checks if the account exists in the accounts list and if the pin is correct.
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
