using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            throw new ArgumentException("Scripture text cannot be null or empty.");

        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords(int numberToHide)
    {
        var visibleWords = _words.Where(word => !word.IsHidden).ToList();

        for (int i = 0; i < numberToHide && visibleWords.Count > 0; i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public void RevealWord()
    {
        var hiddenWords = _words.Where(word => word.IsHidden).ToList();

        if (hiddenWords.Count > 0)
        {
            int index = _random.Next(hiddenWords.Count);
            hiddenWords[index].Show();
        }
    }

    public string GetDisplayText()
    {
        string scriptureText = string.Join(" ", _words.Select(word => word.GetDisplayText()));
        return $"{_reference.GetDisplayText()} - {scriptureText}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden);
    }

    public double GetProgress()
    {
        int totalWords = _words.Count;
        int hiddenWords = _words.Count(word => word.IsHidden);
        return (double)hiddenWords / totalWords * 100;
    }
}
