
// Level - 1 Problem 1: Student Grade Evaluator
// Scenario
// You are developing a console-based application in .NET 8 for a school. The application should evaluate a student’s marks and assign a grade based on predefined rules.
// Requirements
// • Accept student name and marks (0-100). • Use if-else statements to determine grade. • Display grade as A, B, C, D or Fail. • Handle invalid input using conditional checks.


using System;

class A
{
     static void Main(string[] args)
    {
        string name;
        int marks;

        Console.WriteLine("Enter Name:");
        name = Console.ReadLine();

        Console.WriteLine("Enter Marks:");
        marks = int.Parse(Console.ReadLine());

        if (marks < 0 || marks > 100)
        {
            Console.WriteLine("Invalid Marks");
        }
        else
        {
            Console.WriteLine("Student: " + name);

            if (marks >= 90)
                Console.WriteLine("Grade: A");
            else if (marks >= 75)
                Console.WriteLine("Grade: B");
            else if (marks >= 60)
                Console.WriteLine("Grade: C");
            else if (marks >= 50)
                Console.WriteLine("Grade: D");
            else
                Console.WriteLine("Grade: Fail");
        }
    }
}