using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void GenerateSalesReport()
    {
        Console.WriteLine("Sales Report Started");
        Thread.Sleep(2000); 
        Console.WriteLine("Sales Report Completed");
    }

    static void GenerateInventoryReport()
    {
        Console.WriteLine("Inventory Report Started");
        Thread.Sleep(3000);
        Console.WriteLine("Inventory Report Completed");
    }

    static void GenerateCustomerReport()
    {
        Console.WriteLine("Customer Report Started");
        Thread.Sleep(1500);
        Console.WriteLine("Customer Report Completed");
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Generating Reports");

        // Run tasks concurrently
        Task t1 = Task.Run( GenerateSalesReport);
        Task t2 = Task.Run(GenerateInventoryReport);
        Task t3 = Task.Run( GenerateCustomerReport);

        // Wait for all tasks
        Task.WaitAll(t1, t2, t3);

        Console.WriteLine("All Reports Generated Successfully!");
    }
}