abstract class Event
{
//attributes (member variables)

    private string _title;

    private string _description;

    private string _date;

    private string _time;

    private Address _address;

    //behaviors (member functions or *methods*)

    public Event (string title, string description, string date, string time, Address address)
    {
        _title = title;

        _description = description;

        _date = date;

        _time = time;

        _address = address;

    }

    public string StandardDetails()
    {
        string details = "";

        details +=$"{_title}\n{_description}\n{_date} {_time}\n{_address.GetAddress()}";

        return details;
    }

    public abstract string FullDetails();

    public string ShortDescription()
    {
        string details = "";
        details += $"{this.GetType().Name}\n{_title}\n{_date}";
        return details;
    }

}