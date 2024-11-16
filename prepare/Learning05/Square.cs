using System.Drawing;

public class Square : Shape
{
    public double _side;
    public override double CalculateArea()
    {
        return _side*_side;
    } 
}