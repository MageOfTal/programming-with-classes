class Event
{
//attributes (member variables)

    private string _title;

    private string _description;

    private string _date;

    private string _time;

    private string _address;

    //behaviors (member functions or *methods*)

    public string StandardDetails()
    {
        string details = "";

        details +=$"{_title}\n{description}\n{date} {time}\n{address}";

        return details;
    }

    public virtual string FullDetails()
    {
        return "";
    }

    public virtual string ShortDescription()
    {
        return "";
    }

}