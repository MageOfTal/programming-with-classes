using System.Formats.Asn1;
using System.IO;
using Microsoft.VisualBasic;
class Journal
{
    //attributes (member variables)

    public List<JournalEntry> CurrentJournal = new();
    public List<JournalEntry> NewJournal = new();

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
        newJournal.entryDate = currentDate;
        newJournal.promptEntry = randomPrompt;
        newJournal.userEntry = userResponse;

        //add the entry to the current journal
        CurrentJournal.Add(newJournal);

    }
    public void saveJournal()
    {
        Console.WriteLine ("Choose .txt file location");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (JournalEntry entry in CurrentJournal)
            {
                outputFile.WriteLine(entry.entryDate);
                outputFile.WriteLine(entry.promptEntry);
                outputFile.WriteLine(entry.userEntry);
            }

        }
    }
    public void displayJournal()
    {
        foreach(JournalEntry entry in CurrentJournal)
        {
            entry.displayEntry();
        }
    }
    public void loadJournal()
    {
        Console.WriteLine("Enter .txt file location");
        string filename = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(filename);
        int index = 0;
        NewJournal.Clear();
        JournalEntry loadJournalEntry = new();
        int lineStatus;
        foreach (string line in lines)
        {
            

            lineStatus = index % 3;

            if (lineStatus == 0)
            {
                loadJournalEntry.entryDate = line; 
            }

            else if (lineStatus == 1)
            {
                loadJournalEntry.promptEntry = line; 
            }
            else if (lineStatus == 2)
            {
                loadJournalEntry.userEntry = line;
                NewJournal.Add(loadJournalEntry);
                loadJournalEntry = new();
            }
            index++; // Increment the index
        }
        
        CurrentJournal = NewJournal;
            
    }
            
}

