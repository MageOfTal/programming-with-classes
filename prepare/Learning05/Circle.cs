using System.Drawing;

public class Circle : Shape
{
    public double _radius;
   
    public override double CalculateArea()
    {
        return _radius*_radius*Math.PI;
    }
}