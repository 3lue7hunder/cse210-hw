using System;
using System.Threading;

abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Start()
    {
        Console.WriteLine($"\nStarting {_name}...");
        Console.WriteLine(_description);
        Console.Write("Enter duration (seconds): ");
        _duration = int.Parse(Console.ReadLine() ?? "10");
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
        Execute();
    }

    protected abstract void Execute();

    protected void End()
    {
        Console.WriteLine("\nWell done!");
        Console.WriteLine($"You completed {_name} for {_duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write($"{spinner[i % 4]}\b");
            Thread.Sleep(250);
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}
