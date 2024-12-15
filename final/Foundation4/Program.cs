using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new();

        Cycling cycling = new("03 Nov 2024", 30, 16.7);
        Running running = new("04 Nov 2024", 45, 1);
        //very fast swimmer
        Swimming swimming = new("05 Nov 2024", 5, 100);

        activities.Add(cycling);
        activities.Add(running);
        activities.Add(swimming);

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}