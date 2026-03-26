using System;

    class Program
    {
        static void Main(string[] args)
        {
            AreaCalculator calculator = new AreaCalculator();

            // Rectangle
            Shape rectangle = new Rectangle
            {
                Width = 10,
                Height = 5
            };

            calculator.PrintArea(rectangle);

            // Circle
            Shape circle = new Circle
            {
                Radius = 7
            };

            calculator.PrintArea(circle);

            Console.ReadLine();
        }
    }
