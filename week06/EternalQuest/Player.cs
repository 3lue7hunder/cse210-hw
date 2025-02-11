class Player
{
    private int score;
    private int level;

    public Player()
    {
        score = 0;
        level = 1;
    }

    public void AddPoints(int points)
    {
        score += points;
        while (score >= level * 100)  // Level up every 100 XP
        {
            level++;
            Console.WriteLine($"🎉 Level Up! You are now Level {level}!");
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"🏅 Score: {score} XP | Level: {level}");
    }
}
