using System.Collections.Generic;
using RantBuddyCommon;

namespace RantBuddyDataService
{
    public interface IRantDataService
    {
        bool ValidateAccount(string username, string pin);
        void AddEntry(Rant rant);
        List<Rant> LoadRants();
        void DeleteEntry(int index);
        void UpdateEntry(int index, Rant newRant);
        List<Rant> SearchEntry(string keyword);
        void SaveRants(List<Rant> rants);
    }
}
