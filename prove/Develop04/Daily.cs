
public class Daily : Task
{
    //attributes (member variables)

    public int dailyStreak;

    Player currentPlayer = Player.currentPlayer;


    //behaviors (member functions or *methods*)

    public override void completeTask()
    {
        if (complete == false)
        {
            currentPlayer.gainScore(completeReward);
            complete = true;
            dailyStreak += 1;
        }
        else
        {
            Menu.changeSystemMessage($"Daily task {taskName} already complete");
        }
    }
    

}