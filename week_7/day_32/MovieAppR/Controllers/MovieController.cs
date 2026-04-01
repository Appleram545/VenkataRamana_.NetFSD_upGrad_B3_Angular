using Microsoft.AspNetCore.Mvc;
using MovieAppR.Models;
using MovieAppR.Services;

namespace MovieAppR.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _service;

        public MovieController(IMovieService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var movies = _service.GetMovies();
            return View(movies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (!ModelState.IsValid)
                return View(movie);

            _service.CreateMovie(movie);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var movie = _service.GetMovie(id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (!ModelState.IsValid)
                return View(movie);

            _service.UpdateMovie(movie);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var movie = _service.GetMovie(id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.DeleteMovie(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var movie = _service.GetMovie(id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }
    }
}