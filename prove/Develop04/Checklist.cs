
public class Checklist : Task
{
    //attributes (member variables)

    private List<Task> listedTasks = new();

    public int itemsDone {get; private set;}

    Player currentPlayer = Player.GetCurrentPlayer();


    //behaviors (member functions or *methods*)

    public List<Task> GetListedTasks()
    {
        return listedTasks;
    }

    public override void completeTask()
    {
        currentPlayer.gainScore(completeReward);
        complete = true;
        //remove self from list
        currentPlayer.GetPlayerTasks().Remove(this);
    }

    public virtual Task createSubTask(int i)
    {
        Subtask newTask = new();

        Console.WriteLine($"Name subtask {i+1}");
        newTask.taskName = Console.ReadLine();

        Console.WriteLine("How many points for completing this subtask?\nSuggestions: Easy - 5, Medium - 15, Hard - 35, Very hard - 100");
        //make sure the user knows how to type in a number
        try
        {
            newTask.completeReward = int.Parse(Console.ReadLine());
            return newTask;
        }
        catch
        {
            Menu.changeSystemMessage("Invalid input while creating task.");
            throw new ArgumentException("Invalid argument");
        }
        throw new InvalidOperationException("Task creation failed due to invalid input.");

    }
    public override Task createTask()
    {
        itemsDone = 0;
        
        try
        {

            Console.WriteLine("Name your task");
            taskName = Console.ReadLine();
            Console.WriteLine("How many sub-tasks? Limit 20.");
            
            int listLength = int.Parse(Console.ReadLine());

            if (listLength > 20 || listLength < 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            
            
            for (int i = 0; i< listLength; i++)
            {
                var subTask = createSubTask(i);
                subTask.ParentChecklist = this; // Set the parent reference
                this.listedTasks.Add(subTask);
            }

            Console.WriteLine("How many points for completing your list?\nSuggestions: Easy - 5, Medium - 15, Hard - 35, Very hard - 100");
            completeReward = int.Parse(Console.ReadLine());
            return this;
        }
        catch (FormatException)
        {
            Menu.changeSystemMessage("Wrong format of input while creating task.");
        }
        catch (ArgumentOutOfRangeException)
        {
            Menu.changeSystemMessage("CAN YOU EVEN READ??");
        }

    throw new InvalidOperationException("Task creation failed due to invalid input.");

    }
}