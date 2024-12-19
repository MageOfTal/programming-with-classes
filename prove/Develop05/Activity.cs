using System.Linq;
using System.Transactions;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Globalization;
public class Activity
{

    //attributes (member variables)

    private int _completions = 0;

    private Action<int> _uniqueBehavior;

    private string _prompt = "This is a default activity.";

    private int _duration;
   

    //behaviors (member functions or *methods*)
    public void InitialPrompt()
    {
        Console.Clear();
        Console.WriteLine($"Let us start our {this.GetType().Name.ToLower()} mindfulness exercise!\n{_prompt}\nHow many seconds would you like this activity to last?");
        _duration = int.Parse(Console.ReadLine());
        Waiting("Great, let's start! Get ready...",3000);
        _uniqueBehavior?.Invoke(_duration);
        ExitActivity();
    }

    public void ExitActivity()
    {
        _completions ++;
        Waiting($"Great work {Menu.GetMenu().GetUser()}! You're a natural at {this.GetType().Name.ToLower()} exercises.",2000);
        Waiting($"You did this {this.GetType().Name.ToLower()} exercise for a whole {_duration} seconds!",2000);
        Console.Clear();
        Menu.GetMenu().DisplayUserData();
    }

    public void Waiting(string custom, int time)
    {
        Console.Clear();
        Console.WriteLine(custom);
        LoadingCircle(time);
    }

    public void LoadingCircle(int time)
    {
        string[] loadingFrames = { "-", "\\", "|", "/" };

        for (int i = 0; i >= 0; i++)
        {
            Console.Write(loadingFrames[i%loadingFrames.Length]);

            if (time > 200)
            {
                Thread.Sleep(200);
                time -= 200;
            }
            else
            {
                Thread.Sleep(time);
                Console.Write("\b");
                return;
            }
            Console.Write("\b");
        }
    }

    public void SecondCountdown(int time)
    {
        int numberLength;
        int currentNumber = time/1000;
        for (int i = 0; i < time;)
        {
            numberLength = currentNumber.ToString().Length;
            Console.Write (currentNumber);
            Thread.Sleep(1000);
            time -= 1000;
            currentNumber = time/1000;
            if (numberLength != currentNumber.ToString().Length)
            {
                Console.Write("\b \b\b");
            }
            else 
            {
                Console.Write("\b");
            }
        }
    }

    public int GetDuration()
    {
        return _duration;
    }

    public void SetDuration(int duration)
    {
        _duration = duration;
    }

    public void SetPrompt (string prompt)
    {
        _prompt = prompt;
    }

    public string GetPrompt ()
    {
        return _prompt;
    }

    public void SetUniqueBehavior(Action<int> uniqueBehavior)
    {
        _uniqueBehavior = uniqueBehavior;
    }

    public int GetCompletions()
    {
        return _completions;
    }
}