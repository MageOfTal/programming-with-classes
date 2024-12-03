class Program
{
    static void Main(string[] args)
    {
        Menu MainMenu = Menu.getMenu();
        MainMenu.displayUserData();
        while (true)
        {
            string input = Console.ReadLine();
            if (input.ToLower() == "breathing")
            {
                MainMenu.completeTask(taskList);
            }
            else if (input.ToLower() == "reflection")
            {
                MainMenu.createTask();
            }
            else if (input.ToLower() == "listing")
            {
                MainMenu.deleteTask(taskList);
            }

    }
}