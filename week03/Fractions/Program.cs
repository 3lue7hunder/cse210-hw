using System;

namespace Fractions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test default constructor
            Fraction fraction1 = new Fraction();
            Console.WriteLine(fraction1.GetFractionString());
            Console.WriteLine(fraction1.GetDecimalValue());

            // Test constructor with one parameter
            Fraction fraction2 = new Fraction(5);
            Console.WriteLine(fraction2.GetFractionString());
            Console.WriteLine(fraction2.GetDecimalValue());

            // Test constructor with two parameters
            Fraction fraction3 = new Fraction(3, 4);
            Console.WriteLine(fraction3.GetFractionString());
            Console.WriteLine(fraction3.GetDecimalValue());

            // Test setters and getters
            fraction3.Numerator = 1;
            fraction3.Denominator = 3;
            Console.WriteLine(fraction3.GetFractionString());
            Console.WriteLine(fraction3.GetDecimalValue());
        }
    }
}
