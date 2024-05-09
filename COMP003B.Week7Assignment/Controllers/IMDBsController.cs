using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COMP003B.Week7Assignment.Data;
using COMP003B.Week7Assignment.Models;

namespace COMP003B.Week7Assignment.Controllers
{
    public class IMDBsController : Controller
    {
        private readonly MovieCatalogueContext _context;

        public IMDBsController(MovieCatalogueContext context)
        {
            _context = context;
        }

        // GET: IMDBs
        public async Task<IActionResult> Index()
        {
            var movieCatalogueContext = _context.IMDBs.Include(i => i.Actor).Include(i => i.Movie);
            return View(await movieCatalogueContext.ToListAsync());
        }

        // GET: IMDBs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iMDB = await _context.IMDBs
                .Include(i => i.Actor)
                .Include(i => i.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iMDB == null)
            {
                return NotFound();
            }

            return View(iMDB);
        }

        // GET: IMDBs/Create
        public IActionResult Create()
        {
            ViewData["actorId"] = new SelectList(_context.Actors, "actorId", "actorName");
            ViewData["movieId"] = new SelectList(_context.Movies, "movieId", "movieTitle");
            return View();
        }

        // POST: IMDBs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,movieId,actorId")] IMDB iMDB)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iMDB);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["actorId"] = new SelectList(_context.Actors, "actorId", "actorName", iMDB.actorId);
            ViewData["movieId"] = new SelectList(_context.Movies, "movieId", "movieTitle", iMDB.movieId);
            return View(iMDB);
        }

        // GET: IMDBs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iMDB = await _context.IMDBs.FindAsync(id);
            if (iMDB == null)
            {
                return NotFound();
            }
            ViewData["actorId"] = new SelectList(_context.Actors, "actorId", "actorName", iMDB.actorId);
            ViewData["movieId"] = new SelectList(_context.Movies, "movieId", "movieTitle", iMDB.movieId);
            return View(iMDB);
        }

        // POST: IMDBs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,movieId,actorId")] IMDB iMDB)
        {
            if (id != iMDB.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iMDB);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IMDBExists(iMDB.Id))
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
            ViewData["actorId"] = new SelectList(_context.Actors, "actorId", "actorName", iMDB.actorId);
            ViewData["movieId"] = new SelectList(_context.Movies, "movieId", "movieTitle", iMDB.movieId);
            return View(iMDB);
        }

        // GET: IMDBs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iMDB = await _context.IMDBs
                .Include(i => i.Actor)
                .Include(i => i.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iMDB == null)
            {
                return NotFound();
            }

            return View(iMDB);
        }

        // POST: IMDBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iMDB = await _context.IMDBs.FindAsync(id);
            if (iMDB != null)
            {
                _context.IMDBs.Remove(iMDB);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IMDBExists(int id)
        {
            return _context.IMDBs.Any(e => e.Id == id);
        }
    }
}
