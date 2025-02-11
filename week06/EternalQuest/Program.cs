using System;

class Program
{
    static void Main()
    {
        Player player = new Player();
        GoalManager manager = new GoalManager();
        manager.LoadGoals("goals.txt");

        while (true)
        {
            Console.Clear();
            player.DisplayScore();
            Console.WriteLine("\n1. Add Goal\n2. Record Goal\n3. Show Goals\n4. Save & Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Goal Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("1. Simple  2. Eternal  3. Checklist  4. Negative");
                Console.Write("Type: ");
                string type = Console.ReadLine();
                
                if (type == "1") manager.AddGoal(new SimpleGoal(name, 100));
                else if (type == "2") manager.AddGoal(new EternalGoal(name, 50));
                else if (type == "3") manager.AddGoal(new ChecklistGoal(name, 50, 5, 500));
                else if (type == "4") manager.AddGoal(new NegativeGoal(name, 30));
            }
            else if (choice == "2")
            {
                Console.Write("Enter goal name: ");
                string goalName = Console.ReadLine();
                manager.RecordEvent(goalName, player);
            }
            else if (choice == "3")
            {
                manager.DisplayGoals();
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
            else if (choice == "4")
            {
                manager.SaveGoals("goals.txt");
                break;
            }
        }
    }
}
