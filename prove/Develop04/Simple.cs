
public class Simple : Task
{
    //attributes (member variables)


    Player currentPlayer = Player.GetCurrentPlayer();


    //behaviors (member functions or *methods*)

    public override Task createTask()
    {
        Simple newTask = new();

        Console.WriteLine("Name your task");
        newTask.taskName = Console.ReadLine();

        Console.WriteLine("How many points for completing your task?\nSuggestions: Easy - 5, Medium - 15, Hard - 35, Very hard - 100");
        //make sure the user knows how to type in a number
        try
        {
            newTask.completeReward = int.Parse(Console.ReadLine());
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
        currentPlayer.gainScore(completeReward);
        complete = true;
        //remove self from list
        currentPlayer.GetPlayerTasks().Remove(this);
    }

}