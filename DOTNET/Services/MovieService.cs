using TP4.Models;

namespace TP4.Services
{
    public class MovieService
    {
        private readonly ApplicationdbContext _db;
        public MovieService(ApplicationdbContext db)
        {
            _db = db;
        }

        public List<Movie> GetMovies()
        {
            if (_db == null)
            {
                return null;
            }
            return _db.Movie.ToList();
        }

        public void AddMovie(Movie movie)
        {
            _db.Movie.Add(movie);
            _db.SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            Movie movie = _db.Movie.Find(id);

            if (movie == null)
            {
                return;
            }
            _db.Movie.Remove(movie);
            _db.SaveChanges();
        }

        public IEnumerable<Movie> GetMoviesByRole(Role role)
        {
            if (role == null)
            {
                return _db.Movie;
            }

            return _db.Movie.Where(movie => movie.Roles != null && movie.Roles.Contains(role));
        }

        public IEnumerable<Movie> GetMoviesOrderCroissantByName()
        {
            return _db.Movie.OrderBy(movie => movie.Name);
        }

        public IEnumerable<Movie> GetMoviesByRoleId(int id)
        {
            return _db.Movie.Where(movie => movie.Roles != null && movie.Roles.Any(role => role.Id == id));
        }

    }
}
