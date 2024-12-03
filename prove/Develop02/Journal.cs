using System.Formats.Asn1;
using System.IO;
using Microsoft.VisualBasic;
using System.Linq;
class Journal
{
    //attributes (member variables)

    public List<JournalEntry> _currentJournal = new();
    public List<JournalEntry> _newJournal = new();

    public int _dailyStreak;

    //behaviors (member functions or *methods*)

    public void makeEntry()
    {
        //get the current date and yesterday
        string currentDate = DateTime.Now.ToString("dd/MM/yyyy");
        string yesterday = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
        //get a prompt
        prompt allPrompts = new();
        string randomPrompt = allPrompts.SelectPrompt();

        //get the user response to the prompt
        Console.WriteLine(randomPrompt);
        string userResponse = Console.ReadLine();

        //create and define the new entry
        JournalEntry newJournal = new();
        newJournal._entryDate = currentDate;
        newJournal._promptEntry = randomPrompt;
        newJournal._userEntry = userResponse;

        //add the entry to the current journal
        _currentJournal.Add(newJournal);

        //check to see if they extended streak
        if (_currentJournal.Count()>1)
        {
        string lastEntryDate = _currentJournal[_currentJournal.Count()-2]._entryDate;

        if (lastEntryDate == yesterday)
        {
            _dailyStreak++;
        }
        else if (lastEntryDate != currentDate)
        {
            _dailyStreak = 0;
        }
        


        }
        


    }
    public void saveJournal()
    {
        Console.WriteLine ("Choose .txt file location");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (JournalEntry entry in _currentJournal)
            {
                outputFile.WriteLine(entry._entryDate);
                outputFile.WriteLine(entry._promptEntry);
                outputFile.WriteLine(entry._userEntry);
            }

            outputFile.WriteLine(_dailyStreak);
        }
    }
    public void displayJournal()
    {
        foreach(JournalEntry entry in _currentJournal)
        {
            entry.displayEntry();
        }

        Console.WriteLine ($"Your daily journal streak is {_dailyStreak}.");
    }
    public void loadJournal()
    {
        Console.WriteLine("Enter .txt file location");
        string filename = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(filename);
        int index = 0;
        _newJournal.Clear();
        JournalEntry loadJournalEntry = new();
        int lineStatus;
        foreach (string line in lines.Take(lines.Count() - 1))
        {
            

            lineStatus = index % 3;

            if (lineStatus == 0)
            {
                loadJournalEntry._entryDate = line; 
            }

            else if (lineStatus == 1)
            {
                loadJournalEntry._promptEntry = line; 
            }
            else if (lineStatus == 2)
            {
                loadJournalEntry._userEntry = line;
                _newJournal.Add(loadJournalEntry);
                loadJournalEntry = new();
            }
            index++; // Increment the index
        }

        //get the streak from the last line
        if (lines.Count() != 0)
        {
            _dailyStreak = int.Parse(lines[lines.Count()-1]);
        }
        
        
        _currentJournal = _newJournal;
            
    }
            
}

