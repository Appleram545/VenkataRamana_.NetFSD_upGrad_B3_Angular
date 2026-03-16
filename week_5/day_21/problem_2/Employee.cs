class Employee
{
    public string _name { get; set; }
    public double _baseSalary { get; set; }


    public virtual double CalculateSalary()
    {
        return _baseSalary;
    }
}