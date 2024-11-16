using System.Drawing;

public class Rectangle : Shape 
{
    public double _side1;
    public double _side2;
    public override double CalculateArea()
    {
        return _side1 * _side2;
    } 
}