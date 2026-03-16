using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter Base Salary: ");
        double salary = double.Parse(Console.ReadLine());

       
        Employee manager = new Manager();
        manager._baseSalary = salary;

        Employee developer = new Developer();
        developer._baseSalary = salary;

        Console.WriteLine("Manager Salary = " + manager.CalculateSalary());
        Console.WriteLine("Developer Salary = " + developer.CalculateSalary());
    }
}