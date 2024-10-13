using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {   
        //initialize journal and userCommand
        Journal userJournal = new();
        string userCommand;
        do
        {
            Console.WriteLine("Welcome to Journal! Commands: Journal, Display, Save, Load, Quit");
            userCommand = Console.ReadLine();
            if (userCommand == "Journal")
            {
                userJournal.makeEntry();
            }
            if (userCommand == "Display")
            {
                userJournal.displayJournal();
            }
            if (userCommand == "Save")
            {
                userJournal.saveJournal();
            }
            if (userCommand == "Load")
            {
                userJournal.loadJournal();
            }
        }
        while (userCommand != "Quit");
        
    }
}