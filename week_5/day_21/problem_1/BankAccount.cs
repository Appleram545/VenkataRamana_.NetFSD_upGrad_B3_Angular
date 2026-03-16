class BankAccount
{

    private int _accountNumber;
    private double _balance;


    public int AccountNumber
    {
        get { return _accountNumber; }
        set { _accountNumber = value; }
    }


    public double Balance
    {
        get { return _balance; }
    }


    public void Deposit(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Deposit amount must be positive.");
            return;
        }

        _balance += amount;
        Console.WriteLine("Amount Deposited: " + amount);
        Console.WriteLine("Current Balance = " + _balance);
    }


    public void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Withdrawal amount must be positive.");
            return;
        }

        if (amount > _balance)
        {
            Console.WriteLine("Insufficient Balance.");
            return;
        }

        _balance -= amount;
        Console.WriteLine("Amount Withdrawn: " + amount);
        Console.WriteLine("Current Balance = " + _balance);
    }
}