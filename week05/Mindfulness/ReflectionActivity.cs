using System;
using System.Threading;

class ReflectionActivity : Activity
{
    private static readonly string[] Prompts =
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly string[] Questions =
    {
        "Why was this experience meaningful to you?",
        "What did you learn from this experience?",
        "How did you feel afterward?",
        "Have you ever done anything like this before?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection Activity", "Reflect on times of strength and resilience.") {}

    protected override void Execute()
    {
        Console.WriteLine("\n" + Prompts[new Random().Next(Prompts.Length)]);
        ShowSpinner(3);
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine(Questions[new Random().Next(Questions.Length)]);
            ShowSpinner(5);
        }
        End();
    }
}
