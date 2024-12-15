class Gathering : Event
{
//attributes (member variables)

    private string _weather;

    //behaviors (member functions or *methods*)

    public override string FullDetails()
    {
        string details = StandardDetails();
        details += $"\n{this.GetType().Name}\nForecasted weather: {_weather}";
        return details;
    }

    public Gathering (string title, string description, string date, string time, Address address, string weather): base(title, description, date, time, address)
    {
        _weather = weather;
    }
}