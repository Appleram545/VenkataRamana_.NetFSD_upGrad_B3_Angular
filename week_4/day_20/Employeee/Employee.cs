using System;

public class Employee
{
    
    private string _name = "";
    private int _age;
    private decimal _salary;
    private readonly string _employeeId;


    public string FullName
    {
        get
        {
            return _name;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Full name cannot be empty.");

            _name = value.Trim();
        }
    }


    public int Age
    {
        get
        {
            return _age;
        }
        set
        {
            if (value < 18 || value > 80)
                throw new ArgumentException("Age must be between 18 and 80.");

            _age = value;
        }
    }

    
    public decimal Salary
    {
        get
        {
            return _salary;
        }
        private set
        {
            if (value < 1000)
                throw new ArgumentException("Salary cannot be below 1000.");

            _salary = value;
        }
    }

    // Read-only EmployeeId
    public  string EmployeeId
    {
        get { return _employeeId; }
    }

    // Constructor 
    public Employee(string employeeId, string fullName, decimal salary, int age)
    {
        if (string.IsNullOrWhiteSpace(employeeId))
            throw new ArgumentException("Employee ID cannot be empty.");

        _employeeId = employeeId;

        FullName = fullName;
        Age = age;
        Salary = salary;
    }

    // Give Raise
    public void GiveRaise(decimal percentage)
    {
        if (percentage <= 0 || percentage > 40)
            throw new ArgumentException("Raise percentage must be between 1 and 40.");

        Salary = Salary * (1 + percentage / 100);

        Console.WriteLine($"Raise applied. New salary: {Salary}");
    }

    // Deduct Penalty
    public bool DeductPenalty(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Penalty must be greater than 0.");

        decimal newSalary = Salary - amount;

        if (newSalary < 1000)
            return false;

        Salary = newSalary;
        return true;
    }
}