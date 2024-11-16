using System.Drawing;

public class Shape
{

    private string _color = "Red";
    public string GetColor()
    {
        return _color;
    }
    public void SetColor (string inputColor)
    {
        _color = inputColor;
    }
    public virtual double CalculateArea()
    {
        return 0;
    }
}