using System.Collections.Generic;
using RantBuddyCommon;
using RantBuddyDataService;

namespace RantBuddy
{
    public class RantService
    {
        private IRantDataService dataService;

        public JSONFileDataService JSONFileDataService { get; }

        public RantService()
        {
           // dataService = new JSONFileDataService(); //for JSON
           // dataService = new TextFileDataService(); //for TextFile
            dataService = new InMemoryDataService(); //for InMemory
        }

        public RantService(JSONFileDataService jSONFileDataService)
        {
            JSONFileDataService = jSONFileDataService;
            dataService = jSONFileDataService; 
        }

        public bool ValidateAccount(string username, string pin)
        {
            return dataService.ValidateAccount(username, pin);
        }

        public void AddRant(Rant rant)
        {
            dataService.AddEntry(rant);
        }

        public List<Rant> GetRants()
        {
            return dataService.LoadRants();
        }

        public void UpdateRant(int index, Rant newRant)
        {
            dataService.UpdateEntry(index, newRant);
        }

        public void DeleteRant(int index)
        {
            dataService.DeleteEntry(index);
        }

        public List<Rant> SearchRants(string keyword)
        {
            return dataService.SearchEntry(keyword);
        }
    }
}
