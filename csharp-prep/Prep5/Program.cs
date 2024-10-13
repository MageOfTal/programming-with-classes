using System;
using System.Globalization;
class Program
{
    static void Main(string[] args)
    {
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program!");
        }
        static string PromptUserName()
        {
            Console.WriteLine("What is your name?");
            string userName = Console.ReadLine();
            return userName;
        }
        static int PromptUserNumber()
        {
            Console.WriteLine("What is your favorite number?");
            int number = int.Parse(Console.ReadLine());
            return number;
        }
        static int SquareNumber(int number)
        {
            number = number*number;
            return number;
        }
        static void DisplayResult(string userName, int number)
        {
            Console.WriteLine($"{userName}, your number squared is {number}.");
        }
        DisplayWelcome();
        string userName = PromptUserName();
        int number = PromptUserNumber();
        number = SquareNumber(number);
        DisplayResult(userName, number);
        
        
    }
}