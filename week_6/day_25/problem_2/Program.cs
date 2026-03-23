using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Product Name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter Product Price:");
        double price = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter Discount Percentage:");
        double discount = double.Parse(Console.ReadLine());

        
        double finalPrice = price - (price * discount / 100);

        Console.WriteLine(" Bill Details");
        Console.WriteLine($"Product: {name}");
        Console.WriteLine($"Original Price: {price}");
        Console.WriteLine($"Discount: {discount}%");
        Console.WriteLine($"Final Price: {finalPrice}");
    }
}