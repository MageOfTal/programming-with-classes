using System.Linq;
using System.Transactions;
public class Menu
{
    //attributes (member variables)

    Player currentPlayer = Player.currentPlayer;
    static Menu MainMenu = new();

    private static string _systemMessage;

    private string userOptions = "Commands:\n(Complete) task    (Create) task    (Delete) task    (Display) tasks    Check (Prestige)";

   //behaviors (member functions or *methods*)

    public static void clearSystemMessage()
    {
        _systemMessage = "";
    }
    public static void addSystemMessage(string message)
    {
        _systemMessage += message + "\n";
    }

    public static Menu getMenu ()
    {
        return MainMenu;
    }

    public static void changeSystemMessage (string message)
    {
        _systemMessage = message + "\n";
    }

    public void displayUserData ()
    {
        Console.WriteLine(playerInfoDisplay());
        Console.WriteLine(userXPBarDisplay());
        Console.WriteLine(userOptions);
        Console.WriteLine(_systemMessage);
        clearSystemMessage();
    }

     


    //Displays numerical and visual representation of Player's progress to next level.
    private string userXPBarDisplay()
    {
        string XPBar = "";
        // Shows current level score/required level score, then starts XP bar with '('
        XPBar += $"{currentPlayer.levelProgress}/{currentPlayer.nextLevelReq}    (";

        // Creates up to 20 'progress' characters for the XP Bar
        int progressChars = (int)Math.Round(currentPlayer.percentToLevel * 20);
        XPBar += string.Concat(Enumerable.Repeat("=", progressChars));

        // Adds remaining characters out of the 20 as 'unfilled'
        XPBar += string.Concat(Enumerable.Repeat("-", 20 - progressChars));

        // Caps bar
        XPBar += ")";

        return XPBar;
    }
    private string playerInfoDisplay()
    {
        string playerData = $"{currentPlayer.playerName}    Level: {currentPlayer.playerLevel}    Score Mult: {currentPlayer.scoreMult}";
        return playerData;
    }

    public void prestige()
    {
        Console.WriteLine($"Last prestige level: {currentPlayer.previousPrestigeLv} Current level: {currentPlayer.playerLevel} Prestige level requirement: {currentPlayer.prestigeLevelRequirement}");
        if (currentPlayer.playerLevel >= currentPlayer.prestigeLevelRequirement)
        {
            Console.WriteLine("Y to Prestige, Enter to cancel.");
            string input = Console.ReadLine();
            if (input.ToLower() == "y")
            {
                currentPlayer.prestigePlayer();
            }
            else 
            {
                changeSystemMessage("Prestige cancelled.");
                displayUserData();
                return;
            }
        }
        else
        {
            Console.WriteLine("Press enter to return.");
            Console.ReadLine();
            displayUserData();
            return;

        }
    }

    public void seeTasks (List<Task> tasks)
    {
        foreach (Task task in tasks)
        {
            if (task is Checklist checklist)
            {
                Console.WriteLine($"{tasks.IndexOf(task)+1}. {task.taskName} ({checklist.itemsDone}/{checklist.listedTasks.Count()})");
            }
            else if (task.complete == true)
            {
                Console.WriteLine($"{tasks.IndexOf(task)+1}. {task.taskName} *");
            }
            else
            {
                Console.WriteLine($"{tasks.IndexOf(task)+1}. {task.taskName}");
            }
        }
        Console.WriteLine ("Enter to close, or select the number of a Checklist to see details.");
        string input = Console.ReadLine();  
        if (string.IsNullOrWhiteSpace(input))
        {
            displayUserData();
            return;
        }             
        int taskIndex;
        try
        {
            taskIndex = int.Parse(input)-1;

            if (tasks[taskIndex] is Checklist c)
            {
                seeTasks(c.listedTasks);
            }
        }
        catch
        {
            changeSystemMessage("Invalid entry.");
            displayUserData();

            return;
        }
    }


    public void displayTasks(List<Task> tasks)
    {
        foreach (Task task in tasks)
        {
            if (task is Checklist checklist)
            {
                Console.WriteLine($"{tasks.IndexOf(task)+1}. {task.taskName} ({checklist.itemsDone}/{checklist.listedTasks.Count()})");
            }
            else if (task.complete == true)
            {
                Console.WriteLine($"{tasks.IndexOf(task)+1}. {task.taskName} ✔");
            }
            else
            {
                Console.WriteLine($"{tasks.IndexOf(task)+1}. {task.taskName}");
            }
        }
        
    }

    public void deleteTask(List<Task> taskList)
    {
        displayTasks(taskList);
        Console.WriteLine("Select task number to delete, or press enter to cancel. Select a checklist for more options.");
        int taskIndex;
        string input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            changeSystemMessage("Cancelled task deletion.");
            displayUserData();
            return;
        }

        try
        {
            taskIndex = int.Parse(input)-1;

            if (!(taskIndex >= 0 && taskIndex < taskList.Count))
            {
                throw new IndexOutOfRangeException();
            }

            if (taskList[taskIndex] is Checklist c)
            {
                Console.WriteLine("D to delete Checklist. S to delete subtask. Enter to cancel.");
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    changeSystemMessage("Cancelled task deletion.");
                    displayUserData();
                    return;
                }
                else if (input.ToLower() == "D")
                {
                    taskList.Remove(taskList[taskIndex]);
                }
                else if (input.ToLower() == "S")
                {
                    deleteTask(c.listedTasks);
                }
                else 
                {
                    changeSystemMessage("Did not recognize input.");
                    displayUserData();
                    return;
                }
                completeTask(c.listedTasks);
            }

            else
            {
                taskList[taskIndex].completeTask();
            }
        }
        catch
        {
            changeSystemMessage("Invalid task number");
            displayUserData();
        }

    }

    public void completeTask(List<Task> taskList)
    {
        displayTasks(taskList);
        Console.WriteLine("Select task number to complete, or press enter to cancel.");
        string input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            changeSystemMessage("Cancelled task completion.");
            displayUserData();
            return;
        }
        int completedTaskIndex;
        try
        {
            completedTaskIndex = int.Parse(input)-1;

            if (!(completedTaskIndex >= 0 && completedTaskIndex < taskList.Count))
            {
                throw new IndexOutOfRangeException();
            }

            if (taskList[completedTaskIndex] is Checklist c)
            {
                completeTask(c.listedTasks);
            }

            else
            {
                
                displayUserData();
                return;

            }
        }
        catch
        {
            changeSystemMessage("Invalid task number");
            displayUserData();
        }


        
    }

    public void createTask()
    {
        Console.WriteLine("Is your task (Simple), (Daily), a (Checklist), or (Repeatable)? Press enter to cancel.");
        string taskType = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(taskType))
        {
            changeSystemMessage("Cancelled task creation.");
            displayUserData();
            return;
        }
        if (taskType.ToLower() == "simple")
        {
            Simple newTask = new();
            currentPlayer.playerTasks.Add(newTask.createTask());
        }
        else if (taskType.ToLower() == "daily")
        {
            Daily newTask = new();
            currentPlayer.playerTasks.Add(newTask.createTask());
        }
        else if (taskType.ToLower() == "checklist")
        {
            Checklist newTask = new();
            currentPlayer.playerTasks.Add(newTask.createTask());
        }
        else if (taskType.ToLower() == "repeatable")
        {
            Repeatable newTask = new();
            currentPlayer.playerTasks.Add(newTask.createTask());
        }
        else
        {
            changeSystemMessage("No valid type entered.");
            displayUserData();
            return;
        }
    displayUserData();
    return;

    }

}