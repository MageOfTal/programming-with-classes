class Verse
{
    //attributes (member variables)

    private List<Word> _verseText = new();

    private string _verseReference;


    //behaviors (member functions or *methods*)

    public List<Word> get()
    {
        return _verseText;
    }

    public void Set(List<Word> newVerse)
    {
        _verseText = newVerse;
    }

    public static List<string> ParseVerse(string Text)
    {
        List<string> words = Text.Split(' ','?','.','!').ToList<string>();
        return words;
    }

}