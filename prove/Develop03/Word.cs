using System.Dynamic;

class Word
{
    //attributes (member variables)

    public string _word {get; private set;}
    public bool _isDisplayed {get; private set;}

    //behaviors (member functions or *methods*)

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