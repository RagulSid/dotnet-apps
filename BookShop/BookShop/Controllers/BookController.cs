﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookShop.Data;
using BookShop.Models;

namespace BookShop.Controllers
{
    public class BookController : Controller
    {
        private readonly BookShopContext _context;

        public BookController(BookShopContext context)
        {
            _context = context;
        }

        // GET: Book
        public async Task<IActionResult> Index()
        {
              return _context.BookViewModel != null ? 
                          View(await _context.BookViewModel.ToListAsync()) :
                          Problem("Entity set 'BookShopContext.BookViewModel'  is null.");
        }

        // GET: Book/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookViewModel == null)
            {
                return NotFound();
            }

            var bookViewModel = await _context.BookViewModel
                .FirstOrDefaultAsync(m => m.BookID == id);
            if (bookViewModel == null)
            {
                return NotFound();
            }

            return View(bookViewModel);
        }

        // GET: Book/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookID,Title,Author,Price")] BookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookViewModel);
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BookViewModel == null)
            {
                return NotFound();
            }

            var bookViewModel = await _context.BookViewModel.FindAsync(id);
            if (bookViewModel == null)
            {
                return NotFound();
            }
            return View(bookViewModel);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookID,Title,Author,Price")] BookViewModel bookViewModel)
        {
            if (id != bookViewModel.BookID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookViewModelExists(bookViewModel.BookID))
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
            return View(bookViewModel);
        }

        // GET: Book/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookViewModel == null)
            {
                return NotFound();
            }

            var bookViewModel = await _context.BookViewModel
                .FirstOrDefaultAsync(m => m.BookID == id);
            if (bookViewModel == null)
            {
                return NotFound();
            }

            return View(bookViewModel);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BookViewModel == null)
            {
                return Problem("Entity set 'BookShopContext.BookViewModel'  is null.");
            }
            var bookViewModel = await _context.BookViewModel.FindAsync(id);
            if (bookViewModel != null)
            {
                _context.BookViewModel.Remove(bookViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookViewModelExists(int id)
        {
          return (_context.BookViewModel?.Any(e => e.BookID == id)).GetValueOrDefault();
        }
    }
}
