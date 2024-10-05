using System;

public class Resume
{

    public List<Job> _jobRecord = new();
    public string _name;
    public void DisplayResume()
    {
        Console.WriteLine("Name:");
        Console.WriteLine (_name);
        Console.WriteLine ("Job history:");
        foreach(Job pastJob in _jobRecord)
        {
            pastJob.DisplayJobInformation();
        }
    }
}