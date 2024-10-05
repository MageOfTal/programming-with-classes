using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {   
        //initialize journal and userCommand
        Journal userJournal = new();
        string userCommand = "";
        do
        {
            Console.WriteLine("Welcome to Journal! Commands: Journal, Save, Load, Quit");
            string userCommand = Console.ReadLine();
            if (userCommand == "Journal")
            {
                userJournal.makeEntry();
            }
        }
        while (userCommand != "Quit");
        
    }
}