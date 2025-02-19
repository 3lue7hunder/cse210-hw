class Swimming : Activity
{
    private int _laps;
    private const double LapDistance = 50 / 1000.0; // Each lap is 50 meters converted to km

    public Swimming(string date, int duration, int laps) : base(date, duration)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * LapDistance;
    public override double GetSpeed() => (GetDistance() / GetDuration()) * 60;
    public override double GetPace() => GetDuration() / GetDistance();
}
