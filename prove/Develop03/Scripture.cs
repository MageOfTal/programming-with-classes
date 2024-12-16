class Scripture
{
    private List<Word> _scripture;

    private Reference _reference;

    //attributes (member variables)

    public Scripture(string scripture, string scriptureBook, int chapter, int verseStart)
    {
        _scripture = new();

        string[] words = scripture.Split(' ');

        foreach (string word in words)
        {
            _scripture.Add(new Word(word));
        }

        _reference = new Reference(scriptureBook,chapter,verseStart);
    }
    public Scripture(string scripture, string scriptureBook, int chapter, int verseStart, int verseEnd)
    {
        string[] words = scripture.Split(' ');

        foreach (string word in words)
        {
            _scripture.Add(new Word(word));
        }

        _reference = new Reference(scriptureBook,chapter,verseStart,verseEnd);
    }

    public void memory()
    {
        Console.WriteLine(_reference.displayReference());

        string normalizedScripture = "";

        foreach (Word word in _scripture)
        {
            if (word.GetIsDisplayed() == true)
            {
                normalizedScripture += word.GetWord();
            }
            else 
            {
                normalizedScripture += new string('_',word.GetWord().Length);
            }

            normalizedScripture += " ";
        }

        Console.WriteLine(normalizedScripture);
        
        bool areAllHidden = true;

        foreach (Word word in _scripture)
        {
            if (word.GetIsDisplayed() == true)
            {
                areAllHidden = false;
            }
        }

        if (areAllHidden == true)
        {
            Environment.Exit(0);
        }

        Console.WriteLine("Press Enter to continue or type \"quit\" to finish.");
        
        string input = Console.ReadLine().ToLower();

        if (input == "quit")
        {
            Environment.Exit(0);
        }

        else
        {
            hider();
            memory();
        }

    }

    public void hider()
    {
        List<int> unhiddenWords = new();

        List<int> toHide = new();

        int index = 0;
    
        foreach (Word word in _scripture)
        {
            if (word.GetIsDisplayed() == true)
            {
                unhiddenWords.Add(index);
            }
            
            index ++;
        }

    Random random = new();
    
    toHide = unhiddenWords.OrderBy(_ => random.Next()).Take(4).ToList();

    foreach (int i in toHide)
    {
        _scripture[i].hide();
    }



    }
}