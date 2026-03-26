using System;



    public class AreaCalculator
    {
        public void PrintArea(Shape shape)
        {
            double area = shape.CalculateArea();
            Console.WriteLine($"Area: {area}");
        }
    }
