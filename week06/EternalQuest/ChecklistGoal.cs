class ChecklistGoal : Goal
{
    private int targetCount;
    private int currentCount;
    private int bonusPoints;

    public ChecklistGoal(string name, int points, int targetCount, int bonusPoints) 
        : base(name, points)
    {
        this.targetCount = targetCount;
        this.bonusPoints = bonusPoints;
        currentCount = 0;
    }

    public override int RecordEvent()
    {
        if (currentCount < targetCount)
        {
            currentCount++;
            return (currentCount == targetCount) ? points + bonusPoints : points;
        }
        return 0;
    }

    public override string Display()
    {
        return $"{(currentCount >= targetCount ? "[X]" : "[ ]")} {name} - {currentCount}/{targetCount} completed";
    }
}
