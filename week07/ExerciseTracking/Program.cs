using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0), // 3 miles in 30 min
            new Cycling(new DateTime(2022, 11, 3), 45, 15.0), // 15 mph for 45 min
            new Swimming(new DateTime(2022, 11, 3), 40, 30)   // 30 laps
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
