using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running("03 Feb 2025", 30, 4.8),
            new Cycling("05 Feb 2025", 40, 20.0),
            new Swimming("07 Feb 2025", 25, 20)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
