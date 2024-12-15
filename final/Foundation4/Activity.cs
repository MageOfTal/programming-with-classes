using System.Runtime.CompilerServices;

abstract class Activity
{
    //attributes (member variables)

    private string _date;

    private double _length;

    //behaviors (member functions or *methods*)

    public Activity (string date, double length)
    {
        _date = date;

        _length = length;
    }

    public string GetDate()
    {
        return _date;
    } 

    public void SetDate(string date)
    {
        _date = date;
    }

    public double GetLength ()
    {
        return _length;
    }

    public void SetLength (double length)
    {
        _length = length;
    }


    public virtual string GetDistanceResults()
    {
        return "";
    }

    public virtual string GetSpeedResults()
    {
        return "";
    }

    public virtual string GetPaceResults()
    {
        return "";
    }

    public string GetSummary()
    {
        return $"{_date} {this.GetType().Name}-{GetDistanceResults()}, {GetSpeedResults()}, {GetPaceResults()}";
    }

}