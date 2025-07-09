using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string input = Console.ReadLine();
        int grade;

        if (int.TryParse(input, out grade))
        {
            if (grade >= 90)
            {
                Console.WriteLine("You got an A!");
                Console.WriteLine("Congratulations on passing the class!");
            }
            else if (grade >= 80)
            {
                if (grade >= 87)
                {
                    Console.WriteLine("You got a B+");
                }
                else
                {
                    Console.WriteLine("You got a B");
                }
                Console.WriteLine("Congratulations on passing the class!");
            }
            else if (grade >= 70)
            {
                Console.WriteLine("You got a C");
                Console.WriteLine("Congratulations on passing the class!");
            }
            else if (grade >= 60)
            {
                Console.WriteLine("You got a D");
                Console.WriteLine("You did not pass the class, but don't give up!");
            }
            else
            {
                Console.WriteLine("You got an F");
                Console.WriteLine("You did not pass the class, but don't give up!");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a numeric grade.");
        }
    }
}
