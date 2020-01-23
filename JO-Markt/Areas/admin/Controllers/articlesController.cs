using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JOMarkt.Data;
using JOMarkt.Models;

namespace JOMarkt.Areas.admin.Controllers
{
    [Area("admin")]
    public class articlesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public articlesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: admin/articles
        public async Task<IActionResult> Index()
        {
            return View(await _context.articles.ToListAsync());
        }

        // GET: admin/articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articles = await _context.articles
                .FirstOrDefaultAsync(m => m.articlesId == id);
            if (articles == null)
            {
                return NotFound();
            }

            return View(articles);
        }

        // GET: admin/articles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: admin/articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("image,articlesId,Title,Content,PublisherDate,Publisher,IsVisible")] articles articles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(articles);
        }

        // GET: admin/articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articles = await _context.articles.FindAsync(id);
            if (articles == null)
            {
                return NotFound();
            }
            return View(articles);
        }

        // POST: admin/articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("image,articlesId,Title,Content,PublisherDate,Publisher,IsVisible")] articles articles)
        {
            if (id != articles.articlesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!articlesExists(articles.articlesId))
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
            return View(articles);
        }

        // GET: admin/articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articles = await _context.articles
                .FirstOrDefaultAsync(m => m.articlesId == id);
            if (articles == null)
            {
                return NotFound();
            }

            return View(articles);
        }

        // POST: admin/articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articles = await _context.articles.FindAsync(id);
            _context.articles.Remove(articles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool articlesExists(int id)
        {
            return _context.articles.Any(e => e.articlesId == id);
        }
    }
}
