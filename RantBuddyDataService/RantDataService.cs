using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RantBuddyDataService
{
    public interface RantDataService
    {
        List<Rant> LoadRants();
        void SaveRants();
        void AddEntry(Rant rant); 
        void DeleteEntry(int index);
        void UpdateEntry(int index, Rant rant);
        List<Rant> SearchEntry(string keyWord); 
        bool ValidateAccount(string username, string password);
    }
}
