using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace RantBuddyDataService
{
    public class JSONFileDataService : RantDataService
    {
        static string jsonFilePath = "accounts.json";
        static List<Rant> rants = new List<Rant>();

        public void AddEntry(Rant rant)
        {
            rants.Add(rant);
            SaveRants();
        }

        public void DeleteEntry(int index)
        {
            if (index >= 0 && index < rants.Count)
            {
                rants.RemoveAt(index);
                SaveRants();
            }
            else
            {
                throw new IndexOutOfRangeException("Invalid rant index.");
            }
        }

        public List<Rant> LoadRants()
        {
            if (File.Exists(jsonFilePath))
            {
                try
                {
                    string jsonString = File.ReadAllText(jsonFilePath);
                    rants = JsonSerializer.Deserialize<List<Rant>>(jsonString) ?? new List<Rant>();
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                  
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Error reading JSON file: {ex.Message}");
                }
            }
            return rants;
        }

        public void SaveRants()
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(rants, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(jsonFilePath, jsonString);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error serializing JSON: {ex.Message}");
                  }
            catch (IOException ex)
            {
                Console.WriteLine($"Error writing JSON file: {ex.Message}");
                 }
        }

        public List<Rant> SearchEntry(string keyWord) =>
            rants.Where(entry => entry.Rants.ToLower().Contains(keyWord.ToLower())).ToList();

        public void UpdateEntry(int index, Rant rant)
        {
            if (index >= 0 && index < rants.Count)
            {
                rants[index] = rant;
                SaveRants();
            }
            else
            {
                throw new IndexOutOfRangeException("Invalid rant index.");
            }
        }

        public bool ValidateAccount(string username, string password)
        {
            return false; 
        }
    }
}