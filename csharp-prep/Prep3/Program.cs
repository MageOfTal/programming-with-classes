using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is the magic number?");
        int magicNumber = int.Parse(Console.ReadLine());
        int guess;
        do
        {
            Console.WriteLine("What is your guess?");
            guess = int.Parse(Console.ReadLine());
                if (guess> magicNumber)
                {
                    Console.WriteLine("Go lower!");
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Go higher!");
                }
                else
                {
                    Console.WriteLine("You got it right!");
                }
            
        } while (guess != magicNumber);
    }
}