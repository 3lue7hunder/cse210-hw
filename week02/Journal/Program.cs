using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        string choice = "";

        while (choice != "7")
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Delete an entry");
            Console.WriteLine("6. Search entries");
            Console.WriteLine("7. Export to CSV");
            Console.WriteLine("8. Import from CSV");
            Console.WriteLine("9. Display analytics");
            Console.WriteLine("10. Exit");
            Console.Write("Enter your choice: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Random random = new Random();
                    string prompt = prompts[random.Next(prompts.Count)];
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    string date = DateTime.Now.ToShortDateString();
                    journal.AddEntry(new Entry(prompt, response, date));
                    Console.WriteLine("Entry added.");
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to save to: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    Console.WriteLine("Journal saved.");
                    break;

                case "4":
                    Console.Write("Enter filename to load from: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    Console.WriteLine("Journal loaded.");
                    break;

                case "5":
                    journal.DisplayAll();
                    Console.Write("Enter the entry number to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int index) && journal.DeleteEntry(index - 1))
                    {
                        Console.WriteLine("Entry deleted.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid entry number.");
                    }
                    break;

                case "6":
                    Console.Write("Enter a keyword to search for: ");
                    string keyword = Console.ReadLine();
                    List<Entry> results = journal.SearchEntries(keyword);
                    Console.WriteLine($"\nFound {results.Count} result(s):");
                    foreach (Entry entry in results)
                    {
                        Console.WriteLine(entry);
                    }
                    break;

                case "7":
                    Console.Write("Enter filename to export to CSV: ");
                    string exportFile = Console.ReadLine();
                    journal.ExportToCsv(exportFile);
                    Console.WriteLine("Journal exported to CSV.");
                    break;

                case "8":
                    Console.Write("Enter filename to import from CSV: ");
                    string importFile = Console.ReadLine();
                    journal.ImportFromCsv(importFile);
                    Console.WriteLine("Journal imported from CSV.");
                    break;

                case "9":
                    journal.DisplayAnalytics();
                    break;

                case "10":
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}

/* 
Additional Features Added to Exceed Core Requirements:

1. Search Feature:
   - Allows users to search journal entries by keywords.

2. Export to CSV:
   - Enables exporting all journal entries to a CSV file for easy sharing or analysis.

3. Import from CSV:
   - Allows importing journal entries from a CSV file.

4. Analytics:
   - Provides insights, including the total number of entries, most used prompt, and most common words in responses.

These features enhance usability and provide extra value beyond the core requirements.
*/
