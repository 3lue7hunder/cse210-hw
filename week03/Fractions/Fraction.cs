using System;

namespace Fractions
{
    public class Fraction
    {
        // Private attributes
        private int numerator;
        private int denominator;

        // Default constructor (1/1)
        public Fraction()
        {
            numerator = 1;
            denominator = 1;
        }

        // Constructor with one parameter (x/1)
        public Fraction(int numerator)
        {
            this.numerator = numerator;
            this.denominator = 1;
        }

        // Constructor with two parameters (x/y)
        public Fraction(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        // Getter and Setter for numerator
        public int Numerator
        {
            get { return numerator; }
            set { numerator = value; }
        }

        // Getter and Setter for denominator
        public int Denominator
        {
            get { return denominator; }
            set 
            { 
                if (value != 0) // Prevent division by zero
                {
                    denominator = value;
                }
                else
                {
                    throw new ArgumentException("Denominator cannot be zero.");
                }
            }
        }

        // Method to get the fraction string
        public string GetFractionString()
        {
            return $"{numerator}/{denominator}";
        }

        // Method to get the decimal value
        public double GetDecimalValue()
        {
            return (double)numerator / denominator;
        }
    }
}
