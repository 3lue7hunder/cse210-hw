using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a reference and scripture
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string scriptureText = "Trust in the Lord with all thine heart and lean not unto thine own understanding.";
        Scripture scripture = new Scripture(reference, scriptureText);

        Console.WriteLine("Welcome to the Scripture Memorizer!");
        Console.WriteLine("Press Enter to hide more words or type 'quit' to exit.\n");

        while (true)
        {
            // Display the current state of the scripture
            Console.WriteLine(scripture.GetDisplayText());
            Console.Write("\n> ");

            string userInput = Console.ReadLine();

            // Check for quit condition
            if (userInput.ToLower() == "quit")
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            // Hide words and check if the scripture is completely hidden
            scripture.HideRandomWords(3);
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("Congratulations! You have memorized the scripture.");
                break;
            }

            Console.Clear();
        }
    }
}
