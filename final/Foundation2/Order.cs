using System.Net.Http.Headers;

class Order
{
//attributes (member variables)

    private List<Product> _products;

    private Customer _customer;

    

    //behaviors (member functions or *methods*)

    public void SetCustomer (Customer customer)
    {
        _customer = customer;
    }

    public void SetProducts (List<Product> products)
    {
        _products = products;
    }

    public float GetCost()
    {
        float total = 0;
        foreach (Product product in _products)
        {
            total += product.GetTotal();
        }

        if (_customer.CheckUSAddress() == true)
        {
            total += 5;
        }

        else
        {
            total += 15;
        }
        return total;
    }

    public string GetPacking()
    {
        string packing = "";
        foreach (Product product in _products)
        {
            packing += $"{product.GetName()} {product.GetID()}\n";
        }

        return packing;
    }

    public string GetShipping()
    {
        string shipping = "";
        
        shipping += $"{_customer.GetName()}\n{_customer.GetAddress()}";
        return shipping;
    }

    public string GetAddress()
    {
        return _customer.GetAddress();
    }

    public Order (Customer customer, List<Product> products)
    {
        _products = products;

        _customer = customer;
    }

}