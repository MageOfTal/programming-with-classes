class Journal
{
    //attributes (member variables)

    public List<JournalEntry> CurrentJournal = new();

    public string userName;

    //behaviors (member functions or *methods*)

    public void makeEntry()
    {
        //get the current date
        string currentDate = DateTime.Now.ToString("dd/MM/yyyy");
        //get a prompt
        prompt allPrompts = new();
        string randomPrompt = allPrompts.SelectPrompt();

        //get the user response to the prompt
        Console.WriteLine(randomPrompt);
        string userResponse = Console.ReadLine();

        //create and define the new entry
        JournalEntry newJournal = new();
        newJournal.date = currentDate;
        newJournal.promptEntry = randomPrompt;
        newJournal.userEntry = userResponse;

        //add the entry to the current journal
        CurrentJournal.Add(newJournal);

    }
    public void saveJournal()
    {

    }
    public void loadJournal()
    {
        
    }

}