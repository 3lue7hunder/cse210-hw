using System;

abstract class Goal
{
    protected string name;
    protected int points;

    public Goal(string name, int points)
    {
        this.name = name;
        this.points = points;
    }

    public abstract int RecordEvent();  // Polymorphic method
    public abstract string Display();  // Shows goal progress

    public string GetName() => name;
    public int GetPoints() => points;
}
