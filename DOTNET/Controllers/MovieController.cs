using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DOTNET.Data;
using DOTNET.Models;
using DOTNET.ViewModel;
using NuGet.Protocol;

namespace DOTNET.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.Include(m => m.Genre).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
            .Include(m => m.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        public async Task<IActionResult> Create()
        {
            var Genre = await _context.Genres.ToListAsync();
            ViewBag.Genre = Genre;
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Movie_Added,GenreId")] Movie movie,IFormFile file)
        {
            Console.WriteLine(file==null?"null":"not null");
            if (ModelState.IsValid)
            {
                if (file != null && file.Length > 0)
                {
                    
                    
                    using (var memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream);

                        movie.file = memoryStream.ToArray();
                    }
                    
                }
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
            .Include(m => m.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            var Genre = await _context.Genres.ToListAsync();
            ViewBag.Genre = Genre;
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Movies.Any(m => m.Id == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new { id = movie.Id });
            }
            return View(movie);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
            .Include(m => m.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // public IActionResult Edit(int id)
        // {
        //     return Content("Test Id" + id);
        // }
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
        private bool MovieExists(int id)
        {
          return (_context.Movies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
       
    }
}