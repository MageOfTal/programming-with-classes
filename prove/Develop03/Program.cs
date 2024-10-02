using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 100);
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