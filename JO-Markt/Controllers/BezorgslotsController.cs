using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JOMarkt.Data;
using JOMarkt.Models;
using System.Xml;
using System.Globalization;

namespace JO_Markt.Controllers
{
    public class BezorgslotsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BezorgslotsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bezorgslots
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bezorgslot.ToListAsync());
        }

        // GET: Bezorgslots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bezorgslot = await _context.Bezorgslot
                .FirstOrDefaultAsync(m => m.BezorgslotId == id);
            if (bezorgslot == null)
            {
                return NotFound();
            }

            return View(bezorgslot);
        }

        // GET: Bezorgslots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bezorgslots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BezorgslotId,Datum,BeginTijd,EindTijd,Prijs")] Bezorgslot bezorgslot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bezorgslot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bezorgslot);
        }

        // GET: Bezorgslots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bezorgslot = await _context.Bezorgslot.FindAsync(id);
            if (bezorgslot == null)
            {
                return NotFound();
            }
            return View(bezorgslot);
        }

        // POST: Bezorgslots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BezorgslotId,Datum,BeginTijd,EindTijd,Prijs")] Bezorgslot bezorgslot)
        {
            if (id != bezorgslot.BezorgslotId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bezorgslot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BezorgslotExists(bezorgslot.BezorgslotId))
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
            return View(bezorgslot);
        }

        // GET: Bezorgslots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bezorgslot = await _context.Bezorgslot
                .FirstOrDefaultAsync(m => m.BezorgslotId == id);
            if (bezorgslot == null)
            {
                return NotFound();
            }

            return View(bezorgslot);
        }

        // POST: Bezorgslots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bezorgslot = await _context.Bezorgslot.FindAsync(id);
            _context.Bezorgslot.Remove(bezorgslot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BezorgslotExists(int id)
        {
            return _context.Bezorgslot.Any(e => e.BezorgslotId == id);
        }

        public async Task<IActionResult> LoadBezorg()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load("https://supermaco.starwave.nl/api/deliveryslots");
            XmlNodeList elemList = xdoc.GetElementsByTagName("Deliveryslot");

            for (int i = 0; i < elemList.Count; i++)
            {
                XmlNodeList Timeslots = elemList[i].SelectNodes("./Timeslots");
                for (int y = 0; y < Timeslots.Count; y++)
                {
                    XmlNodeList Timeslot = Timeslots[y].SelectNodes("./Timeslot");
                    for (int x = 0; x < Timeslot.Count; x++)
                    {
                        Bezorgslot b = new Bezorgslot(); b.Datum = Convert.ToDateTime(elemList[i].SelectSingleNode("./Date").InnerXml);
                        b.BeginTijd = Convert.ToDateTime(Timeslot[x].SelectSingleNode("./StartTime").InnerXml);
                        b.EindTijd = Convert.ToDateTime(Timeslot[x].SelectSingleNode("./EndTime").InnerXml);
                        b.Prijs = Convert.ToDouble(Timeslot[x].SelectSingleNode("./Price").InnerXml, CultureInfo.InvariantCulture);
                        _context.Add(b);
                    }
                }
            }
            await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index));
        }
    }
}
