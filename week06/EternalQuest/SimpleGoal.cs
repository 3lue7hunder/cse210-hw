class SimpleGoal : Goal
{
    private bool isCompleted;

    public SimpleGoal(string name, int points) : base(name, points)
    {
        isCompleted = false;
    }

    public override int RecordEvent()
    {
        if (!isCompleted)
        {
            isCompleted = true;
            return points;
        }
        return 0; // No points if already completed
    }

    public override string Display()
    {
        return $"{(isCompleted ? "[X]" : "[ ]")} {name} - {points} pts";
    }
}
