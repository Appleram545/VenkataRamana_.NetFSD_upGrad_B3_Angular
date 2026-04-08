using Microsoft.AspNetCore.Mvc;
using StudentCourse.Repositories;

namespace StudentCourse.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRepository _repo;

        public StudentController(StudentRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var students = _repo.GetStudentsWithCourse();
            return View(students);
        }
    }
}