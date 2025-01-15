using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public bool DeleteEntry(int index)
    {
        if (index >= 0 && index < _entries.Count)
        {
            _entries.RemoveAt(index);
            return true;
        }
        return false;
    }

    public List<Entry> SearchEntries(string keyword)
    {
        return _entries
            .Where(e => e.Prompt.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        e.Response.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }

        for (int i = 0; i < _entries.Count; i++)
        {
            Console.WriteLine($"Entry #{i + 1}:\n{_entries[i]}");
        }
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.ToCsv());
            }
        }
    }

    public void LoadFromFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            _entries.Clear();
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                _entries.Add(Entry.FromCsv(line));
            }
        }
        else
        {
            Console.WriteLine($"File {fileName} not found.");
        }
    }

    public void ExportToCsv(string fileName)
    {
        SaveToFile(fileName);
    }

    public void ImportFromCsv(string fileName)
    {
        LoadFromFile(fileName);
    }

    public void DisplayAnalytics()
    {
        Console.WriteLine($"Total Entries: {_entries.Count}");

        var mostUsedPrompt = _entries
            .GroupBy(e => e.Prompt)
            .OrderByDescending(g => g.Count())
            .FirstOrDefault()?.Key;

        Console.WriteLine($"Most Used Prompt: {mostUsedPrompt ?? "N/A"}");

        var mostCommonWords = _entries
            .SelectMany(e => e.Response.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            .GroupBy(word => word.ToLower())
            .OrderByDescending(g => g.Count())
            .Take(5);

        Console.WriteLine("Most Common Words in Responses:");
        foreach (var word in mostCommonWords)
        {
            Console.WriteLine($"{word.Key} ({word.Count()})");
        }
    }
}
