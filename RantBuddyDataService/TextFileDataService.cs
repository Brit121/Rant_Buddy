
namespace RantBuddyDataService
{
    public class TextFileDataService : RantDataService
    {
        const string accountsFilePath = "accounts.txt";
        const string rantsFilePath = "rants.txt";
        Dictionary<string, string> accounts = new Dictionary<string, string>();
        List<Rant> rantEntries = new List<Rant>();

        public TextFileDataService()
        {
            LoadAccounts();
            LoadRants();
        }

        private void LoadAccounts()
        {
            if (File.Exists(accountsFilePath))
            {
                try
                {
                    accounts = File.ReadAllLines(accountsFilePath)
                        .Select(line => line.Split('|'))
                        .Where(parts => parts.Length == 2)
                        .ToDictionary(parts => parts[0].Trim(), parts => parts[1].Trim());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading accounts: {ex.Message}");
                }
            }
        }

        public List<Rant> LoadRants() => rantEntries;

        public void SaveRants()
        {
            try
            {
                File.WriteAllLines(rantsFilePath, rantEntries.Select(rant => rant.Rants));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving rants: {ex.Message}");
            }
        }

        public void AddEntry(Rant entry)
        {
            rantEntries.Add(entry);
            SaveRants();
        }

        public void DeleteEntry(int index)
        {
            if (index >= 0 && index < rantEntries.Count)
            {
                rantEntries.RemoveAt(index);
                SaveRants();
            }
            else
            {
                throw new IndexOutOfRangeException("Invalid rant index.");
            }
        }

        public void UpdateEntry(int index, Rant newEntry)
        {
            if (index >= 0 && index < rantEntries.Count)
            {
                rantEntries[index] = newEntry;
                SaveRants();
            }
            else         
            {
                throw new IndexOutOfRangeException("Invalid rant index.");
            }
        }

        public List<Rant> SearchEntry(string keyword) =>
            rantEntries.Where(entry => entry.Rants.ToLower().Contains(keyword.ToLower())).ToList();

        public bool ValidateAccount(string userName, string pin) =>
            accounts.ContainsKey(userName) && accounts[userName] == pin;

    }
}