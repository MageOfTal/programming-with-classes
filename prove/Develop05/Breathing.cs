using System.Linq;
using System.Transactions;
using System.Threading;
using System.Diagnostics.CodeAnalysis;
public class Breathing : Activity
{

    //attributes (member variables)

    private static string[] _breathingSteps = ["Breathe in...", "Breathe out..."];

    //behaviors (member functions or *methods*)

    public Breathing()
    {
        SetPrompt("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
        SetUniqueBehavior(BreathingActivity);
    }

    public void BreathingActivity(int time)
    {
        DateTime endTime = DateTime.Now.AddSeconds(time);
        int step = 0;
        while (DateTime.Now < endTime)
        {
            Console.WriteLine(_breathingSteps[step%2]);
            SecondCountdown(5000);
            step ++;
        }
    }
   

}