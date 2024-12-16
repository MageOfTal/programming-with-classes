public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    public string GetHomeworkList()
    {
        string homework = $"{_textbookSection} - {_problems}";
        return homework;
    }

    public MathAssignment (string studentName, string topic, string textbookSection, string problems) : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;

    }
    
} 