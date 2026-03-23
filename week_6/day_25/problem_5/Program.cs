using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Configure trace listener (log file)
        Trace.Listeners.Clear();
        Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));
        Trace.AutoFlush = true;

        Trace.WriteLine("Application Started");

        try
        {
            ValidateOrder();
            ProcessPayment();
            UpdateInventory();
            GenerateInvoice();

            Trace.TraceInformation("Order processed successfully ");
        }
        catch (Exception e)
        {
            Trace.WriteLine("Error occurred: " + e.Message);
        }

        Trace.WriteLine("Application Ended");
    }

    static void ValidateOrder()
    {
        Trace.WriteLine("Validating Order--");
        
    }

    static void ProcessPayment()
    {
        Trace.WriteLine("Processing Payment--");
        
    }

    static void UpdateInventory()
    {
        Trace.WriteLine("Updating Inventory...");
    }

    static void GenerateInvoice()
    {
        Trace.WriteLine("Generating Invoice...");
    }
}