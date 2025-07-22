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
        _reference = reference;
        _words = text.Split(' ')
                     .Select(word => new Word(word))
                     .ToList();
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(_reference.ToString());
        Console.WriteLine(string.Join(" ", _words.Select(w => w.GetDisplayText())));
    }

    public void HideRandomWords(int count = 3)
    {
        var visibleWords = _words.Where(w => w.IsVisible()).ToList();
        for (int i = 0; i < count && visibleWords.Any(); i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index); // only hide visible ones
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(w => !w.IsVisible());
    }
}
