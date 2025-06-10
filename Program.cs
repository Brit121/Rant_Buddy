using System;
using System.Collections.Generic;
using System.Linq;
using RantBuddyCommon;
using RantBuddyDataService;

namespace RantBuddy
{
    internal class Program
    {
        static RantService rant = new RantService();
        static string currentUsername = "";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to Rant Buddy!");

            // Login loop
            while (true)
            {
                Console.WriteLine("\nPlease enter your Username: ");
                string username = Console.ReadLine();
                if (string.IsNullOrEmpty(username))
                {
                    Console.WriteLine("Invalid Username. Please try again.");
                    continue;
                }

                Console.WriteLine("Please enter your 4-digits pin: ");
                string pin = Console.ReadLine();
                if (string.IsNullOrEmpty(pin))
                {
                    Console.WriteLine("Invalid Pin. Please try again.");
                    continue;
                }

                if (rant.ValidateAccount(username, pin))
                {
                    currentUsername = username;
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect account details. Please try again.");
                }
            }

            Console.WriteLine($"\n----------------- Welcome, {currentUsername}! Logged in successfully! -----------------");

            int choice;
            do
            {
                DisplayMenu();

                choice = GetUserChoice();

                switch (choice)
                {
                    case 1: CreateOrAddEntry(); break;
                    case 2: RetrieveOrViewEntries(); break;
                    case 3: UpdateEntry(); break;
                    case 4: DeleteEntry(); break;
                    case 5: SearchEntries(); break;
                    case 6: Console.WriteLine("Sayonara!"); break;
                }

            } while (choice != 6);
        }

        static void DisplayMenu()
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("[1] Create or Add an Entry");
            Console.WriteLine("[2] Retrieve or View Entries");
            Console.WriteLine("[3] Update an Entry");
            Console.WriteLine("[4] Delete an Entry");
            Console.WriteLine("[5] Search Entries");
            Console.WriteLine("[6] Exit");
        }

        static int GetUserChoice()
        {
            while (true)
            {
                Console.WriteLine("Enter your choice (1-6): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 6)
                {
                    return choice;
                }
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
            }
        }

        static void CreateOrAddEntry()
        {
            var userRants = rant.GetRants()
                .Where(r => r.Username.Equals(currentUsername, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (userRants.Count == 0)
                Console.WriteLine("\nThis is your first entry! Please type your first rant:");
            else
                Console.WriteLine("\nAdd a new entry:");

            string entry = Console.ReadLine();

            if (!string.IsNullOrEmpty(entry))
            {
                rant.AddRant(new Rant { Username = currentUsername, Content = entry });
                Console.WriteLine("Entry added successfully!");
            }
            else
            {
                Console.WriteLine("No entry provided. Please try again.");
            }
        }

        static void RetrieveOrViewEntries()
        {
            var userRants = rant.GetRants()
                .Where(r => r.Username.Equals(currentUsername, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (userRants.Count == 0)
            {
                Console.WriteLine("\nNo entries to display. Why not create one?");
                return;
            }

            Console.WriteLine("\nYour Entries:");
            for (int i = 0; i < userRants.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {userRants[i].Content}");
            }
        }

        static void UpdateEntry()
        {
            var userRants = rant.GetRants()
                .Where(r => r.Username.Equals(currentUsername, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (userRants.Count == 0)
            {
                Console.WriteLine("\nNo entries to update. Please add one first.");
                return;
            }

            Console.WriteLine("\nYour Entries:");
            for (int i = 0; i < userRants.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {userRants[i].Content}");
            }

            Console.Write("Enter the number of the entry you want to update: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= userRants.Count)
            {
                Console.Write("Enter the new content: ");
                string newContent = Console.ReadLine();

                if (!string.IsNullOrEmpty(newContent))
                {
                    rant.UpdateRant(index - 1, new Rant { Username = currentUsername, Content = newContent });
                    Console.WriteLine("Entry updated successfully!");
                }
                else
                {
                    Console.WriteLine("New content cannot be empty.");
                }
            }
            else
            {
                Console.WriteLine("Invalid entry number.");
            }
        }

        static void DeleteEntry()
        {
            var userRants = rant.GetRants()
                .Where(r => r.Username.Equals(currentUsername, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (userRants.Count == 0)
            {
                Console.WriteLine("\nNo entries to delete.");
                return;
            }

            Console.WriteLine("\nYour Entries:");
            for (int i = 0; i < userRants.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {userRants[i].Content}");
            }

            Console.Write("Enter the number of the entry you want to delete: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= userRants.Count)
            {
                rant.DeleteRant(index - 1);
                Console.WriteLine("Entry deleted successfully!");
            }
            else
            {
                Console.WriteLine("Invalid entry number.");
            }
        }

        static void SearchEntries()
        {
            var userRants = rant.GetRants()
                .Where(r => r.Username.Equals(currentUsername, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (userRants.Count == 0)
            {
                Console.WriteLine("\nNo entries to search.");
                return;
            }

            Console.Write("Enter keyword to search: ");
            string keyword = Console.ReadLine();

            var results = userRants
                .Where(r => r.Content.IndexOf(keyword ?? "", StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            if (results.Count == 0)
            {
                Console.WriteLine("No entries matched your search.");
            }
            else
            {
                Console.WriteLine("\nSearch results:");
                foreach (var rant in results)
                {
                    Console.WriteLine($"- {rant.Content}");
                }
            }
        }
    }
}