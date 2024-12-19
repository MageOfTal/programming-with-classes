using System.Threading;
public class Menu
{
    //attributes (member variables)

    static Menu MainMenu = new();

    private string _userName;

    private string _systemMessage;

    private string userOptions = "Would you like to do breathing, reflection, or listing today?\nOr, check (completions).";

   //behaviors (member functions or *methods*)

    public void SetupUser()
    {
        Console.WriteLine("What is your name?");

        _userName = Console.ReadLine();
    }

    public string GetUser()
    {
        return _userName;
    }

    public void ClearSystemMessage()
    {
        _systemMessage = "";
    }
    public void AddSystemMessage(string message)
    {
        _systemMessage += message + "\n";
    }

    public static Menu GetMenu ()
    {
        return MainMenu;
    }

    public void ChangeSystemMessage (string message)
    {
        _systemMessage = message + "\n";
    }

    public void DisplayUserData ()
    {
        Console.WriteLine($"Hello {_userName}!");
        Console.WriteLine(userOptions);
        Console.WriteLine(_systemMessage);
        ClearSystemMessage();
    }

}