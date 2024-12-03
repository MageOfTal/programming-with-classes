public class Fraction
{
    private int _topNum;
    private int _bottomNum;

    public Fraction(int number)
    {
        _topNum = number;
        _bottomNum = 1;
    }

    public Fraction(int top, int bottom)
    {
        _topNum = top;
        _bottomNum = bottom;
    }

    public int GetTop()
    {
        return _topNum;
    }
    public int GetBottom()
    {
        return _bottomNum;
    }

    public void SetTop(int num)
    {
        _topNum = num;
    }

    public void Setbottom(int num)
    {
        _bottomNum = num;
    }

    public string GetFractionString()
    {
        return $"{_topNum}/{_bottomNum}";
    }

    public double GetFractionDecimal()
    {
        return (double)_topNum/_bottomNum;
    }
} 