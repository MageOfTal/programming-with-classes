class Nicaea
{
    //attributes (member variables)

    private int count = new();

    //behaviors (member functions or *methods*)

    public void displayVerse()
    {
        Dictionary<string,string> myScriptures = Scriptures.get();
    }

    public void displayEntry()
    {

        Console.WriteLine($"{entryDate}\n{promptEntry}\n{userEntry}\n");
    }

}