using System;
using System.Threading;

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity helps you relax by guiding your breathing.") {}

    protected override void Execute()
    {
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write(" Breathe in... ");
            ShowCountdown(4);
            Console.Write(" Breathe out... ");
            ShowCountdown(4);
        }
        End();
    }
}
