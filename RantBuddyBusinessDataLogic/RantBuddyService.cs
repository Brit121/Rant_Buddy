namespace RantBuddyBusinessDataLogic
{
    public class RantBuddyService
    {
        public static List<string> rantEntries = new List<string>();
        // stores the rant entries.
        public static int pin = 1201;
        public static List<String> GetEntries()
        // returns the list of rant entries.
        {
            return rantEntries;
        }

        public static bool HasEntries()
        // checks if there are any entries in the rantEntries list.
        {
            return rantEntries.Count > 0;
        }
        public static void AddEntry(string entry)
        // adds a new entry to the rantEntries list.
        {
            rantEntries.Add(entry);
        }
        public static bool DeleteEntry(int index)
        // deletes an entry from the rantEntries list based on the index specified.
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