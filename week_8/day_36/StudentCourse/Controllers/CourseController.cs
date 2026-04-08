using Microsoft.AspNetCore.Mvc;
using StudentCourse.Repositories;

namespace StudentCourse.Controllers
{
    public class CourseController : Controller
    {
        private readonly StudentRepository _repo;

        public CourseController(StudentRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var courses = _repo.GetCoursesWithStudents();
            return View(courses);
        }
    }
}