using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library2026.Areas.Identity.Data;
using Library2026.Models;

namespace Library2026.Controllers
{
    public class GenreBooksController : Controller
    {
        private readonly LibraryContext _context;

        public GenreBooksController(LibraryContext context)
        {
            _context = context;
        }

        // GET: GenreBooks
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.GenreBook.Include(g => g.Book).Include(g => g.Genre);
            return View(await libraryContext.ToListAsync());
        }

        // GET: GenreBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genreBook = await _context.GenreBook
                .Include(g => g.Book)
                .Include(g => g.Genre)
                .FirstOrDefaultAsync(m => m.GenreBookID == id);
            if (genreBook == null)
            {
                return NotFound();
            }

            return View(genreBook);
        }

        // GET: GenreBooks/Create
        public IActionResult Create()
        {
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "BookID");
            ViewData["GenreID"] = new SelectList(_context.Genre, "GenreID", "GenreID");
            return View();
        }

        // POST: GenreBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GenreBookID,GenreID,BookID")] GenreBook genreBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genreBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "BookID", genreBook.BookID);
            ViewData["GenreID"] = new SelectList(_context.Genre, "GenreID", "GenreID", genreBook.GenreID);
            return View(genreBook);
        }

        // GET: GenreBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genreBook = await _context.GenreBook.FindAsync(id);
            if (genreBook == null)
            {
                return NotFound();
            }
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "BookID", genreBook.BookID);
            ViewData["GenreID"] = new SelectList(_context.Genre, "GenreID", "GenreID", genreBook.GenreID);
            return View(genreBook);
        }

        // POST: GenreBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GenreBookID,GenreID,BookID")] GenreBook genreBook)
        {
            if (id != genreBook.GenreBookID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genreBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenreBookExists(genreBook.GenreBookID))
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
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "BookID", genreBook.BookID);
            ViewData["GenreID"] = new SelectList(_context.Genre, "GenreID", "GenreID", genreBook.GenreID);
            return View(genreBook);
        }

        // GET: GenreBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genreBook = await _context.GenreBook
                .Include(g => g.Book)
                .Include(g => g.Genre)
                .FirstOrDefaultAsync(m => m.GenreBookID == id);
            if (genreBook == null)
            {
                return NotFound();
            }

            return View(genreBook);
        }

        // POST: GenreBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genreBook = await _context.GenreBook.FindAsync(id);
            if (genreBook != null)
            {
                _context.GenreBook.Remove(genreBook);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenreBookExists(int id)
        {
            return _context.GenreBook.Any(e => e.GenreBookID == id);
        }
    }
}
