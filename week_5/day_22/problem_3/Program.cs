
using System;

class Program
{
    
    public static void Main(string [] args)
    {
        try
        {
            Console.WriteLine("Enetr Balance :");
            double balance = double.Parse(Console.ReadLine());

            BankAccount bnk = new BankAccount(balance);

            Console.WriteLine("enter withdraw Emount : ");
            double amount  = double.Parse(Console.ReadLine());

            bnk.withdraw(amount);
        }
        catch(InsufficientExecutionStackException e)
        {
            Console.WriteLine("Error :"+ e.Message);
        }
        finally
        {
            Console.WriteLine("Completed");
        }
    }
}