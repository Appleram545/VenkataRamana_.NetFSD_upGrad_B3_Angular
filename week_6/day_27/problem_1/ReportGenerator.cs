using System;
using System.Collections.Generic;

public class ReportGenerator
{
    public void GenerateReport(List<Student> students)
    {
        Console.WriteLine("Student Report");

        foreach (var student in students)
        {
            string grade = GetGrade(student.Marks);

            Console.WriteLine($"ID: {student.StudentId}");
            Console.WriteLine($"Name: {student.StudentName}");
            Console.WriteLine($"Marks: {student.Marks}");
            Console.WriteLine($"Grade: {grade}");
           
        }
    }

    private string GetGrade(int marks)
    {
        if (marks >= 90) return "A";
        else if (marks >= 75) return "B";
        else if (marks >= 50) return "C";
        else return "Fail";
    }
}