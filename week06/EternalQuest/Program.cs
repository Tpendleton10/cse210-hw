using System;

namespace EternalQuest
{
    class Program
    {
        static GoalManager manager = new();

        static void Main(string[] args)
        {
            bool running = true;
            Console.WriteLine("Welcome to Eternal Quest!");

            while (running)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1) Create New Goal");
                Console.WriteLine("2) List Goals");
                Console.WriteLine("3) Record Event");
                Console.WriteLine("4) Show Score & Badges");
                Console.WriteLine("5) Save Goals");
                Console.WriteLine("6) Load Goals");
                Console.WriteLine("7) Quit");
                Console.Write("Choose: ");
                switch (Console.ReadLine()?.Trim())
                {
                    case "1": CreateGoalMenu(); break;
                    case "2": manager.DisplayGoals(); break;
                    case "3": RecordEventMenu(); break;
                    case "4": manager.DisplayScoreAndBadges(); break;
                    case "5": SaveMenu(); break;
                    case "6": LoadMenu(); break;
                    case "7": running = false; break;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }

        static void CreateGoalMenu()
        {
            Console.WriteLine("1) Simple Goal\n2) Eternal Goal\n3) Checklist Goal");
            string choice = Console.ReadLine();
            Console.Write("Name: "); string name = Console.ReadLine();
            Console.Write("Description: "); string desc = Console.ReadLine();
            int points = ReadInt("Points per event: ");

            switch (choice)
            {
                case "1": manager.AddGoal(new SimpleGoal(name, desc, points)); break;
                case "2": manager.AddGoal(new EternalGoal(name, desc, points)); break;
                case "3":
                    int target = ReadInt("Target count: ");
                    int bonus = ReadInt("Bonus points: ");
                    manager.AddGoal(new ChecklistGoal(name, desc, points, target, bonus));
                    break;
            }
        }

        static void RecordEventMenu()
        {
            manager.DisplayGoals();
            int idx = ReadInt("Goal number: ") - 1;
            int pts = manager.RecordEvent(idx);
            if (pts > 0) Console.WriteLine($"Earned {pts} points!");
        }

        static void SaveMenu()
        {
            Console.Write("Filename: ");
            manager.SaveToFile(Console.ReadLine());
        }

        static void LoadMenu()
        {
            Console.Write("Filename: ");
            manager.LoadFromFile(Console.ReadLine());
        }

        static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int value)) return value;
                Console.WriteLine("Invalid number.");
            }
        }
    }
}
