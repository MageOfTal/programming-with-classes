class JournalEntry
{
    //attributes (member variables)

    public string _userEntry;

    public string _promptEntry;

    public string _entryDate;

    //behaviors (member functions or *methods*)

    public void displayEntry()
    {

        Console.WriteLine($"{_entryDate}\n{_promptEntry}\n{_userEntry}\n");
    }

}