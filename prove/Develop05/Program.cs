using System;

class Program
{
    static void Main(string[] args)
    {
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program!");
        } 
        static void PromptUserName() - Asks for and returns the user's name (as a string)
        {
            Console.WriteLine("Welcome to the Program!");
            userName = Console.ReadLine("Welcome to the Program!");
            return (userName);
        }
        static void PromptUserNumber() - Asks for and returns the user's favorite number (as an integer)
        static void SquareNumber(int numInputSquare) - Accepts an integer as a parameter and returns that number squared (as an integer)
        static void DisplayResult(string name, int numSquared) - Accepts the user's name and the squared number and displays them.
    }
}