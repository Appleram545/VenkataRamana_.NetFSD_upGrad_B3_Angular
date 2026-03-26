using System;

    public class StudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public void AddStudent(Student student)
        {
            _repository.AddStudent(student);
        }

        public void DisplayStudents()
        {
            var students = _repository.GetAllStudents();

            foreach (var s in students)
            {
                Console.WriteLine($"ID: {s.StudentId}, Name: {s.StudentName}, Course: {s.Course}");
            }
        }

        public void FindStudent(int id)
        {
            var student = _repository.GetStudentById(id);

            if (student != null)
                Console.WriteLine($"Found: {student.StudentName}");
            else
                Console.WriteLine("Student not found");
        }

        public void DeleteStudent(int id)
        {
            _repository.DeleteStudent(id);
            Console.WriteLine("Student deleted (if existed)");
        }
    }
