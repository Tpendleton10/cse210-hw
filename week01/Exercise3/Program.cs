using System;

class Program
{
    static void Main()
    {
        string playAgain;

        do
        {
            // Generate random number
            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1, 11); // Between 1 and 10
            int guess = 0;
            int guessCount = 0;

            Console.WriteLine("I'm thinking of a number between 1 and 10.");

            while (guess != number)
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine().Trim();

                if (!int.TryParse(input, out guess) || guess < 1 || guess > 10)
                {
                    Console.WriteLine("Please enter a valid number between 1 and 10.");
                    continue;
                }

                guessCount++;

                if (guess > number)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess < number)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("🎉 Congratulations, you guessed the number!");
                    Console.WriteLine($"It took you {guessCount} guess(es).");
                }
            }

            // Ask if they want to play again
            Console.Write("Do you want to play again? (yes or no): ");
            playAgain = Console.ReadLine().Trim().ToLower();

        } while (playAgain == "yes");

        Console.WriteLine("Thanks for playing!");
    }
}
