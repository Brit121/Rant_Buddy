﻿using System.Collections.Generic;
using RantBuddy_DataService;
using RantBuddyCommon;

namespace RantBuddyDataService
{
    public class RantBuddy_Service
    {
        private readonly IRantDataService dataService;
        public RantBuddy_Service()
        {
            //dataService = new JSONFileDataService(); //for JSON
            //dataService = new TextFileDataService(); //for TextFile
            // dataService = new InMemoryDataService(); //for InMemory
            dataService = new DBRantDataService(); //for database 
        }

        public bool ValidateAccount(string u, string p)
        {
            return dataService.ValidateAccount(u, p);
        }

        public void AddRant(Rant r)
        {
            dataService.AddEntry(r);
        }

        public List<Rant> GetRants()
        {
            return dataService.LoadRants();
        }

        public void UpdateRant(int i, Rant r)
        {
            dataService.UpdateEntry(i, r);
        }

        public void DeleteRant(int i)
        {
            dataService.DeleteEntry(i);
        }

        public List<Rant> SearchRants(string k)
        {
            return dataService.SearchEntry(k);
        }
    }
}