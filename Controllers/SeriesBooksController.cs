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
    public class SeriesBooksController : Controller
    {
        private readonly LibraryContext _context;

        public SeriesBooksController(LibraryContext context)
        {
            _context = context;
        }

        // GET: SeriesBooks
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.SeriesBook.Include(s => s.Book).Include(s => s.Series);
            return View(await libraryContext.ToListAsync());
        }

        // GET: SeriesBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seriesBook = await _context.SeriesBook
                .Include(s => s.Book)
                .Include(s => s.Series)
                .FirstOrDefaultAsync(m => m.SeriesBookID == id);
            if (seriesBook == null)
            {
                return NotFound();
            }

            return View(seriesBook);
        }

        // GET: SeriesBooks/Create
        public IActionResult Create()
        {
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "BookID");
            ViewData["SeriesID"] = new SelectList(_context.Series, "SeriesID", "SeriesID");
            return View();
        }

        // POST: SeriesBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SeriesBookID,SeriesID,BookID,SeriesNumber")] SeriesBook seriesBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seriesBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "BookID", seriesBook.BookID);
            ViewData["SeriesID"] = new SelectList(_context.Series, "SeriesID", "SeriesID", seriesBook.SeriesID);
            return View(seriesBook);
        }

        // GET: SeriesBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seriesBook = await _context.SeriesBook.FindAsync(id);
            if (seriesBook == null)
            {
                return NotFound();
            }
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "BookID", seriesBook.BookID);
            ViewData["SeriesID"] = new SelectList(_context.Series, "SeriesID", "SeriesID", seriesBook.SeriesID);
            return View(seriesBook);
        }

        // POST: SeriesBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SeriesBookID,SeriesID,BookID,SeriesNumber")] SeriesBook seriesBook)
        {
            if (id != seriesBook.SeriesBookID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seriesBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeriesBookExists(seriesBook.SeriesBookID))
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
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "BookID", seriesBook.BookID);
            ViewData["SeriesID"] = new SelectList(_context.Series, "SeriesID", "SeriesID", seriesBook.SeriesID);
            return View(seriesBook);
        }

        // GET: SeriesBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seriesBook = await _context.SeriesBook
                .Include(s => s.Book)
                .Include(s => s.Series)
                .FirstOrDefaultAsync(m => m.SeriesBookID == id);
            if (seriesBook == null)
            {
                return NotFound();
            }

            return View(seriesBook);
        }

        // POST: SeriesBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seriesBook = await _context.SeriesBook.FindAsync(id);
            if (seriesBook != null)
            {
                _context.SeriesBook.Remove(seriesBook);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeriesBookExists(int id)
        {
            return _context.SeriesBook.Any(e => e.SeriesBookID == id);
        }
    }
}
