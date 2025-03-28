using System.Collections.Generic;
using System;

namespace rantBuddy

{
    internal class Program
    {
        static List<string> rantEntries = new List<string>();
        static string[] actions = new string[] { "[1] Add an Entry", "[2] View Entries", "[3] Delete an Entry", "[4] Exit" };
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to your Rant Buddy!");
            //passcode, add entry, view entries, delete entries, exit

            int passcode = 1201;
            int password;


            while (true)
            {
                Console.Write("\nPlease enter your passcode: \n");
                string input = Console.ReadLine();

                if (int.TryParse(input, out password) && password == passcode)
                {
                    Console.WriteLine("\n------------- Logged In Successfully! Welcome! --------------");
                    break;
                }
                Console.WriteLine("\n------------- Incorrect Passcode! Use four numbers only.--------------");
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
                            AddEntry();
                            break;
                        case 2:
                            ViewEntries();
                            break;
                        case 3:
                            DeleteEntry();
                            break;
                        case 4:
                            Console.WriteLine("\n------------ Exiting... Byebye! ------------");
                            break;
                    }
                }
            }

            while (userOption != 4);

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
                if (int.TryParse(input, out option) && option >= 1 && option <= 4)
                {
                    return option;
                }
                Console.Write("\n------------ Invalid choice of Option! Please choose correctly! -------------");
                Console.Write("\n------------------------------------------------------------------------------");
            }
        }
        static void AddEntry()
        {
            Console.WriteLine("\nAdd an entry: \n");
            string entry = Console.ReadLine();
            rantEntries.Add(entry);
            Console.WriteLine("\n------------------- Entry Added Successfully! ------------------");
            return;
        }

        static void ViewEntries()
        {
            if (rantEntries.Count == 0)
            {
                Console.WriteLine("\n------------------- No Entries found! ------------------");
                return;
            }
            Console.WriteLine("\nEntries: ");
            for (int i = 0; i < rantEntries.Count; i++)
            {
                Console.WriteLine($"\n{i + 1}. {rantEntries[i]}");
                Console.WriteLine("\n--------------------------------------------");
            }
        }
        static void DeleteEntry()
        {
            if (rantEntries.Count == 0)
            {
                Console.WriteLine("\n--------------- No Entries to delete. --------------");
                Console.WriteLine("\n-----------------------------------------------------");

            }
            Console.WriteLine("\nEntries: ");
            for (int i = 0; i < rantEntries.Count; i++)
            {
                Console.WriteLine($"\n{i + 1}. {rantEntries[i]}");
                Console.WriteLine("\n------------------------------------------------");
            }
            Console.WriteLine("\nPlease enter the number of the entry you want to delete:  ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= rantEntries.Count)
            {
                rantEntries.RemoveAt(index - 1);
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
