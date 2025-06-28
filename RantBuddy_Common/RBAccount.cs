using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace RantBuddyCommon
{
    public class RBAccount
    {
        public string UserName { get; set; }
        public string Pin { get; set; }
        public RBAccount(string userName, string pin)
        {
            UserName = userName;
            Pin = pin;
        }
        public RBAccount() { }

    }
}