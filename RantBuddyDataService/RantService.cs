using RantBuddyCommon;

namespace RantBuddyDataService
{
    public class RantService
    {
        private RantDataService RantDataService; 

        public RantService()
        {
            RantDataService = new InMemoryDataService();
           // RantDataService = new TextFileDataService();
           // RantDataService = new JSONFileDataService(); 
        }

        public void AddRant(Rant rant) => RantDataService.AddEntry(rant);

        public List<Rant> GetRants() => RantDataService.LoadRants();

        public void DeleteRant(int index) => RantDataService.DeleteEntry(index);

        public void UpdateRant(int index, Rant newRant) => RantDataService.UpdateEntry(index, newRant);

        public List<Rant> SearchRants(string keyword) => RantDataService.SearchEntry(keyword);

        public bool ValidateAccount(string username, string password) => RantDataService.ValidateAccount(username, password);

    }
}
