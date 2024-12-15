class Lecture : Event
{
//attributes (member variables)

    private string _speaker;

    private int _capacity;

    //behaviors (member functions or *methods*)

    public override string FullDetails()
    {
        string details = StandardDetails();
        details += $"\n{this.GetType().Name}\nSpeaker: {_speaker}\nCapacity: {_capacity}";

        return details;
    }

    public Lecture (string title, string description, string date, string time, Address address, string speaker, int capacity): base(title, description, date, time, address)
    {
        _speaker = speaker;

        _capacity = capacity;
    }
}