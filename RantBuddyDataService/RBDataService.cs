using RantBuddyCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

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
            RBAccount account1 = new RBAccount();
            account1.UserName = "Brit";
            account1.Pin = "1201";
            accounts.Add(account1);

            RBAccount account2 = new RBAccount();
            account2.UserName = "Taniah";
            account2.Pin = "1234";
            accounts.Add(account2);
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
