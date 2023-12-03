using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DOTNET.Models;
using DOTNET.Data;

namespace DOTNET.Controllers
{
    public class MembershiptypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MembershiptypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Membershiptype
        public async Task<IActionResult> Index()
        {
              return _context.Membershiptypes != null ? 
                          View(await _context.Membershiptypes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Membershiptype'  is null.");
        }

        // GET: Membershiptype/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Membershiptypes == null)
            {
                return NotFound();
            }

            var Membershiptype = await _context.Membershiptypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Membershiptype == null)
            {
                return NotFound();
            }

            return View(Membershiptype);
        }

        // GET: Membershiptype/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Membershiptype/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SignUpFee,DurationInMonth,DiscountRate")] Membershiptype Membershiptype)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Membershiptype);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Membershiptype);
        }

        // GET: Membershiptype/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Membershiptypes == null)
            {
                return NotFound();
            }

            var Membershiptype = await _context.Membershiptypes.FindAsync(id);
            if (Membershiptype == null)
            {
                return NotFound();
            }
            return View(Membershiptype);
        }

        // POST: Membershiptype/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SignUpFee,DurationInMonth,DiscountRate")] Membershiptype Membershiptype)
        {
            if (id != Membershiptype.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Membershiptype);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembershiptypeExists(Membershiptype.Id))
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
            return View(Membershiptype);
        }

        // GET: Membershiptype/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Membershiptypes == null)
            {
                return NotFound();
            }

            var Membershiptype = await _context.Membershiptypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Membershiptype == null)
            {
                return NotFound();
            }

            return View(Membershiptype);
        }

        // POST: Membershiptype/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Membershiptypes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Membershiptype'  is null.");
            }
            var Membershiptype = await _context.Membershiptypes.FindAsync(id);
            if (Membershiptype != null)
            {
                _context.Membershiptypes.Remove(Membershiptype);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembershiptypeExists(int id)
        {
          return (_context.Membershiptypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
