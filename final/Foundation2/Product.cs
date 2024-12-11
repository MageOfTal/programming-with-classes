class Product
{
//attributes (member variables)

    private string _name;

    private string _id;
    
    private float _price;

    private int _quantity;

    

    //behaviors (member functions or *methods*)

    public float GetTotal()
    {
        return _price*_quantity;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetID()
    {
        return _id;
    }

    public Product (string name, string id, float price, int quantity)
    {
        _name = name;

        _id = id;

        _price = price;

        _quantity = quantity;
    }

}