
using System;




class Program
{
    static void Main()
    {
        Console.Write("Enter Electronics Price: ");
        double elPrice = double.Parse(Console.ReadLine());

        Console.Write("Enter Clothins Price: ");
        double clPrice = double.Parse(Console.ReadLine());

        Product el = new Electronics();
        el.Price = elPrice;

        Product cl = new Clothing();
        cl.Price = clPrice;


        Console.WriteLine(" Electronics Price after 5% discount = " + el.CalDiscount());
        Console.WriteLine(" Clothing Price after 15% discount = " + cl.CalDiscount());



    }
}