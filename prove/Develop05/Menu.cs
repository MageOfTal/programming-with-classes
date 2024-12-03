using System.Dynamic;
using System.Linq;
using System.Transactions;
public class Menu
{
    //attributes (member variables)

    static Menu MainMenu = new();

    public string _userName {get; private set;}

    private static string _systemMessage;

    private string userOptions = "Would you like to do breathing, reflection, or listing today?";

   //behaviors (member functions or *methods*)

    public void getUser()
    {
        Console.WriteLine("What is your name?");

        _userName = Console.ReadLine();
    }

    public string returnUser()
    {
        return _userName;
    }

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
        Console.WriteLine($"Hello {_userName}!");
        Console.WriteLine(userOptions);
        Console.WriteLine(_systemMessage);
        clearSystemMessage();
    }

}