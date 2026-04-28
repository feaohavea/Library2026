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
    public class UserBooksController : Controller
    {
        private readonly LibraryContext _context;

        public UserBooksController(LibraryContext context)
        {
            _context = context;
        }

        // GET: UserBooks
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.UserBook.Include(u => u.Book).Include(u => u.User);
            return View(await libraryContext.ToListAsync());
        }

        // GET: UserBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userBook = await _context.UserBook
                .Include(u => u.Book)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserBookID == id);
            if (userBook == null)
            {
                return NotFound();
            }

            return View(userBook);
        }

        // GET: UserBooks/Create
        public IActionResult Create()
        {
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "BookID");
            ViewData["UserID"] = new SelectList(_context.User, "UserID", "UserID");
            return View();
        }

        // POST: UserBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserBookID,UserID,BookID")] UserBook userBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "BookID", userBook.BookID);
            ViewData["UserID"] = new SelectList(_context.User, "UserID", "UserID", userBook.UserID);
            return View(userBook);
        }

        // GET: UserBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userBook = await _context.UserBook.FindAsync(id);
            if (userBook == null)
            {
                return NotFound();
            }
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "BookID", userBook.BookID);
            ViewData["UserID"] = new SelectList(_context.User, "UserID", "UserID", userBook.UserID);
            return View(userBook);
        }

        // POST: UserBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserBookID,UserID,BookID")] UserBook userBook)
        {
            if (id != userBook.UserBookID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserBookExists(userBook.UserBookID))
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
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "BookID", userBook.BookID);
            ViewData["UserID"] = new SelectList(_context.User, "UserID", "UserID", userBook.UserID);
            return View(userBook);
        }

        // GET: UserBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userBook = await _context.UserBook
                .Include(u => u.Book)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserBookID == id);
            if (userBook == null)
            {
                return NotFound();
            }

            return View(userBook);
        }

        // POST: UserBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userBook = await _context.UserBook.FindAsync(id);
            if (userBook != null)
            {
                _context.UserBook.Remove(userBook);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserBookExists(int id)
        {
            return _context.UserBook.Any(e => e.UserBookID == id);
        }
    }
}
