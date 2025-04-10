using System.Collections.Generic;
using System;
using RantBuddyBusinessDataLogic;

namespace rantBuddy


{
    internal class Program
    {
        static string[] actions = new string[] { "[1] Create or Add an Entry", "[2] Retrieve or View Entries", "[3] Update an Entry", "[4] Delete an Entry", "[5] Exit" };
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to your Rant Buddy!");
            //passcode, add entry, view entries, delete entries, exit

            int pin = 1201;
            int password;


            while (true)
            {
                Console.Write("\nPlease enter your 4-digit pin: \n");
                string input = Console.ReadLine();

                if (int.TryParse(input, out password) && password == pin)
                {
                    Console.WriteLine("\n------------- Logged In Successfully! Welcome! --------------");
                    break;
                }
                Console.WriteLine("\n------------- Incorrect Pin! Please use four numbers only.--------------");
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
                            Console.WriteLine("\n------------ Sayonara!!!!!!!!! ------------");
                            break;
                    }
                }
            }

            while (userOption != 5);

        }


        static void DisplayActions()
        {
            Console.WriteLine("\nPlease choose an option: ");
            foreach (string action in actions)
            {
                Console.WriteLine(action);
            }
        }
        static int GetUserOption()
        {
            int option;
            while (true)
            {
                Console.Write("\n[User Option]:  \n");
                string input = Console.ReadLine();
                if (int.TryParse(input, out option) && option >= 1 && option <= 5)
                {
                    return option;
                }
                Console.Write("\n------------ Invalid choice of Option! Please choose from 1 to 4 only! -------------");
                Console.Write("\n------------------------------------------------------------------------------");
            }
        }
        static void CreateOrAddEntry()
        {
            Console.WriteLine("\nAdd an entry: \n");
            string entry = Console.ReadLine();
            if (!string.IsNullOrEmpty(entry))
            {
                RantBuddyEntries.rantEntries.Add(entry);
                Console.WriteLine("\n------------------- Entry Added Successfully! ------------------");
            }
            else
            {
                Console.Write("\nNo Entry Provided. Please Enter an Entry.\n");
            }
        }
        static void RetrieveOrViewEntries()
        {
            bool result = RantBuddyEntries.HasEntries();
            {
                if (result == false)
                {
                    Console.WriteLine("\n----------------- No Entries to Display. -----------------");
                }
                else
                {
                    Console.WriteLine("\n----------------- Entries: -----------------");
                    for (int i = 0; i < RantBuddyEntries.rantEntries.Count; i++)
                    {
                        Console.WriteLine($"\n{i + 1}. {RantBuddyEntries.rantEntries[i]}");
                        Console.WriteLine("\n------------------------------------------------");
                    }
                }
            }
        }
        static void UpdateEntry()
        {
            if (RantBuddyEntries.rantEntries.Count == 0)
            {
                Console.WriteLine("\n--------------- No Entries to update. --------------");
                Console.WriteLine("\n-----------------------------------------------------");

            }
            Console.WriteLine("\nEntries: ");
            for (int i = 0; i < RantBuddyEntries.rantEntries.Count; i++)
            {
                Console.WriteLine($"\n{i + 1}. {RantBuddyEntries.rantEntries[i]}");
                Console.WriteLine("\n------------------------------------------------");
            }
            Console.WriteLine("\nPlease enter the number of the entry you want to update:  ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= RantBuddyEntries.rantEntries.Count)
            {
                Console.WriteLine("\nPlease enter the new entry: ");
                string newEntry = Console.ReadLine();
                if (!string.IsNullOrEmpty(newEntry))
                {
                    RantBuddyEntries.rantEntries[index - 1] = newEntry;
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
                Console.WriteLine("\n--------- Invalid choice of number! Please Try Again. ----------");
                Console.WriteLine("\n--------------------------------------------------");
            }
        }
        static void DeleteEntry()
        {
            if (RantBuddyEntries.rantEntries.Count == 0)
            {
                Console.WriteLine("\n--------------- No Entries to delete. --------------");
                Console.WriteLine("\n-----------------------------------------------------");

            }
            Console.WriteLine("\nEntries: ");
            for (int i = 0; i < RantBuddyEntries.rantEntries.Count; i++)
            {
                Console.WriteLine($"\n{i + 1}. {RantBuddyEntries.rantEntries[i]}");
                Console.WriteLine("\n------------------------------------------------");
            }
            Console.WriteLine("\nPlease enter the number of the entry you want to delete:  ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= RantBuddyEntries.rantEntries.Count)
            {
                RantBuddyEntries.rantEntries.RemoveAt(index - 1);
                Console.WriteLine("\n--------------- Entry deleted successfully! --------------------");
                Console.WriteLine("\n------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("\n--------- Invalid choice of number! Please Try Again. ----------");
                Console.WriteLine("\n--------------------------------------------------");
            }
        }
    }
}
