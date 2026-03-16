using System;



class Program
{
    static void Main()
    {
        BankAccount acc = new BankAccount();

        Console.Write("Enter Account Number: ");
        acc.AccountNumber = int.Parse(Console.ReadLine());

        Console.Write("Enter Deposit Amount: ");
        double deposit = double.Parse(Console.ReadLine());
        acc.Deposit(deposit);

        Console.Write("Enter Withdraw Amount: ");
        double withdraw = double.Parse(Console.ReadLine());
        acc.Withdraw(withdraw);

        Console.WriteLine("Current Balance = " + acc.Balance);
    }
}































































