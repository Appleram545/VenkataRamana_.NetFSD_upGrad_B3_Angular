

// Level - 2 Problem 1: Employee Bonus Calculator
// Scenario
// Develop a console application that calculates employee bonus based on salary and years of experience.
// Requirements
// • Accept employee name, salary and years of experience. • Use if-else and conditional operator. • Bonus rules:    - Experience < 2 years: 5% bonus    - 2-5 years: 10% bonus    - >5 years: 15% bonus • Display final salary after bonus.



using System;

class A
{
    static void Main(string[] args)
    {
        string name;
        double salary, bonus, finalSalary;
        int exp;

        Console.WriteLine("Enter Name:");
        name = Console.ReadLine();

        Console.WriteLine("Enter Salary:");
        salary = double.Parse(Console.ReadLine());

        if (salary < 0)
        {
            Console.WriteLine(" Salary can not be negative");
            return;

        }
        Console.WriteLine("Enter Experience in years :");
        exp = int.Parse(Console.ReadLine());
        if (exp < 0)
        {
            Console.WriteLine(" experience can not be negative");
            return;

        }

        double bonuspercent;

        if (exp < 3)
        {
            bonuspercent = 0.2;

        }
        else if (exp <= 4)
        {
            bonuspercent = 0.5;
        }
        else
        {
            bonuspercent = 0.7;
        }

        bonus = salary > 0 ? salary * bonuspercent : 0;

        finalSalary = bonus + salary;

        Console.WriteLine("Employee: " + name);
        Console.WriteLine("Bonus: " + bonus);
        Console.WriteLine("Final Salary: " + finalSalary);

    }
}