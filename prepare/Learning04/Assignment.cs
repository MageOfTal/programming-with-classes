public class Assignment
{
    private string _studentName;
    private string _topic;

    public string GetSummary()
    {
        string summary = $"{_studentName} - {_topic}";
        return summary;
    }

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    public string GetTopic()
    {
        return _topic;
    }
    public string GetStudent()
    {
        return _studentName;
    }
    
} 