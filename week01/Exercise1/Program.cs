using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your First Name? ");
        string first = Console.ReadLine();

        Console.Write("What is your Last Name? ");
        string last = Console.ReadLine();
        
        Console.Write($"Your name is {last}, {first} {last}");

    }
}