public class Reference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int StartVerse { get; private set; }
    public int? EndVerse { get; private set; }

    // Constructor for single verse
    public Reference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = verse;
        EndVerse = null;
    }

    // Constructor for verse range
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        return EndVerse == null
            ? $"{Book} {Chapter}:{StartVerse}"
            : $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
    }

    // Parses string like "Proverbs 3:5-6" or "John 3:16"
    public static Reference Parse(string input)
    {
        var parts = input.Split(' ');
        var book = parts[0];
        var chapterVerse = parts[1].Split(':');
        int chapter = int.Parse(chapterVerse[0]);

        string[] verses = chapterVerse[1].Split('-');
        if (verses.Length == 1)
        {
            return new Reference(book, chapter, int.Parse(verses[0]));
        }
        else
        {
            return new Reference(book, chapter, int.Parse(verses[0]), int.Parse(verses[1]));
        }
    }
}
