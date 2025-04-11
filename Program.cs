using System.Collections.Generic;
using System;
using RantBuddyBusinessDataLogic;

namespace rantBuddy


{
    internal class Program
    {
        static string[] actions = new string[] { "[1] Create or Add an Entry", "[2] Retrieve or View Entries", "[3] Update an Entry", "[4] Delete an Entry", "[5] Search", "[6] Exit" };
        // actions to be displayed
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to your Rant Buddy!");
            //passcode, create and add entry, retrieve or view entries, update entry, delete entries,search keyword, exit

            int password;


            while (true)
            {
                Console.Write("\nPlease enter your 4-digit pin: \n");
                string input = Console.ReadLine();

                if (int.TryParse(input, out password) && password == RantBuddyService.pin)
                // checks if the input is a valid integer and matches the pin
                {
                    Console.WriteLine("\n------------- Logged In Successfully! Welcome! --------------");
                    break;
                }
                else
                {
                    Console.WriteLine("\n------------- Incorrect Pin! Please use four numbers only.--------------");
                }
            }

            int userOption;

            do
            {
                DisplayActions();

                userOption = GetUserOption();

                {
                    switch (userOption)
                    {
                        case 1:
                            CreateOrAddEntry();
                            break;
                        case 2:
                            RetrieveOrViewEntries();
                            break;
                        case 3:
                            UpdateEntry();
                            break;
                        case 4:
                            DeleteEntry();
                            break;
                        case 5:
                            SearchKeyword();
                            break;
                        case 6:
                            Console.WriteLine("\n------------ Sayonara!!!!!!!!! ------------");
                            break;
                    }
                }
            }

            while (userOption != 6);

        }
        static void DisplayActions()
        // displays the actions
        {
            Console.WriteLine("\nPlease choose an option: ");
            foreach (string action in actions)
            {
                Console.WriteLine(action);
            }
        }
        static int GetUserOption()
        // gets the user option
        {
            int option;
            while (true)
            {
                Console.Write("\n[User Option]:  \n");
                string input = Console.ReadLine();
                if (int.TryParse(input, out option) && option >= 1 && option <= 6)
                {
                    return option;
                }
                Console.Write("\n------ Invalid choice of Option! Please choose a number from 1 to 6 only! -------");
                Console.Write("\n------------------------------------------------------------------------------");
            }
        }
        static void CreateOrAddEntry()
        // creates or adds an entry
        {
            if (RantBuddyService.rantEntries.Count == 0)
            {
                Console.WriteLine("\nPlease create your first entry: \n");
            }
            else
            {
                Console.WriteLine("\nAdd a new entry: \n");
            }

            string entry = Console.ReadLine();
            if (!string.IsNullOrEmpty(entry))
            {
                RantBuddyService.rantEntries.Add(entry);
                Console.WriteLine("\n------- Entry Added Successfully! ---------");
            }
            else
            {
                Console.Write("\nNo Entry Provided. Please Enter an Entry.\n");
            }
        }
        static void RetrieveOrViewEntries()
        // retrieves or views the entries
        {
            bool result = RantBuddyService.HasEntries();
            {
                if (result == false)
                {
                    Console.WriteLine("\n----------------- No Entries to Display. -----------------");
                }
                else
                {
                    Console.WriteLine("\n----------------- Entries: ");
                    for (int i = 0; i < RantBuddyService.rantEntries.Count; i++)
                    {
                        Console.WriteLine($"\n{i + 1}. {RantBuddyService.rantEntries[i]}");
                        Console.WriteLine("\n------------------------------------------------");
                    }
                }
            }
        }
        static void UpdateEntry()
        // updates an entry
        {
            if (RantBuddyService.rantEntries.Count == 0)
            {
                Console.WriteLine("\n--------------- No Entries to update. --------------");
                Console.WriteLine("\n-----------------------------------------------------");

            }
            Console.WriteLine("\nEntries: ");
            for (int i = 0; i < RantBuddyService.rantEntries.Count; i++)
            {
                Console.WriteLine($"\n{i + 1}. {RantBuddyService.rantEntries[i]}");
                Console.WriteLine("\n------------------------------------------------");
            }
            Console.WriteLine("\nPlease enter the index number of the entry you want to update:  ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= RantBuddyService.rantEntries.Count)
            {
                Console.WriteLine("\nPlease enter the new entry: ");
                string newEntry = Console.ReadLine();
                if (!string.IsNullOrEmpty(newEntry))
                {
                    RantBuddyService.rantEntries[index - 1] = newEntry;
                    Console.WriteLine("\n--------------- Entry updated successfully! --------------------");
                    Console.WriteLine("\n------------------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("\n--------- Invalid Entry! Please Try Again. ----------");
                    Console.WriteLine("\n--------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("\n--------- Invalid choice of index number! Please Try Again. ----------");
                Console.WriteLine("\n--------------------------------------------------");
            }
        }
        static void SearchKeyword()
        // searches for a keyword in the entries
        {
            if (RantBuddyService.rantEntries.Count == 0)
            {
                Console.WriteLine("\n--------------- No Entries in the List. --------------");
                Console.WriteLine("\n-----------------------------------------------------");
                return;

            }

            Console.WriteLine(" Please Enter a Keyword to search for: ");
            string keyword = Console.ReadLine();
            var foundEntries = RantBuddyService.rantEntries.FindAll(entry => entry.Contains(keyword, StringComparison.OrdinalIgnoreCase));

            if (foundEntries.Count > 0)
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine("\nFound Entries: \n");
                foreach (var entry in foundEntries)
                {
                    Console.WriteLine(entry);
                    Console.WriteLine("--------------------------");

                }
            }
            else
            {
                Console.WriteLine("\n-----------------------------------------------------");
                Console.WriteLine("No Entries found matching the Keyword you're searching for.");
                Console.WriteLine("\n-----------------------------------------------------");
            }
        }
        static void DeleteEntry()
        // deletes an entry
        {
            if (RantBuddyService.rantEntries.Count == 0)
            {
                Console.WriteLine("\n--------------- No Entries to delete. --------------");
                Console.WriteLine("\n-----------------------------------------------------");
                return;
            }
            Console.WriteLine("\nEntries: ");
            for (int i = 0; i < RantBuddyService.rantEntries.Count; i++)
            {
                Console.WriteLine($"\n{i + 1}. {RantBuddyService.rantEntries[i]}");
                Console.WriteLine("\n------------------------------------------------");
            }
            Console.WriteLine("\nPlease enter the index number of the entry you want to delete:  ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= RantBuddyService.rantEntries.Count)
            {
                RantBuddyService.rantEntries.RemoveAt(index - 1);
                Console.WriteLine("\n--------------- Entry deleted successfully! --------------------");
                Console.WriteLine("\n------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("\n--------- Invalid choice of index number! Please Try Again. ----------");
                Console.WriteLine("\n----------------------------------------------------------");
            }
        }
    }
}
