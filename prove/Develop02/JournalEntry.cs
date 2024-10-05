class JournalEntry
{
    //attributes (member variables)

    public string userEntry;

    public string promptEntry;

    public string date;

    //behaviors (member functions or *methods*)

    public void displayEntry()
    {
        prompt promptList = new();
        promptList.SelectPrompt();
        {
            
        }
                Console.WriteLine($"{date}\n{promptEntry}\n{userEntry}\n");
    }

}