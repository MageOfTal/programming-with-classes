using System.Dynamic;

class Word
{
    //attributes (member variables)

    private string _word;
    private bool _isDisplayed;

    //behaviors (member functions or *methods*)

    public bool GetIsDisplayed()
    {
        return _isDisplayed;
    }

    public string GetWord()
    {
        return _word;
    }
    public Word(string word)
    {
        _word = word;
        
        _isDisplayed = true;
    }

    public void hide()
    {
        _isDisplayed = false;
    }

}