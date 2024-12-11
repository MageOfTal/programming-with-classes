class Gathering : Event
{
//attributes (member variables)

    private string _name;

    private Address _address;

    

    //behaviors (member functions or *methods*)

    public bool CheckUSAddress()
    {
        return _address.CheckUSAddress();
    }

    public string GetName()
    {
        return _name;
    }

    public string GetAddress()
    {
        return _address.GetAddress();
    }

    public Customer (Address address, string name)
    {
        _address = address;

        _name = name;
    }

}