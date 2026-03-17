using System;
using System.Collections.Generic;

public record Student(int RollNumber, string Name, string Course, int Marks);

class Program
{
    static List<Student> students = new List<Student>();

    static void Main()
    {
        int choice=0;

        while(choice !=4)
        {
            Console.WriteLine("Student Record Management System ");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Display all Students");
            Console.WriteLine("3. Search Student by Roll Number");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;

                case 2:
                    DisplayStudents();
                    break;

                case 3:
                    SearchStudent();
                    break;

                case 4:
                    Console.WriteLine("closing");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        } 
    }

    static void AddStudent()
    {
        int roll, marks;
        string name, course;

        // Roll Number validation
        Console.Write("Enter Roll Number: ");
        while (!int.TryParse(Console.ReadLine(), out roll) || roll <= 0)
        {
            Console.Write("Invalid Roll Number : ");
        }

        Console.Write("Enter Name: ");
        name = Console.ReadLine();

        Console.Write("Enter Course: ");
        course = Console.ReadLine();

        // Marks validation
        Console.Write("Enter Marks: ");
        while (!int.TryParse(Console.ReadLine(), out marks) || marks < 0 || marks > 100)
        {
            Console.Write("Invalid Marks : ");
        }

        students.Add(new Student(roll, name, course, marks));
        Console.WriteLine(" added successfully!");
    }

    static void DisplayStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No records ");
            return;
        }

        Console.WriteLine("Student Records:");
        foreach (var s in students)
        {
            Console.WriteLine($"Roll No: {s.RollNumber} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
        }
    }

    static void SearchStudent()
    {
        Console.Write("Enter Roll Number to search: ");
        if (!int.TryParse(Console.ReadLine(), out int roll))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        var student = students.Find(s => s.RollNumber == roll);

        if (student != null)
        {
            Console.WriteLine("Student Found:");
            Console.WriteLine($"Roll No: {student.RollNumber} | Name: {student.Name} | Course: {student.Course} | Marks: {student.Marks}");
        }
        else
        {
            Console.WriteLine(" not found.");
        }
    }
}