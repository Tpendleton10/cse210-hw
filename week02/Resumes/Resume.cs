using System;
using System.Collections.Generic;

public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();  // Properly using List<Job>

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Experience:");
        foreach (Job job in _jobs)
        {
            job.Display(); // Reuse Job's Display method
        }
    }
}
