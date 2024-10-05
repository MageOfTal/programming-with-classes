using System;

public class Program
{
    static void Main(string[] args)
    {
        Job job1 = new();
        Job job2 = new();
        job1._jobTitle = "Software Engineer";
        job2._jobTitle = "Manager";
        job1._company = "Microsoft";
        job2._company = "Apple";
        job1._startYear = 2019;
        job2._startYear = 2022;
        job1._endYear = 2022;
        job2._endYear = 2023;

        Resume john = new();
        john._jobRecord = [job1,job2];
        john._name = "John Job";

        john.DisplayResume();

    }
}