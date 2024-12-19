using System.Linq;
using System.Transactions;
public class Menu
{
    //attributes (member variables)

    Player currentPlayer = Player.GetCurrentPlayer();
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
        XPBar += $"{currentPlayer.GetLevelProgress()}/{currentPlayer.GetNextLevelReq()}    (";

        // Creates up to 20 'progress' characters for the XP Bar
        int progressChars = (int)Math.Round(currentPlayer.GetPercentToLevel() * 20);
        XPBar += string.Concat(Enumerable.Repeat("=", progressChars));

        // Adds remaining characters out of the 20 as 'unfilled'
        XPBar += string.Concat(Enumerable.Repeat("-", 20 - progressChars));

        // Caps bar
        XPBar += ")";

        return XPBar;
    }
    private string playerInfoDisplay()
    {
        string playerData = $"{currentPlayer.GetPlayerName()}    Level: {currentPlayer.GetPlayerLevel()}    Score Mult: {currentPlayer.GetScoreMult()}";
        return playerData;
    }

    public void prestige()
    {
        Console.WriteLine($"Last prestige level: {currentPlayer.GetPreviousPrestigeLv()} Current level: {currentPlayer.GetPlayerLevel()} Prestige level requirement: {currentPlayer.GetPrestigeLevelRequirement()}");
        if (currentPlayer.GetPlayerLevel() >= currentPlayer.GetPrestigeLevelRequirement())
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
            int taskNumber = tasks.IndexOf(task)+1;
            if (task is Checklist checklist)
            {
                Console.WriteLine($"{taskNumber}. {task.GetTaskName()} ({checklist.GetItemsDone()}/{checklist.GetListedTasks().Count()})");
            }
            else if (task.GetComplete() == true)
            {
                Console.WriteLine($"{taskNumber}. {task.GetTaskName()} *");
            }
            else
            {
                Console.WriteLine($"{taskNumber}. {task.GetTaskName()}");
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
                Console.WriteLine($"Task name: {tasks[taskIndex].GetTaskName()}");
                Console.WriteLine($"Completion Reward: {tasks[taskIndex].GetCompleteReward()}");
                Console.WriteLine($"Task type: {tasks[taskIndex].GetType().Name}");

                seeTasks(c.GetListedTasks());
            }

            else
            {
                Console.WriteLine($"Task name: {tasks[taskIndex].GetTaskName()}");
                Console.WriteLine($"Completion Reward: {tasks[taskIndex].GetCompleteReward()} points");
                Console.WriteLine($"Task type: {tasks[taskIndex].GetType().Name}");
                Console.WriteLine("Enter to return");
                Console.ReadLine();
                displayUserData();
                return;

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
                Console.WriteLine($"{tasks.IndexOf(task)+1}. {task.GetTaskName()} ({checklist.GetItemsDone()}/{checklist.GetListedTasks().Count()})");
            }
            else if (task.GetComplete() == true)
            {
                Console.WriteLine($"{tasks.IndexOf(task)+1}. {task.GetTaskName()} *");
            }
            else
            {
                Console.WriteLine($"{tasks.IndexOf(task)+1}. {task.GetTaskName()}");
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
                else if (input.ToLower() == "d")
                {
                    taskList.RemoveAt(taskIndex);
                    displayUserData();
                    return;
                }
                else if (input.ToLower() == "s")
                {
                    deleteTask(c.GetListedTasks());
                }
                else 
                {
                    changeSystemMessage("Did not recognize input.");
                    displayUserData();
                    return;
                }
            }

            else
            {
                taskList.RemoveAt(taskIndex);
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
            else if (taskList[completedTaskIndex].GetComplete() == true)
            {
                changeSystemMessage("That task is already complete.");
                displayUserData();
                return;
            }

            if (taskList[completedTaskIndex] is Checklist c)
            {
    
                completeTask(c.GetListedTasks());
                
            }

            else
            {
                taskList[completedTaskIndex].completeTask();
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
        try 
        {
            if (string.IsNullOrWhiteSpace(taskType))
            {
                changeSystemMessage("Cancelled task creation.");
                displayUserData();
                return;
            }
            if (taskType.ToLower() == "simple")
            {
                Simple newTask = new();
                currentPlayer.GetPlayerTasks().Add(newTask.createTask());
            }
            else if (taskType.ToLower() == "daily")
            {
                Daily newTask = new();
                currentPlayer.GetPlayerTasks().Add(newTask.createTask());
            }
            else if (taskType.ToLower() == "checklist")
            {
                Checklist newTask = new();
                currentPlayer.GetPlayerTasks().Add(newTask.createTask());
            }
            else if (taskType.ToLower() == "repeatable")
            {
                Repeatable newTask = new();
                currentPlayer.GetPlayerTasks().Add(newTask.createTask());
            }
        }
        catch
        {
            changeSystemMessage("No valid type entered.");
            displayUserData();
            return;
        }
    displayUserData();
    return;

    }

}