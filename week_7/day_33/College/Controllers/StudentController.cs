using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using College.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace College.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var students = _context.Students
                .Include(s => s.Course)
                .ToList();

            return View(students);
        }


        public IActionResult Create()
        {
            var courses = _context.Courses.ToList();

            ViewBag.Courses = new SelectList(
                courses,
                "CourseId",
                "CourseName"
            );
            return View();
        }


        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Courses = new SelectList(
        _context.Courses.ToList(),
        "CourseId",
        "CourseName"
                );
            return View(student);
        }
    }
}