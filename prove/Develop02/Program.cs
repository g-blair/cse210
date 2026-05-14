using System;
namespace Develop02;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        bool running = true;

        while (running)
        {
            Console.WriteLine("\nJournal Menu");
            Console.WriteLine("1. Add Entry");
            Console.WriteLine("2. Display Entries");
            Console.WriteLine("3. Save Journal");
            Console.WriteLine("4. Load Journal");
            Console.WriteLine("5. Quit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine() ?? "";

            if (choice == "1")
            {
                journal.AddEntry();
            }
            else if (choice == "2")
            {
                Console.WriteLine(journal.DisplayEntries());
            }
            else if (choice == "3")
            {
                Console.WriteLine(journal.Save());
            }
            else if (choice == "4")
            {
                Console.WriteLine(journal.Load());
            }
            else if (choice == "5")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }
    }
}