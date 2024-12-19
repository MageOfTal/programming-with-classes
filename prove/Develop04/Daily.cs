
public class Daily : Task
{
    //attributes (member variables)

    private int _dailyStreak;

    Player _currentPlayer = Player.GetCurrentPlayer();


    //behaviors (member functions or *methods*)
    public int GetDailyStreak()
    {
        return _dailyStreak;
    }
    public void SetDailyStreak(int dailyStreak)
    {
        _dailyStreak = dailyStreak;
    }

    public override Task createTask()
    {
        Daily newTask = new();

        Console.WriteLine("Name your task");
        newTask.SetTaskName(Console.ReadLine());

        Console.WriteLine("How many points for completing your task?\nSuggestions: Easy - 5, Medium - 15, Hard - 35, Very hard - 100");
        //make sure the user knows how to type in a number
        try
        {
            newTask.SetCompleteReward(int.Parse(Console.ReadLine()));
            return newTask;
        }
        catch
        {
            Menu.changeSystemMessage("Invalid input while creating task.");
        }

        throw new InvalidOperationException("Task creation failed due to invalid input.");

        
    }


    public override void completeTask()
    {
        if (GetComplete() == false)
        {
            _currentPlayer.gainScore(GetCompleteReward());
            SetComplete(true);
            _dailyStreak += 1;
        }
        else
        {
            Menu.changeSystemMessage($"Daily task {GetTaskName()} already complete");
        }
    }
    

}