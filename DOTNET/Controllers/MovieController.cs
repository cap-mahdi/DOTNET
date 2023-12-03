using Microsoft.AspNetCore.Mvc;
using TP4.Models;
using TP4.Services;

namespace TP4.Controllers
{
    public class MovieController : Controller
    {

        private readonly MovieService movieService;

        public MovieController(MovieService movieService)
        {
            this.movieService = movieService;
        }

        [HttpGet]
        [Route("Movie")]
        public IActionResult Index()
        {
            var movies = movieService.GetMovies();
            return View(movies);
        }
        [HttpGet]
        [Route("Movie/Create")]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpGet]
        [Route("Movie/ordered")]
        public IEnumerable<Movie> GetMoviesOrderCroissantByName()
        {
            
            return movieService.GetMoviesOrderCroissantByName();
        }

        [HttpGet]
        [Route("Movie/role/{id}")]
        public IEnumerable<Movie> GetMoviesByRoleId(int id)
        {
            return movieService.GetMoviesByRoleId(id);
        }

        [HttpGet]
        [Route("Movie/role")]
        public IEnumerable<Movie> GetMoviesByRole(Role role)
        {
            return movieService.GetMoviesByRole(role);
        }

        [HttpPost]
        [Route("Movie/add")]
        public IActionResult AddMovie(Movie movie)
        {
            movieService.AddMovie(movie);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [method: HttpDelete]
        [Route("Movie/{id}")]
        public IActionResult DeleteMovie(int id)
        {
            movieService.DeleteMovie(id);
            return RedirectToAction("Index");
        }



        
    }
}
