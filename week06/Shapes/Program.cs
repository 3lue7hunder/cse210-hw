using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create instances of shapes
        Shape square = new Square("Red", 5);
        Shape rectangle = new Rectangle("Blue", 4, 6);
        Shape circle = new Circle("Green", 3);

        // Store shapes in a list
        List<Shape> shapes = new List<Shape> { square, rectangle, circle };

        // Iterate through the list and display color and area
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape Color: {shape.GetColor()}, Area: {shape.GetArea():F2}");
        }
    }
}
