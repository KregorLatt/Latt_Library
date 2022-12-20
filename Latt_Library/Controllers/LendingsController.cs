﻿using System;
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
    public class LendingsController : Controller

    {
        public IActionResult LendBook()
        {
            ViewData["BookLenderId"] = new SelectList(_context.BookLender, "Id", "Id");
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Id");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LendBook([Bind("Id,BookLenderId,BookId,DateBegin,DateEnd,DateCompleted")] Lending lending)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lending);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookLenderId"] = new SelectList(_context.BookLender, "Id", "Id", lending.BookLenderId);
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Id", lending.BookId);
            return View(lending);
        }

        private readonly ApplicationDbContext _context;

        public LendingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lendings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Lending.Include(l => l.Lender).Include(l => l.LentBook);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Lendings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lending == null)
            {
                return NotFound();
            }

            var lending = await _context.Lending
                .Include(l => l.Lender)
                .Include(l => l.LentBook)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lending == null)
            {
                return NotFound();
            }

            return View(lending);
        }

        // GET: Lendings/Create
        public IActionResult Create()
        {
            ViewData["BookLenderId"] = new SelectList(_context.BookLender, "Id", "Id");
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Id");
            return View();
        }

        // POST: Lendings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookLenderId,BookId,DateBegin,DateEnd,DateCompleted")] Lending lending)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lending);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookLenderId"] = new SelectList(_context.BookLender, "Id", "Id", lending.BookLenderId);
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Id", lending.BookId);
            return View(lending);
        }

        // GET: Lendings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lending == null)
            {
                return NotFound();
            }

            var lending = await _context.Lending.FindAsync(id);
            if (lending == null)
            {
                return NotFound();
            }
            ViewData["BookLenderId"] = new SelectList(_context.BookLender, "Id", "Id", lending.BookLenderId);
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Id", lending.BookId);
            return View(lending);
        }

        // POST: Lendings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookLenderId,BookId,DateBegin,DateEnd,DateCompleted")] Lending lending)
        {
            if (id != lending.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lending);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LendingExists(lending.Id))
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
            ViewData["BookLenderId"] = new SelectList(_context.BookLender, "Id", "Id", lending.BookLenderId);
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Id", lending.BookId);
            return View(lending);
        }

        // GET: Lendings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lending == null)
            {
                return NotFound();
            }

            var lending = await _context.Lending
                .Include(l => l.Lender)
                .Include(l => l.LentBook)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lending == null)
            {
                return NotFound();
            }

            return View(lending);
        }

        // POST: Lendings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lending == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Lending'  is null.");
            }
            var lending = await _context.Lending.FindAsync(id);
            if (lending != null)
            {
                _context.Lending.Remove(lending);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LendingExists(int id)
        {
          return _context.Lending.Any(e => e.Id == id);
        }
    }
}
