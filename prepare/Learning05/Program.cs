using System;
using System.Drawing;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("run");

        List<Shape> shapes = new();
        Square shape1 = new();
        shape1._side = 5;
        Circle shape2 = new();
        shape2._radius = 4;
        Rectangle shape3 = new();
        shape3._side1 = 6;
        shape3._side2 = 5;
        shapes.Add(shape1);
        shapes.Add(shape2);
        shapes.Add(shape3);
        
        foreach (Shape s in shapes)
        {
            Console.WriteLine("and here");
            double area = s.CalculateArea();
            Console.WriteLine(area);
            string color = s.GetColor();
            Console.WriteLine(color);
        }

    }
    
}