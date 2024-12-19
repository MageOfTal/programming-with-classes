
public class Checklist : Task
{
    //attributes (member variables)

    private List<Task> _listedTasks = new();

    private int _itemsDone;

    Player currentPlayer = Player.GetCurrentPlayer();


    //behaviors (member functions or *methods*)

    public List<Task> GetListedTasks()
    {
        return _listedTasks;
    }

    public int GetItemsDone()
    {
        return _itemsDone;
    }
    public void SetItemsDone(int itemsDone)
    {
        _itemsDone = itemsDone;
    }

    public override void completeTask()
    {
        currentPlayer.gainScore(GetCompleteReward());
        SetComplete(true);
        //remove self from list
        currentPlayer.GetPlayerTasks().Remove(this);
    }

    public virtual Task createSubTask(int i)
    {
        Subtask newTask = new();
        newTask.SetParentChecklist(this);

        newTask.SetListReward(this.GetCompleteReward());

        Console.WriteLine($"Name subtask {i+1}");
        newTask.SetTaskName(Console.ReadLine());

        Console.WriteLine("How many points for completing this subtask?\nSuggestions: Easy - 5, Medium - 15, Hard - 35, Very hard - 100");
        //make sure the user knows how to type in a number
        try
        {
            newTask.SetCompleteReward(int.Parse(Console.ReadLine()));
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
        _itemsDone = 0;
        
        try
        {

            Console.WriteLine("Name your task");
            
            SetTaskName(Console.ReadLine());
            Console.WriteLine("How many sub-tasks? Limit 20.");

            
            int listLength = int.Parse(Console.ReadLine());

            if (listLength > 20 || listLength < 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            
            Console.WriteLine("How many points for completing your list?\nSuggestions: Easy - 5, Medium - 15, Hard - 35, Very hard - 100");
            SetCompleteReward(int.Parse(Console.ReadLine()));
            
            for (int i = 0; i< listLength; i++)
            {
                var subTask = createSubTask(i);
                this._listedTasks.Add(subTask);
            }
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