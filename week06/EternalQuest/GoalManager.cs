using System.Collections.Generic;
using System.IO;

class GoalManager
{
    private List<Goal> goals = new List<Goal>();

    public void AddGoal(Goal goal) => goals.Add(goal);

    public void RecordEvent(string goalName, Player player)
    {
        foreach (var goal in goals)
        {
            if (goal.GetName().Equals(goalName, StringComparison.OrdinalIgnoreCase))
            {
                int earnedPoints = goal.RecordEvent();
                player.AddPoints(earnedPoints);
                Console.WriteLine($"✅ {goalName} completed! Earned {earnedPoints} XP.");
                return;
            }
        }
        Console.WriteLine($"⚠ Goal '{goalName}' not found.");
    }

    public void DisplayGoals()
    {
        foreach (var goal in goals)
        {
            Console.WriteLine(goal.Display());
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var goal in goals)
            {
                writer.WriteLine($"{goal.GetType().Name}:{goal.GetName()}:{goal.GetPoints()}");
            }
        }
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename)) return;

        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split(':');
            string type = parts[0];
            string name = parts[1];
            int points = int.Parse(parts[2]);

            if (type == "SimpleGoal") goals.Add(new SimpleGoal(name, points));
            else if (type == "EternalGoal") goals.Add(new EternalGoal(name, points));
            else if (type == "ChecklistGoal") goals.Add(new ChecklistGoal(name, points, 5, 500));
            else if (type == "NegativeGoal") goals.Add(new NegativeGoal(name, points));
        }
    }
}
