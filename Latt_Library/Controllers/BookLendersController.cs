using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Latt_Library.Data;
using Latt_Library.Models;

namespace Latt_Library.Controllers
{
   

    public class BookLendersController : Controller
    {
        public async Task<IActionResult> LenderBorrowBookIndex()
        {
            return View(await _context.BookLender.ToListAsync());
        }

        public async Task<IActionResult> LenderBorrows()
        {
            return View(await _context.BookLender.ToListAsync());
        }

        public IActionResult LenderBorrowBook()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LenderBorrowBook([Bind("Id,FirstName,LastName,ssId")] BookLender bookLender)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookLender);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(BookLendersController.LenderBorrowBookIndex));
            }
            return View(bookLender);
        }


        private readonly ApplicationDbContext _context;

        public BookLendersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookLenders
        public async Task<IActionResult> Index()
        {
              return View(await _context.BookLender.ToListAsync());
        }

        // GET: BookLenders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookLender == null)
            {
                return NotFound();
            }

            var bookLender = await _context.BookLender
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookLender == null)
            {
                return NotFound();
            }

            return View(bookLender);
        }

        // GET: BookLenders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookLenders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,ssId")] BookLender bookLender)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookLender);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookLender);
        }

        // GET: BookLenders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BookLender == null)
            {
                return NotFound();
            }

            var bookLender = await _context.BookLender.FindAsync(id);
            if (bookLender == null)
            {
                return NotFound();
            }
            return View(bookLender);
        }

        // POST: BookLenders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,ssId")] BookLender bookLender)
        {
            if (id != bookLender.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookLender);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookLenderExists(bookLender.Id))
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
            return View(bookLender);
        }

        // GET: BookLenders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookLender == null)
            {
                return NotFound();
            }

            var bookLender = await _context.BookLender
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookLender == null)
            {
                return NotFound();
            }

            return View(bookLender);
        }

        // POST: BookLenders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BookLender == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BookLender'  is null.");
            }
            var bookLender = await _context.BookLender.FindAsync(id);
            if (bookLender != null)
            {
                _context.BookLender.Remove(bookLender);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookLenderExists(int id)
        {
          return _context.BookLender.Any(e => e.Id == id);
        }
    }
}
