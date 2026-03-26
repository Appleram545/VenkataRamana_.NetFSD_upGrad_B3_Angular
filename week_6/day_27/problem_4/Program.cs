using System;

    class Program
    {
        static void Main(string[] args)
        {
            // Basic Printer
            BasicPrinter basic = new BasicPrinter();
            basic.Print();

            Console.WriteLine();

            // Advanced Printer
            AdvancedPrinter advanced = new AdvancedPrinter();
            advanced.Print();
            advanced.Scan();
            advanced.Fax();

            Console.ReadLine();
        }
    }
