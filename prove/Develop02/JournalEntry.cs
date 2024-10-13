class JournalEntry
{
    //attributes (member variables)

    public string userEntry;

    public string promptEntry;

    public string entryDate;

    //behaviors (member functions or *methods*)

    public void displayEntry()
    {

        Console.WriteLine($"{entryDate}\n{promptEntry}\n{userEntry}\n");
    }

}