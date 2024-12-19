
public class Task
{
    //attributes (member variables)

    private bool _complete;

    private Checklist _parentChecklist;

    private string _taskName;

    private int _completeReward;

    private Player currentPlayer = Player.GetCurrentPlayer();


    //behaviors (member functions or *methods*)
    public Checklist GetParentChecklist()
    {
        return _parentChecklist;
    }
    public void SetParentChecklist (Checklist parentChecklist)
    {
        _parentChecklist = parentChecklist;
    }
    public string GetTaskName()
    {
        return _taskName;
    }
    public void SetTaskName(string taskName)
    {
        _taskName = taskName;
    }
    public bool GetComplete()
    {
        return _complete;
    }
    public int GetCompleteReward()
    {
        return _completeReward;
    }
    public void SetCompleteReward(int completeReward)
    {
        _completeReward = completeReward;
    }
    public void SetComplete(bool complete)
    {
        _complete = complete;
    }
    public virtual void completeTask()
    {
        if (_complete == false)
        {
            currentPlayer.gainScore(_completeReward);
            _complete = true;
        }
    }

    public virtual Task createTask()
    {
        Task newTask = new();

        Console.WriteLine("Name your task");
        newTask._taskName = Console.ReadLine();

        Console.WriteLine("How many points for completing your task?\nSuggestions: Easy - 5, Medium - 15, Hard - 35, Very hard - 100");
        //make sure the user knows how to type in a number
        try
        {
            newTask._completeReward = int.Parse(Console.ReadLine());
            return newTask;
        }
        catch
        {
            Menu.changeSystemMessage("Invalid input while creating task.");
        }

        throw new InvalidOperationException("Task creation failed due to invalid input.");

        
    }
    

}