using System.Linq;
using System.Transactions;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
public class Listing : Activity
{

    //attributes (member variables)
    private static string[] _listingQuestions = 
    [
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
        "What are you grateful for today?",
        "What are your goals for the next week?"
    ];  

    //behaviors (member functions or *methods*)

    public Listing()
    {
        SetPrompt("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        SetUniqueBehavior(ListingActivity);
    }

    public void ListingActivity(int time)
    {
        Console.WriteLine("List as many responses as you can to this prompt:");

        Random rand = new();
        int randomQuestion = rand.Next(0,_listingQuestions.Length);

        Console.WriteLine (_listingQuestions[randomQuestion]);

        Console.Write("You may begin in:");
        SecondCountdown(8000);

        DateTime endTime = DateTime.Now.AddSeconds(time);

        int entries = 0;

        Console.Write('\n');

        while (DateTime.Now < endTime)
        {
            Console.Write (">");
            Console.ReadLine();
            entries++;
        }

        Console.WriteLine ($"You listed {entries} entries!");
        Thread.Sleep(3000);
    }
   

}