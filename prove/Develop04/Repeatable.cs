
public class Repeatable : Task
{
    //attributes (member variables)


    private Player currentPlayer = Player.GetCurrentPlayer();

    private int _completions;


    //behaviors (member functions or *methods*)
    public override Task createTask()
    {
        Repeatable newTask = new();

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
        currentPlayer.gainScore(GetCompleteReward());
        _completions++;
    }

}