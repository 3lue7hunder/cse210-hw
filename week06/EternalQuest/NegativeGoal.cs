class NegativeGoal : Goal
{
    public NegativeGoal(string name, int penalty) : base(name, -penalty) { }

    public override int RecordEvent()
    {
        return points;  // Deducts points
    }

    public override string Display()
    {
        return $"[⚠] {name} - Lose {-points} pts when recorded";
    }
}
