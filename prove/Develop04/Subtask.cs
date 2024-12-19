
public class Subtask : Task
{
    //attributes (member variables)

    private Checklist _parent = new();

    private int _listReward;

    Player currentPlayer = Player.GetCurrentPlayer();


    //behaviors (member functions or *methods*)

    public void SetListReward(int reward)
    {
        _listReward = reward;
    }

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
        currentPlayer.gainScore(GetCompleteReward());
        SetComplete(true);
        bool allComplete = true;
        foreach (Subtask s in _parent.GetListedTasks())
        {
            if (s.GetComplete() == false)
            {
                allComplete = false;
            }
        }
        if (allComplete == true)
        {
            currentPlayer.gainScore(_listReward);

            _parent.completeTask();
        }
        
    }

}