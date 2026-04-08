using Dapper;
using StudentCourse.Models;

namespace StudentCourse.Repositories
{
    public class StudentRepository
    {
        private readonly DapperContext _context;

        public StudentRepository(DapperContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetStudentsWithCourse()
        {
            var query = @"SELECT s.StudentId, s.StudentName, s.CourseId,
                                 c.CourseId, c.CourseName
                          FROM Student s
                          INNER JOIN Course c ON s.CourseId = c.CourseId";

            using var connection = _context.CreateConnection();

            var result = connection.Query<Student, Course, Student>(
                query,
                (student, course) =>
                {
                    student.Course = course;
                    return student;
                },
                splitOn: "CourseId"
            );

            return result.ToList();
        }

        public IEnumerable<Course> GetCoursesWithStudents()
        {
            var query = @"SELECT c.CourseId, c.CourseName,
                                 s.StudentId, s.StudentName, s.CourseId
                          FROM Course c
                          LEFT JOIN Student s ON c.CourseId = s.CourseId";

            using var connection = _context.CreateConnection();

            var dict = new Dictionary<int, Course>();

            var result = connection.Query<Course, Student, Course>(
                query,
                (course, student) =>
                {
                    if (!dict.TryGetValue(course.CourseId, out var current))
                    {
                        current = course;
                        current.Students = new List<Student>();
                        dict.Add(current.CourseId, current);
                    }

                    if (student != null)
                        current.Students.Add(student);

                    return current;
                },
                splitOn: "StudentId"
            );

            return dict.Values;
        }
    }
}