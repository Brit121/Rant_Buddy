using System.Collections.Generic;
using RantBuddyCommon;

namespace RantBuddyDataService
{
    public interface IRantDataService
    {
        List<Rant> LoadRants();
        void SaveRants();
        bool HasEntries();
        void AddEntry(Rant rant);
        void UpdateEntry(int index, Rant rant);
        void DeleteEntry(int index);
        List<Rant> SearchEntry(string keyword);
        bool ValidateAccount(string username, string pin);
    }
}