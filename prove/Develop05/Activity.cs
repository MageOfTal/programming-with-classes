using System.Linq;
using System.Transactions;
public class Activity
{
    private int _duration;

    private string _prompt;

    private string _type;

    private Menu _currentMenu = Menu.getMenu();

    //attributes (member variables)

   

    //behaviors (member functions or *methods*)
    public void initialPrompt()
    {
        Console.WriteLine($@"Hello {_currentMenu._userName}! Let us start our mindfulness exercise.\n
        {_prompt}\n
        How many seconds would you like this activity to last?");
        _duration = int.Parse(Console.ReadLine());
    }

    public void exitActivity()
    {
        Console.WriteLine($"Great work {_currentMenu._userName}! You're a natural at {_type} exercises.");
        Console.WriteLine($"You did this {_type} exercise for a whole {_duration} seconds!");
        _currentMenu.displayUserData();
    }
   

}