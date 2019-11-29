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

namespace JO_Markt.Controllers
{
    public class SubCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SubCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.subCategory.ToListAsync());
        }

        // GET: SubCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategory = await _context.subCategory
                .FirstOrDefaultAsync(m => m.SubcategoryId == id);
            if (subCategory == null)
            {
                return NotFound();
            }

            return View(subCategory);
        }

        // GET: SubCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SubCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubcategoryId,Name")] SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subCategory);
        }

        // GET: SubCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategory = await _context.subCategory.FindAsync(id);
            if (subCategory == null)
            {
                return NotFound();
            }
            return View(subCategory);
        }

        // POST: SubCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubcategoryId,Name")] SubCategory subCategory)
        {
            if (id != subCategory.SubcategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubCategoryExists(subCategory.SubcategoryId))
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
            return View(subCategory);
        }

        // GET: SubCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategory = await _context.subCategory
                .FirstOrDefaultAsync(m => m.SubcategoryId == id);
            if (subCategory == null)
            {
                return NotFound();
            }

            return View(subCategory);
        }

        // POST: SubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subCategory = await _context.subCategory.FindAsync(id);
            _context.subCategory.Remove(subCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubCategoryExists(int id)
        {
            return _context.subCategory.Any(e => e.SubcategoryId == id);
        }

        //public async Task<IActionResult> LoadXMLSubCategories()
        //{

        //    XmlDocument doc = new XmlDocument();
        //    doc.Load("https://supermaco.starwave.nl/api/categories");


        //    XmlNodeList elemList = doc.GetElementsByTagName("Category");
        //    for (int i = 0; i < elemList.Count; i++)
        //    {
        //        Category c = new Category();
        //        c.Name = (elemList[i].SelectSingleNode("./Name").InnerXml);
        //        //Console.WriteLine("Name: " + elemList[i].SelectSingleNode("./Name").InnerXml);

        //        XmlNodeList subcats = elemList[i].SelectNodes("./Subcategory");

        //        for (int j = 0; j < subcats.Count; j++)
        //        {
        //            SubCategory sc = new SubCategory();
        //            sc.Name = (subcats[j].SelectSingleNode("./Name").InnerXml);
        //            // Console.WriteLine("--sub: " + subcats[j].SelectSingleNode("./Name").InnerXml);

        //            XmlNodeList subsubcats = subcats[j].SelectNodes("./Subsubcategory");
        //            for (int w = 0; w < subsubcats.Count; w++)
        //            {
        //                SubsubCategory ssc = new SubsubCategory();
        //                ssc.Name = (subsubcats[w].SelectSingleNode("./Name").InnerXml);
        //                // Console.WriteLine("--subsub: " + subsubcats[w].SelectSingleNode("./Name").InnerXml);

        //                //_context.Add(ssc);
        //                // await _context.SaveChangesAsync();
        //                // _context.SubsubCategory.AddRange(ssc);
        //            }
        //            // _context.Add(sc);
        //            // await _context.SaveChangesAsync();
        //            //_context.subCategory.AddRange(sc);
        //        }
        //        //  Console.WriteLine("subsub: " + SubCatList[i].SelectSingleNode("./Name").InnerXml);
        //        _context.Category.AddRange(c);




        //        await _context.SaveChangesAsync();
        //    }
        //    return RedirectToAction(nameof(Index));




        //    //await _context.SaveChangesAsync();






        //}
    }
}
