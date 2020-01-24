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
    public class DeliveryslotsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeliveryslotsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Deliveryslots
        public async Task<IActionResult> Index()
        {
            return View(await _context.Deliveryslots.ToListAsync());
        }

        // GET: Deliveryslots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryslots = await _context.Deliveryslots
                .FirstOrDefaultAsync(m => m.DeliveryslotId == id);
            if (deliveryslots == null)
            {
                return NotFound();
            }

            return View(deliveryslots);
        }

        // GET: Deliveryslots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Deliveryslots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeliveryslotId,Date,StartTime,EndTime,Price,IsChecked")] Deliveryslots deliveryslots)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deliveryslots);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deliveryslots);
        }

        // GET: Deliveryslots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryslots = await _context.Deliveryslots.FindAsync(id);
            if (deliveryslots == null)
            {
                return NotFound();
            }
            return View(deliveryslots);
        }

        // POST: Deliveryslots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeliveryslotId,Date,StartTime,EndTime,Price,IsChecked")] Deliveryslots deliveryslots)
        {
            if (id != deliveryslots.DeliveryslotId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deliveryslots);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryslotsExists(deliveryslots.DeliveryslotId))
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
            return View(deliveryslots);
        }

        // GET: Deliveryslots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryslots = await _context.Deliveryslots
                .FirstOrDefaultAsync(m => m.DeliveryslotId == id);
            if (deliveryslots == null)
            {
                return NotFound();
            }

            return View(deliveryslots);
        }

        // POST: Deliveryslots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deliveryslots = await _context.Deliveryslots.FindAsync(id);
            _context.Deliveryslots.Remove(deliveryslots);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryslotsExists(int id)
        {
            return _context.Deliveryslots.Any(e => e.DeliveryslotId == id);
        }
        public async Task<IActionResult> LoadXml()
        {
            XmlDocument xdoc = new XmlDocument(); xdoc.Load("https://supermaco.starwave.nl/api/deliveryslots");    
            XmlNodeList elemList = xdoc.GetElementsByTagName("Deliveryslot");             for (int i = 0; i < elemList.Count; i++)       
            {                 XmlNodeList Timeslots = elemList[i].SelectNodes("./ Timeslots");        
                for (int y = 0; y < Timeslots.Count; y++)              
                {                     XmlNodeList Timeslot = Timeslots[y].SelectNodes("./ Timeslot");    
                    for (int x = 0; x < Timeslot.Count; x++)                 
                    {
                        Deliveryslots d = new Deliveryslots();      
                        d.Date = elemList[i].SelectSingleNode("./ Date").InnerXml;   
                        d.StartTime = Timeslot[x].SelectSingleNode("./ StartTime").InnerXml; 
                        d.EndTime = Timeslot[x].SelectSingleNode("./ EndTime").InnerXml;
                        d.Price = Convert.ToDouble(Timeslot[x].SelectSingleNode("./ Price").InnerXml, CultureInfo.InvariantCulture);                 
                        _context.Add(d);                                                    
                    }               
                }           
            }               
                        await _context.SaveChangesAsync();     
                        return RedirectToAction(nameof(Index));        
        }
    }
}
