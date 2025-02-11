class EternalGoal : Goal
{
    private int streak;

    public EternalGoal(string name, int points) : base(name, points)
    {
        streak = 0;
    }

    public override int RecordEvent()
    {
        streak++;
        return points + (streak * 5);  // Streak bonus increases reward
    }

    public override string Display()
    {
        return $"[∞] {name} - {points} pts per completion (Streak: {streak})";
    }
}
