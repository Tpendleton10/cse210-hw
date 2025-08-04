using System;
using System.Threading;

public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
        : base("Breathing Activity", "This activity will help you relax by guiding you through slow breathing.") { }

    public void Run()
    {
        DisplayStartingMessage();
        int elapsed = 0;

        while (elapsed < _duration)
        {
            Console.WriteLine("\nBreathe in...");
            Countdown(4);
            Console.WriteLine("Breathe out...");
            Countdown(4);
            elapsed += 8;
        }

        DisplayEndingMessage();
    }
}
