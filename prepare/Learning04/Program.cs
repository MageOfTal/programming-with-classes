using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment a = new("Charles Uffley", "Deep Magic");
        Console.WriteLine(a.GetSummary());

        WritingAssignment w = new("Sarah Carly", "English", "why capitalization isn't important");
        Console.WriteLine(w.GetSummary());
        Console.WriteLine(w.GetWritingInformation());
        
        MathAssignment m = new("Ashley Wacklewoggle", "Calculus", "Section 13.2", "Problems 1-100");

        Console.WriteLine(m.GetSummary());
        Console.WriteLine(m.GetHomeworkList());





    }
}