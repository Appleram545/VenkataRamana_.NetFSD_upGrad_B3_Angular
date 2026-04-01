using MovieAppR.Models;
using MovieAppR.Repositories;

namespace MovieAppR.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repo;

        public MovieService(IMovieRepository repo)
        {
            _repo=repo;
        }

        public List<Movie> GetMovies()
        {
            return _repo.GetAll();
        }
        public Movie GetMovie(int id)
        {
            return _repo.GetById(id);
        }

        public void CreateMovie(Movie movie)
        {
            _repo.Add(movie);
        }
        public void UpdateMovie(Movie movie)
        {
            _repo.Update(movie);
        }
        public void DeleteMovie(int id)
        {
            _repo.Delete(id);
        }
    }
}