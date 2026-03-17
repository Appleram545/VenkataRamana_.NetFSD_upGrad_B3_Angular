using System;
using System.Globalization;

class Program
{

    public static void Main(string [] args)
    {
        Cal c = new Cal();

        try
        {
            
            Console.WriteLine("Enter Numerator");
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Denominator");
            int den  = int.Parse(Console.ReadLine());
            c.Division(num,den);
        }
        catch
        {
            Console.WriteLine("Enter Numbers only");
        }
    }
}