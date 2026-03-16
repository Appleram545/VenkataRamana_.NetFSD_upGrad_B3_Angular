using System;

class Program
{
    static void Main()
    {
        var emp = new Employee("E101", "Ram", 45000m, 35);

        Console.WriteLine("ID : " + emp.EmployeeId);
        Console.WriteLine("Name : " + emp.FullName);
        Console.WriteLine("Salary : " + emp.Salary);

        emp.GiveRaise(10);

        bool result = emp.DeductPenalty(100);

        Console.WriteLine("Penalty Applied : " + result);
        Console.WriteLine("Final Salary : " + emp.Salary);
    }
}