class Developer : Employee
{

    public override double CalculateSalary()
    {
        return _baseSalary + (_baseSalary * 0.10);
    }
}