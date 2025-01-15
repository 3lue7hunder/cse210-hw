using System;

public class Entry
{
    private string _prompt;
    private string _response;
    private string _date;

    public Entry(string prompt, string response, string date)
    {
        _prompt = prompt;
        _response = response;
        _date = date;
    }

    public string Prompt => _prompt;
    public string Response => _response;
    public string Date => _date;

    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }

    public string ToCsv()
    {
        return $"{Date}|{Prompt}|{Response}";
    }

    public static Entry FromCsv(string csvLine)
    {
        string[] parts = csvLine.Split('|');
        return new Entry(parts[1], parts[2], parts[0]);
    }
}
