class Swimming : Activity
{

    //attributes (member variables)
    private double _miles;

    //behaviors (member functions or *methods*)

    public Swimming (string date, double length, double laps): base(date, length)
    {
        _miles = laps * 50 / 1000 * 0.62;
    }

    public override string GetDistanceResults()
    {
        string distance = $"Distance: {_miles.ToString("F1")} miles";
        return distance;
    }

    public override string GetSpeedResults()
    {
        double speedD = _miles/(GetLength()/60);
        string speed = $"Speed: {speedD.ToString("F1")} mph";
        return speed;
    }

    public override string GetPaceResults()
    {
        double paceD = GetLength()/_miles;
        string pace = $"Pace: {paceD.ToString("F1")} min per mile";
        return pace;
    }

}