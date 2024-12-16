
using System.Dynamic;

public class Player
{
    //attributes (member variables)
    private static Player _currentPlayer = new();

    //Score towards next level
    private int _levelProgress;

    //Percent of required score to next level
    
    private double _percentToLevel 
    {
        get
        {
            return (double)_levelProgress/_nextLevelReq;
        }
    }

    //Total player score, resets on prestige
    private int _playerScore;

    //Player level, resets on prestige
    private int _playerLevel;

    //Highest player level across all prestiges
    private int _highestLevel;

    //Name of player
    private string _playerName;

    //Total score required for level up
    private int _nextLevelTotalReq;

    //New score required for this level, just keeps track
    private int _nextLevelReq;

    //Score requirement for first level, future levels have higher requirements
    private int _baseLevelReq = 100;

    //Required levels to prestige
    private int _prestigeLevelRequirement;

    //Previous prestige level
    private int _previousPrestigeLv;

    //Multiplies score when gained
    private double _scoreMult;

    //Player task list
    private List<Task> _playerTasks;

    //The menu for the game
    private Menu _currentMenu;


    //behaviors (member functions or *methods*)

    public static Player GetCurrentPlayer()
    {
        return _currentPlayer;
    }
    public int GetLevelProgress()
    {
        return _levelProgress;
    }
    public void SetLevelProgress(int levelProgress)
    {
        _levelProgress = levelProgress;
    }
    public double GetPercentToLevel()
    {
        return _percentToLevel;
    }
    public double GetPlayerScore()
    {
        return _playerScore;
    }    
    public void SetPlayerScore(int playerScore)
    {
        _playerScore = playerScore;
    }
    public double GetPlayerLevel()
    {
        return _playerLevel;
    }
    public int GetHighestLevel()
    {
        return _highestLevel;
    }
    public string GetPlayerName()
    {
        return _playerName;
    }    
    public int GetNextLevelTotalReq()
    {
        return _nextLevelTotalReq;
    }    
    public int GetNextLevelReq()
    {
        return _nextLevelReq;
    } 
    public int GetPrestigeLevelRequirement()
    {
        return _prestigeLevelRequirement;
    }
    public int GetPreviousPrestigeLv()
    {
        return _previousPrestigeLv;
    }
    public double GetScoreMult()
    {
        return _scoreMult;
    }
    public List<Task> GetPlayerTasks()
    {
        return _playerTasks;
    }
    public void initializePlayer()
    {
        Console.WriteLine("Choose a player name:");
        _playerName = Console.ReadLine();
        _playerLevel = 1;
        _playerScore = 0;
        _highestLevel = 1;
        _nextLevelTotalReq = _baseLevelReq;
        _nextLevelReq = _baseLevelReq;
        _previousPrestigeLv = 0;
        _prestigeLevelRequirement = 10;
        _currentMenu = Menu.getMenu();
        _scoreMult = 1;
        _playerTasks = new();
    }


    public void gainScore(int score)
    {
        score = (int)(score*_scoreMult);
        _playerScore += score;
        _levelProgress += score;
        checkLevel();
    }

    private void checkLevel()
    {
        if (_playerScore >= _nextLevelTotalReq)
        {
            levelUp();
        }
    }

    private void levelUp()
    {
        //Increase player level
        _playerLevel++;
        Menu.addSystemMessage("You leveled up!");
        //Add any extra score as progress to next level
        _levelProgress = _playerScore - _nextLevelTotalReq;
        //Adds new goal score to trigger levelUp
        _nextLevelReq = (int)(Math.Pow(1.1,_playerLevel-1)*100);
        _nextLevelTotalReq += _nextLevelReq;
        //In case of multiple level-ups
        checkLevel();

        if (_playerLevel>_highestLevel)
        {
            _highestLevel = _playerLevel;
        }
    }

    public void prestigePlayer()
    {
        if (_playerLevel >= _prestigeLevelRequirement)
        {
            //Mult from level scales slower than level cost from level scales.
            _previousPrestigeLv = _playerLevel;
            _scoreMult = Math.Pow(_playerLevel,1.09);
            _playerLevel = 1;
            _playerScore = 0;
            _nextLevelTotalReq = _baseLevelReq;
            _nextLevelReq = _baseLevelReq;
            _prestigeLevelRequirement += 10;

            Menu.changeSystemMessage("Succesfully prestiged!");
        }
        else
        {
            Menu.changeSystemMessage($"Your level is too low to prestige. Next prestige at {_prestigeLevelRequirement}.");
        }
    }

    public static List<string> ParseVerse(string Text)
    {
        List<string> words = Text.Split(' ','?','.','!').ToList<string>();
        return words;
    }

}