

class BankAccount
{
    
    private double _balance;

    public BankAccount(double _balance)
    {
        this._balance=_balance;
    }
    public void withdraw(double amount)
    {
        if(amount>_balance)
        {
            throw new InsufficientBalanceException("amount can not exceed available balance");
        }
        _balance -=amount;
        Console.WriteLine("Withdraw sucess & Available balance : "+ _balance);
    }
}