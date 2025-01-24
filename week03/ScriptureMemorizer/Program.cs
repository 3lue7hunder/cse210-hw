using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a library of scriptures
        List<(Reference, string)> scriptureLibrary = new List<(Reference, string)>
        {
            (new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            (new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart and lean not unto thine own understanding."),
            (new Reference("Psalm", 23, 1), "The Lord is my shepherd; I shall not want.")
        };

        // Select a random scripture
        var random = new Random();
        var selectedScripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];
        Scripture scripture = new Scripture(selectedScripture.Item1, selectedScripture.Item2);

        Console.WriteLine("Welcome to the Scripture Memorizer!");
        Console.WriteLine("Press Enter to hide words, type 'hint' to reveal a word, or type 'quit' to exit.\n");

        while (true)
        {
            // Display the current state of the scripture and progress
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine($"Progress: {scripture.GetProgress():F1}% hidden");
            Console.Write("\n> ");

            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            if (userInput.ToLower() == "hint")
            {
                scripture.RevealWord();
                Console.Clear();
                continue;
            }

            // Hide words and check if the scripture is completely hidden
            scripture.HideRandomWords(3);
            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("Congratulations! You have memorized the scripture.");
                break;
            }

            Console.Clear();
        }
    }
}
