class Cycling : Activity
{
    //attributes (member variables)

    private double _speed;

    
    //behaviors (member functions or *methods*)

    public Cycling (string date, double length, double speed): base(date, length)
    {
        _speed = speed;
    }

    public override string GetDistanceResults()
    {
        double miles = (_speed*(GetLength()/60));
        string distance = $"Distance: {miles.ToString("F1")} miles";
        return distance;
    }

    public override string GetSpeedResults()
    {
        string speed = $"Speed: {_speed.ToString("F1")} mph";
        return speed;
    }

    public override string GetPaceResults()
    {
        double miles = (_speed*(GetLength()/60));
        double paceD = GetLength()/miles;
        string pace = $"Pace: {paceD.ToString("F1")} min per mile";
        return pace;
    }
}