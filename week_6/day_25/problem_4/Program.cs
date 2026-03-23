using System;
using System.Threading.Tasks;

class Program
{
    
    static async Task VerifyPaymentAsync()
    {
        Console.WriteLine("Verifying Payment");
        await Task.Delay(2000);
        Console.WriteLine("Payment Verified .");
        Console.WriteLine("-------");
    }

        

    static async Task CheckInventoryAsync()
    {
        Console.WriteLine("Checking Inventory");
        await Task.Delay(1500);
        Console.WriteLine("Inventory Available .");
        Console.WriteLine("-------");
    }

   
    static async Task ConfirmOrderAsync()
    {
        Console.WriteLine("Confirming Order");
        await Task.Delay(1000);
        Console.WriteLine("Order Confirmed .");
        Console.WriteLine("-------");
    }

   
    static async Task Main(string[] args)
    {
        Console.WriteLine("Order Processing Started.");

        
        await VerifyPaymentAsync();
        await CheckInventoryAsync();
        await ConfirmOrderAsync();

        Console.WriteLine("Order Processing Completed Successfully!");
    }
}