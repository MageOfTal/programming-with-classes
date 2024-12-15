using System.ComponentModel.DataAnnotations;

class Reception : Event
{
//attributes (member variables)

    private string _email;
    

    //behaviors (member functions or *methods*)

    public override string FullDetails()
    {
        string details = StandardDetails();
        details += $"\n{this.GetType().Name}\nRSVP: {_email}";
        return details;
    }

    public Reception (string title, string description, string date, string time, Address address, string email): base(title, description, date, time, address)
    {
        _email = email;
    }
}