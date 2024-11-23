
public class Simple : Task
{
    //attributes (member variables)


    Player currentPlayer = Player.currentPlayer;


    //behaviors (member functions or *methods*)

    public override void completeTask()
    {
        currentPlayer.gainScore(completeReward);
        complete = true;
        //remove self from list
        currentPlayer.playerTasks.Remove(this);
    }

}