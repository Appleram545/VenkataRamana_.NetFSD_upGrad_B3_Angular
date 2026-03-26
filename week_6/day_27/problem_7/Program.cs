using System;

    class Program
    {
        static void Main(string[] args)
        {
            var repository = new StudentRepository();
            var service = new StudentService(repository);

            // Add Students
            service.AddStudent(new Student { StudentId = 1, StudentName = "Ram", Course = "C#" });
            service.AddStudent(new Student { StudentId = 2, StudentName = "Anu", Course = "Java" });

            Console.WriteLine("All Students:");
            service.DisplayStudents();

            Console.WriteLine();

            // Find Student
            service.FindStudent(1);

            Console.WriteLine();

            // Delete Student
            service.DeleteStudent(2);

            Console.WriteLine();

            Console.WriteLine("After Deletion:");
            service.DisplayStudents();

            Console.ReadLine();
        }
    }
