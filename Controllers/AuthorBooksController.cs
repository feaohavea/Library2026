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
    public class AuthorBooksController : Controller
    {
        private readonly LibraryContext _context;

        public AuthorBooksController(LibraryContext context)
        {
            _context = context;
        }

        // GET: AuthorBooks
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.AuthorBook.Include(a => a.Author).Include(a => a.Book);
            return View(await libraryContext.ToListAsync());
        }

        // GET: AuthorBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorBook = await _context.AuthorBook
                .Include(a => a.Author)
                .Include(a => a.Book)
                .FirstOrDefaultAsync(m => m.AuthorBookID == id);
            if (authorBook == null)
            {
                return NotFound();
            }

            return View(authorBook);
        }

        // GET: AuthorBooks/Create
        public IActionResult Create()
        {
            ViewData["AuthorID"] = new SelectList(_context.Author, "AuthorID", "AuthorID");
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "BookID");
            return View();
        }

        // POST: AuthorBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuthorBookID,AuthorID,BookID")] AuthorBook authorBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(authorBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorID"] = new SelectList(_context.Author, "AuthorID", "AuthorID", authorBook.AuthorID);
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "BookID", authorBook.BookID);
            return View(authorBook);
        }

        // GET: AuthorBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorBook = await _context.AuthorBook.FindAsync(id);
            if (authorBook == null)
            {
                return NotFound();
            }
            ViewData["AuthorID"] = new SelectList(_context.Author, "AuthorID", "AuthorID", authorBook.AuthorID);
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "BookID", authorBook.BookID);
            return View(authorBook);
        }

        // POST: AuthorBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuthorBookID,AuthorID,BookID")] AuthorBook authorBook)
        {
            if (id != authorBook.AuthorBookID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authorBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorBookExists(authorBook.AuthorBookID))
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
            ViewData["AuthorID"] = new SelectList(_context.Author, "AuthorID", "AuthorID", authorBook.AuthorID);
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "BookID", authorBook.BookID);
            return View(authorBook);
        }

        // GET: AuthorBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorBook = await _context.AuthorBook
                .Include(a => a.Author)
                .Include(a => a.Book)
                .FirstOrDefaultAsync(m => m.AuthorBookID == id);
            if (authorBook == null)
            {
                return NotFound();
            }

            return View(authorBook);
        }

        // POST: AuthorBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var authorBook = await _context.AuthorBook.FindAsync(id);
            if (authorBook != null)
            {
                _context.AuthorBook.Remove(authorBook);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorBookExists(int id)
        {
            return _context.AuthorBook.Any(e => e.AuthorBookID == id);
        }
    }
}
