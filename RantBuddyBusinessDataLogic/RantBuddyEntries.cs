using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RantBuddyBusinessDataLogic
{
    public class RantBuddyEntries
    {
        public static List<string> rantEntries = new List<string>();
        public static List<String> GetEntries()
        {
            return rantEntries;
        }
        public static bool HasEntries()
        {
            return rantEntries.Count > 0;
        }
        public static void AddEntry(string entry)
        {
            rantEntries.Add(entry);
        }
        public static bool DeleteEntry(int index)
        {
            if (index >= 0 && index < rantEntries.Count)
            {
                rantEntries.RemoveAt(index);
                return true;
            }
            return false;
        }
    }
}