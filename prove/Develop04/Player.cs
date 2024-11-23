
using System.Dynamic;

public class Player
{
    //attributes (member variables)
    public static Player currentPlayer = new();

    //Score towards next level
    public int levelProgress {get; private set;}

    //Percent of required score to next level
    public double percentToLevel 
    {
        get
        {
            return levelProgress/nextLevelReq;
        }
    }

    //Total player score, resets on prestige
    public int playerScore {get; private set;}

    //Player level, resets on prestige
    public int playerLevel {get; private set;}

    //Highest player level across all prestiges
    public int highestLevel {get; private set;}

    //Name of player
    public string playerName {get; private set;}

    //Total score required for level up
    public int nextLevelTotalReq {get; private set;}

    //New score required for this level, just keeps track
    public int nextLevelReq {get; private set;}

    //Score requirement for first level, future levels have higher requirements
    private int _baseLevelReq = 100;

    //Required levels to prestige
    public int prestigeLevelRequirement {get; private set;}

    //Previous prestige level
    public int previousPrestigeLv {get; private set;}

    //Multiplies score when gained
    public double scoreMult {get; private set;}

    //Player task list
    public List<Task> playerTasks {get; private set;}

    //The menu for the game
    public Menu currentMenu {get; private set;}


    //behaviors (member functions or *methods*)

    public void initializePlayer()
    {
        Console.WriteLine("Choose a player name:");
        playerName = Console.ReadLine();
        playerLevel = 1;
        playerScore = 0;
        highestLevel = 1;
        nextLevelTotalReq = _baseLevelReq;
        nextLevelReq = _baseLevelReq;
        previousPrestigeLv = 0;
        prestigeLevelRequirement = 10;
        Menu currentMenu = Menu.getMenu();
        scoreMult = 1;
        playerTasks = new();
    }


    public void gainScore(int score)
    {
        score += (int)(score*scoreMult);
        playerScore += score;
        levelProgress += score;
        checkLevel();
    }

    private void checkLevel()
    {
        if (playerScore >= nextLevelTotalReq)
        {
            levelUp();
        }
    }

    private void levelUp()
    {
        //Increase player level
        playerLevel++;
        Menu.addSystemMessage("You leveled up!");
        //Add any extra score as progress to next level
        levelProgress = playerScore - nextLevelTotalReq;
        //Adds new goal score to trigger levelUp
        nextLevelReq = (int)(Math.Pow(playerLevel*100,1.1));
        nextLevelTotalReq += nextLevelReq;
        //In case of multiple level-ups
        checkLevel();

        if (playerLevel>highestLevel)
        {
            highestLevel = playerLevel;
        }
    }

    public void prestigePlayer()
    {
        if (playerLevel >= prestigeLevelRequirement)
        {
            //Mult from level scales slower than level cost from level scales.
            previousPrestigeLv = playerLevel;
            scoreMult = Math.Pow(playerLevel,1.09);
            playerLevel = 1;
            playerScore = 0;
            nextLevelTotalReq = _baseLevelReq;
            nextLevelReq = _baseLevelReq;
            prestigeLevelRequirement += 10;

            Menu.changeSystemMessage("Succesfully prestiged!");
        }
        else
        {
            Menu.changeSystemMessage($"Your level is too low to prestige. Next prestige at {prestigeLevelRequirement}.");
        }
    }

    public static List<string> ParseVerse(string Text)
    {
        List<string> words = Text.Split(' ','?','.','!').ToList<string>();
        return words;
    }

}