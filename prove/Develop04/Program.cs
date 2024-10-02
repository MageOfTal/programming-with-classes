using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new();
        int number;
        do
        {
            Console.WriteLine("Enter number:");
            number = int.Parse(Console.ReadLine());
            if (number != 0)
            {
                numbers.Add(number);
            }
        
        } while (number !=0 );

        numbers.Sort();
        Console.WriteLine($"The sum is {numbers.Sum()}.");
        Console.WriteLine($"The average is {numbers.Average()}.");
        Console.WriteLine($"The largest number is {numbers.Max()}.");
        Console.WriteLine($"The smallest positive number is {numbers.Where(n => n > 0).Min()}.");
        

        foreach (int i in numbers)
        {
            Console.WriteLine(i);
        }
    }
}