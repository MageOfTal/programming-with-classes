
public class Task
{
    //attributes (member variables)

    public bool complete;

    public Checklist ParentChecklist;

    public string taskName;

    public int completeReward;

    Player currentPlayer = Player.currentPlayer;


    //behaviors (member functions or *methods*)

    public virtual void completeTask()
    {
        if (complete == false)
        {
            currentPlayer.gainScore(completeReward);
            complete = true;
        }
    }

    public virtual Task createTask()
    {
        Task newTask = new();

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
    

}