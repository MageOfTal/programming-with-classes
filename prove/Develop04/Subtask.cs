
public class Subtask : Task
{
    //attributes (member variables)

    private Checklist _parent = new();

    Player currentPlayer = Player.GetCurrentPlayer();


    //behaviors (member functions or *methods*)

    public Checklist GetParent()
    {
        return _parent;
    }
    public void SetParent(Checklist parent)
    {
        _parent = parent;
    }
    public override void completeTask()
    {
        currentPlayer.gainScore(completeReward);
        complete = true;
        bool allComplete = true;
        foreach (Subtask s in _parent.GetListedTasks())
        {
            if (s.complete == false)
            {
                allComplete = false;
            }
        if (allComplete == true)
        {
            _parent.completeTask();
        }
        }
    }

}