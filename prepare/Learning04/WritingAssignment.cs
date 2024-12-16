public class WritingAssignment : Assignment
{
    private string _title;

    public string GetWritingInformation()
    {
        string homework = $"{_title} by {GetStudent()}";
        return homework;
    }

    public WritingAssignment (string studentName, string topic, string title) : base(studentName, topic)
    {
        _title = title;

    }
    
} 