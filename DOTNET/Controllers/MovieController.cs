using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP3.Models;

namespace TP3.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationdbContext _context;

        public MovieController(ApplicationdbContext context)
        {
            _context = context;
        }

        // GET: Movie
        public async Task<IActionResult> Index()
        {
            var applicationdbContext = _context.Movies.Include(m => m.Genre);
            return View(await applicationdbContext.ToListAsync());
        }

        // GET: Movie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var Movie = await _context.Movies
                .Include(m => m.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Movie == null)
            {
                return NotFound();
            }

            return View(Movie);
        }

        // GET: Movie/Create
        public IActionResult Create()
        {
            ViewData["genre_id"] = new SelectList(_context.Genres, "Id", "Id");
            return View();
        }

        // POST: Movie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Movie_Added,genre_id")] Movie Movie,IFormFile file)
        {
            Console.WriteLine("MMMMMMMMM");
            Console.WriteLine(file);
            if (ModelState.IsValid)
            {
                if (file != null && file.Length > 0)
                {
                    
                    using (var memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream);

                        Movie.file = memoryStream.ToArray();
                    }
                    
                }
                _context.Add(Movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["genre_id"] = new SelectList(_context.Genres, "Id", "Id", Movie.genre_id);
            return View(Movie);
        }

        // GET: Movie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var Movie = await _context.Movies.FindAsync(id);
            if (Movie == null)
            {
                return NotFound();
            }
            ViewData["genre_id"] = new SelectList(_context.Genres, "Id", "Id", Movie.genre_id);
            return View(Movie);
        }

        // POST: Movie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Movie_Added,genre_id")] Movie Movie)
        {
            if (id != Movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(Movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["genre_id"] = new SelectList(_context.Genres, "Id", "Id", Movie.genre_id);
            return View(Movie);
        }

        // GET: Movie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var Movie = await _context.Movies
                .Include(m => m.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Movie == null)
            {
                return NotFound();
            }

            return View(Movie);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Movies == null)
            {
                return Problem("Entity set 'ApplicationdbContext.Movie'  is null.");
            }
            var Movie = await _context.Movies.FindAsync(id);
            if (Movie != null)
            {
                _context.Movies.Remove(Movie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
          return (_context.Movies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
