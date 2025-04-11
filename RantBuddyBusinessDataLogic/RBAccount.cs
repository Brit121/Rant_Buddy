using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RantBuddyBusinessDataLogic
{
    public class RBAccount
    {
        // stores the account information of the user.
        private string _pin = "1201";
        public string Pin
        {
            get { return _pin; }
            set
            {
                if (value.Length == 4 || value.Length == 6)
                {
                    _pin = value;
                }
            }
        }
        public string UserName { get; set; }

    }
}