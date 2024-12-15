class Address
{
//attributes (member variables)

    private string _street;

    private string _city;

    private string _state;

    private string _country;
    

    //behaviors (member functions or *methods*)

    public bool CheckUSAddress()
    {
        if (_country == "USA")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Address(string street, string city, string state, string country)
    {
        _street = street;

        _city = city;

        _state = state;

        _country = country;
    }

    public string GetAddress()
    {
        string address = $"{_street}\n{_city}, {_state}\n{_country}";
        return address;
    }

}