using System;
using System.Collections.Generic;
using RantBuddyCommon;

namespace RantBuddyDataService
{
    public class InMemoryDataService : IRantDataService
    {
        private List<Rant> _rants = new List<Rant>(); 
        public void AddEntry(Rant rant)
        {
            _rants.Add(rant);
        }

        public void DeleteEntry(int index)
        {
            if (index >= 0 && index < _rants.Count)
            {
                _rants.RemoveAt(index);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index out of range.");
            }
        }

        public List<Rant> LoadRants()
        {
            return new List<Rant>(_rants); 
        }

        public void SaveRants(List<Rant> rants)
        {
            _rants = new List<Rant>(rants); 
        }

        public List<Rant> SearchEntry(string keyword)
        {
            return _rants.Where(r => r.Content.ToLowerInvariant().Contains(keyword.ToLowerInvariant())).ToList();
        }

        public void UpdateEntry(int index, Rant newRant)
        {
            if (index >= 0 && index < _rants.Count)
            {
                _rants[index] = newRant;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index out of range.");
            }
        }

        public bool ValidateAccount(string username, string pin)
        {
            if (username == "brit" && pin == "1201")  return true;
            if (username == "raniah" && pin == "1234") return true;
            return false;
        }
    }
}