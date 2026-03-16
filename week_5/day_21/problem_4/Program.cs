using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter Car Rental Rate Per Day: ");
        int carRate = int.Parse(Console.ReadLine());

        Console.Write("Enter Days: ");
        int days = int.Parse(Console.ReadLine());

        Vehicle car = new Car();
        car.RentalRatePerDay = carRate;

        Console.WriteLine("Total Rental = " + car.calrental(days));
    }
}