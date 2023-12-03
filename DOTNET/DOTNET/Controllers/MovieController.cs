using ASPCoreApplication2023.Models;
using ASPCoreApplication2023.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreApplication2023.Controllers
{
    public class MovieController : Controller
    {
    
        public IActionResult Index()
        {
            Movie movie = new Movie()
            {
                Name =
            "movie 1"
            };
            List<Movie> Movie = new List<Movie>()
                {
                new Movie{Name="Interstellar"},
                new Movie{Name="Inception"},
                new Movie{Name="The Dark Knight"},

                };
            return View(Movie);
        }
        public IActionResult Edit(int id)
        {
            return Content("Test Id" + id);
        }
        public IActionResult ByRelease(int month, int year)
        {
            return Content("Month " + month + " Year " + year);
        }

        public IActionResult Clients(int id)
        {
            //Si un id n'est pas fourni, renvoyez tous les clients
            var movie = new Movie()
            {
                Name = "Interstellar"
            };
            var Customer = new List<Customer>()
            {
                new Customer{Id=1,Name="Mahdi Chaabane"},
                new Customer{ Id=2,Name="Lionel Messi"},
                new Customer{Id=3,Name="Cristiano Ronaldo"},
            };
            
            if (id != 0)
            {
                var clientFound = Customer.Find(c => c.Id == id);

                if (clientFound ==null)
                {
                    return Content("No client found");
                }
                var filmClient = new FilmClients()
                {
                    Movie = movie,
                    Customer = new List<Customer> { clientFound }
                };
                return View(filmClient);


            }   

            var filmClients = new FilmClients()
            {
                Movie = movie,
                Customer = Customer
            };
            return View(filmClients);
        }
       


    }
}
