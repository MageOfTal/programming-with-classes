class Program
{
    static void Main(string[] args)
    {
        Player.GetCurrentPlayer().initializePlayer();
        Menu MainMenu = Menu.getMenu();
        List<Task> taskList = Player.GetCurrentPlayer().GetPlayerTasks();
        MainMenu.displayUserData();
        while (true)
        {
            string input = Console.ReadLine();
            if (input.ToLower() == "complete")
            {
                MainMenu.completeTask(taskList);
            }
            else if (input.ToLower() == "create")
            {
                MainMenu.createTask();
            }
            else if (input.ToLower() == "delete")
            {
                MainMenu.deleteTask(taskList);
            }
            else if (input.ToLower() == "display")
            {
                MainMenu.seeTasks(taskList);
            }
            else if (input.ToLower() == "prestige")
            {
                MainMenu.prestige();
            }                
        }
    }
}