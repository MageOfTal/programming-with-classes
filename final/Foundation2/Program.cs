using System;

class Program
{
    static void Main(string[] args)
    {
        Product product1 = new("Vase", "17D", 30.5f, 2);
        Product product2 = new("Chips", "11A", 7f, 5);
        Product product3 = new("Cast Iron Pan", "32L", 25f, 1);

        List<Product> products1 = new();
        List<Product> products2 = new();

        products1.Add(product1);
        products1.Add(product2);

        products2.Add(product2);
        products2.Add(product1);
        products2.Add(product3);

        Address address1 = new("Maple Ave", "Villeville", "Washington", "USA");
        Address address2 = new("Oak Lane", "Bestland", "Oregon", "Japan");

        Customer Dave = new(address1,"Dave Jones");
        Customer Lara = new(address2,"Lara Laura");

        Order order1 = new(Dave,products1);
        Order order2 = new(Lara,products2);

        Console.WriteLine(order1.GetPacking());
        Console.WriteLine(order1.GetShipping());
        Console.WriteLine(order1.GetCost());

        Console.WriteLine(order2.GetPacking());
        Console.WriteLine(order2.GetShipping());
        Console.WriteLine(order2.GetCost());

    }
}