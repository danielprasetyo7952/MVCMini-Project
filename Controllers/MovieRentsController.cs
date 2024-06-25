using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCApplication.Data;
using MVCApplication.Models;

namespace MVCApplication.Controllers
{
    [Authorize]
    public class MovieRentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public MovieRentsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: MovieRents
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
              return _context.MovieRent != null ? 
                          View(await _context.MovieRent.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.MovieRent'  is null.");
        }

        // GET: MovieRents/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MovieRent == null)
            {
                return NotFound();
            }

            var movieRent = await _context.MovieRent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieRent == null)
            {
                return NotFound();
            }

            return View(movieRent);
        }

        // GET: MovieRents/Create/{movieId}
        public IActionResult Create(int? movieId)
        {
            ViewData["MovieId"] = movieId;
            ViewData["CustomerId"] = _userManager.GetUserId(User);
            return View();
        }

        // POST: MovieRents/Create/{movieId}
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MovieId,CustomerId,RentDate,ReturnDate")] MovieRent movieRent)
        {
            if (ModelState.IsValid)
            {
                var movie = await _context.Movie.FindAsync(movieRent.MovieId);
                if (movie != null)
                {
                    movie.IsRented = true;
                    _context.Update(movie);
                }

                _context.Add(movieRent);
                await _context.SaveChangesAsync();
                return RedirectToAction("Catalog", "Home");
            }
            return View(movieRent);
        }

        // GET: MovieRents/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MovieRent == null)
            {
                return NotFound();
            }

            var movieRent = await _context.MovieRent.FindAsync(id);
            if (movieRent == null)
            {
                return NotFound();
            }
            return View(movieRent);
        }

        // POST: MovieRents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MovieId,CustomerId,RentDate,ReturnDate")] MovieRent movieRent)
        {
            if (id != movieRent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieRent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieRentExists(movieRent.Id))
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
            return View(movieRent);
        }

        // GET: MovieRents/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MovieRent == null)
            {
                return NotFound();
            }

            var movieRent = await _context.MovieRent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieRent == null)
            {
                return NotFound();
            }

            return View(movieRent);
        }

        // POST: MovieRents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MovieRent == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MovieRent'  is null.");
            }
            var movieRent = await _context.MovieRent.FindAsync(id);
            if (movieRent != null)
            {
                _context.MovieRent.Remove(movieRent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieRentExists(int id)
        {
          return (_context.MovieRent?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
