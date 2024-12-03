using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction thing = new Fraction(1);
        Fraction thing2 = new Fraction(1,5);

        Console.WriteLine(thing.GetFractionDecimal());
        Console.WriteLine(thing.GetFractionString());
        Console.WriteLine(thing2.GetFractionDecimal());
        Console.WriteLine(thing2.GetFractionString());

        thing2.SetTop(3);
        Console.WriteLine(thing2.GetTop());
        thing2.Setbottom(4);
        Console.WriteLine(thing2.GetBottom());
    }
}