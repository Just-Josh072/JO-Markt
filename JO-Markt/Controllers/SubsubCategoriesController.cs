using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JOMarkt.Data;
using JOMarkt.Models;

namespace JO_Markt.Controllers
{
    public class SubsubCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubsubCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SubsubCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.SubsubCategory.ToListAsync());
        }

        // GET: SubsubCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subsubCategory = await _context.SubsubCategory
                .FirstOrDefaultAsync(m => m.SubsubcategoryId == id);
            if (subsubCategory == null)
            {
                return NotFound();
            }

            return View(subsubCategory);
        }

        // GET: SubsubCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SubsubCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubsubcategoryId,Name")] SubsubCategory subsubCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subsubCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subsubCategory);
        }

        // GET: SubsubCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subsubCategory = await _context.SubsubCategory.FindAsync(id);
            if (subsubCategory == null)
            {
                return NotFound();
            }
            return View(subsubCategory);
        }

        // POST: SubsubCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubsubcategoryId,Name")] SubsubCategory subsubCategory)
        {
            if (id != subsubCategory.SubsubcategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subsubCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubsubCategoryExists(subsubCategory.SubsubcategoryId))
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
            return View(subsubCategory);
        }

        // GET: SubsubCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subsubCategory = await _context.SubsubCategory
                .FirstOrDefaultAsync(m => m.SubsubcategoryId == id);
            if (subsubCategory == null)
            {
                return NotFound();
            }

            return View(subsubCategory);
        }

        // POST: SubsubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subsubCategory = await _context.SubsubCategory.FindAsync(id);
            _context.SubsubCategory.Remove(subsubCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubsubCategoryExists(int id)
        {
            return _context.SubsubCategory.Any(e => e.SubsubcategoryId == id);
        }
    }
}
