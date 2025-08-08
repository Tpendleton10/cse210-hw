using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list that can hold any Shape
        List<Shape> shapes = new List<Shape>();

        // Add different shape types
        shapes.Add(new Square("Red", 4));
        shapes.Add(new Rectangle("Blue", 5, 3));
        shapes.Add(new Circle("Green", 2.5));

        // Loop through and display color + area
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"{shape.GetColor()} shape — Area: {shape.GetArea():F2}");
        }
    }
}
