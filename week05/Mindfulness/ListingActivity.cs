using System;
using System.Threading;

class ListingActivity : Activity
{
    private static readonly string[] Prompts =
    {
        "List as many people as you appreciate.",
        "List personal strengths of yours.",
        "List moments you felt joy recently.",
        "List people that you have helped this week?",
        "List When have you felt the Holy Ghost this month?",
        "List some of your personal heroes?"
    };

   public ListingActivity() : base("Listing Activity", "List positive aspects of your life.") {}

    protected override void Execute()
    {
        Console.WriteLine("\n" + Prompts[new Random().Next(Prompts.Length)]);
        ShowSpinner(3);
        Console.WriteLine("Start listing items:");
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int count = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write($"> ");
            if (!string.IsNullOrWhiteSpace(Console.ReadLine()))
                count++;
        }
        Console.WriteLine($"You listed {count} items!");
        End();
    }
}
