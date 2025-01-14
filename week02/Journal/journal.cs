using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private static readonly Random _random = new Random();

    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public void AddEntry()
    {
        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        string date = DateTime.Now.ToShortDateString();
        _entries.Add(new Entry(date, prompt, response));
        Console.WriteLine("Entry added successfully!\n");
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.\n");
            return;
        }

        for (int i = 0; i < _entries.Count; i++)
        {
            Console.WriteLine($"Entry #{i + 1}");
            _entries[i].Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
        Console.WriteLine("Journal saved successfully!\n");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.\n");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                _entries.Add(new Entry(parts[0], parts[1], parts[2]));
            }
        }
        Console.WriteLine("Journal loaded successfully!\n");
    }

    public void DeleteEntry()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty. There is nothing to delete.\n");
            return;
        }

        DisplayAll();
        Console.Write("Enter the entry number to delete: ");
        if (int.TryParse(Console.ReadLine(), out int entryNumber) && entryNumber > 0 && entryNumber <= _entries.Count)
        {
            _entries.RemoveAt(entryNumber - 1);
            Console.WriteLine("Entry deleted successfully!\n");
        }
        else
        {
            Console.WriteLine("Invalid entry number. No changes made.\n");
        }
    }
}
