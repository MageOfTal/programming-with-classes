using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Menu MainMenu = Menu.GetMenu();
        MainMenu.SetupUser();
        MainMenu.DisplayUserData();

        Listing l = new();
        Breathing b = new();
        Reflection r= new();
        while (true)
        {
            string input = Console.ReadLine();
            if (input.ToLower() == "breathing")
            {
                b.InitialPrompt();
            }
            else if (input.ToLower() == "reflection")
            {
                r.InitialPrompt();
            }
            else if (input.ToLower() == "listing")
            {
                l.InitialPrompt();
            }
            else if (input.ToLower() == "completions")
            {
                Console.WriteLine ($"Breathing completions: {b.GetCompletions()}");
                Console.WriteLine ($"Reflection completions: {r.GetCompletions()}");
                Console.WriteLine ($"Listing completions: {l.GetCompletions()}");
                Console.WriteLine ("Enter to exit.");
            }
            else
            {
                MainMenu.ChangeSystemMessage("Did not recognize input.");
                MainMenu.DisplayUserData();
            }

        }
    }
}