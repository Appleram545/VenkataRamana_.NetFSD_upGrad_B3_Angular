using System;

    public class AdvancedPrinter : IPrinter, IScanner, IFax
    {
        public void Print()
        {
            Console.WriteLine("Advanced Printer: Printing ---");
        }

        public void Scan()
        {
            Console.WriteLine("Advanced Printer: Scanning ---");
        }

        public void Fax()
        {
            Console.WriteLine("Advanced Printer: Sending Fax ---");
        }
    }
