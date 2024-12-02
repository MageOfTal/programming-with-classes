class Reference
{
    //attributes (member variables)

    private string _book;

    private int _chapter;

    private int _startVerse;

    private int _endVerse;

    //behaviors (member functions or *methods*)

    public Reference(string book, int chapter, int startVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = startVerse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public string displayReference()
    {
        string referenceNormalized = "";

        if (_endVerse == _startVerse)
        {
            referenceNormalized += _book + " " + _chapter + ":" + _startVerse;
        }
        else if (_endVerse != _startVerse)
        {
            referenceNormalized += _book + " " + _chapter + ":" + _startVerse + "-" + _endVerse;
        }

        return referenceNormalized;
    }



}