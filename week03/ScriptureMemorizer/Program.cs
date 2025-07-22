using System;
using System.IO;
using System.Collections.Generic;

/*
 * EXCEEDS REQUIREMENTS:
 * - Loads multiple scriptures from a text file ("Scriptures.txt")
 * - Randomly selects a different scripture each time the program runs
 * - Avoids hiding words that are already hidden (stretch challenge)
 */

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = LoadRandomScripture("Scriptures.txt");

        while (true)
        {
            scripture.Display();

            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit:");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
                break;

            scripture.HideRandomWords();

            if (scripture.AllWordsHidden())
            {
                scripture.Display();
                Console.WriteLine("\nAll words are hidden. Press Enter to exit.");
                Console.ReadLine();
                break;
            }
        }
    }

    static Scripture LoadRandomScripture(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        var random = new Random();
        string line = lines[random.Next(lines.Length)];

        string[] parts = line.Split('|');
        Reference reference = Reference.Parse(parts[0]);
        string text = parts[1];

        return new Scripture(reference, text);
    }
}
