using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JOMarkt.Data;
using JOMarkt.Models;
using System.Xml.Linq;
using System.Xml;

namespace JO_Markt.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Category.Include(c => c.Categories).ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _context.Category
                .FirstOrDefaultAsync(m => m.CategorieId == id);
            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategorieId,Name")] Category categorie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categorie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categorie);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _context.Category.FindAsync(id);
            if (categorie == null)
            {
                return NotFound();
            }
            return View(categorie);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategorieId,Name")] Category categorie)
        {
            if (id != categorie.CategorieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categorie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategorieExists(categorie.CategorieId))
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
            return View(categorie);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _context.Category
                .FirstOrDefaultAsync(m => m.CategorieId == id);
            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categorie = await _context.Category.FindAsync(id);
            _context.Category.Remove(categorie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategorieExists(int id)
        {
            return _context.Category.Any(e => e.CategorieId == id);
        }

        public async Task<IActionResult> LoadXMLCategories()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load("https://supermaco.starwave.nl/api/categories");
       

            XmlNodeList elemList = doc.GetElementsByTagName("Category");
            for (int i = 0; i < elemList.Count; i++)
            {
                Category c = new Category();
                c.Name = (elemList[i].SelectSingleNode("./Name").InnerXml);
                //Console.WriteLine("Name: " + elemList[i].SelectSingleNode("./Name").InnerXml);

                XmlNodeList subcats = elemList[i].SelectNodes("./Subcategory");

                for (int j = 0; j < subcats.Count; j++)
                {
                    SubCategory sc = new SubCategory();
                    sc.Name = (subcats[j].SelectSingleNode("./Name").InnerXml);
                    // Console.WriteLine("--sub: " + subcats[j].SelectSingleNode("./Name").InnerXml);
                    sc.Category = c;

                    XmlNodeList subsubcats = subcats[j].SelectNodes("./Subsubcategory");
                    for (int w = 0; w < subsubcats.Count; w++)
                    {

                        SubsubCategory ssc = new SubsubCategory();
                        ssc.Name = (subsubcats[w].SelectSingleNode("./Name").InnerXml);
                        ssc.Subcategory = sc;
                        // Console.WriteLine("--subsub: " + subsubcats[w].SelectSingleNode("./Name").InnerXml);

                        _context.Add(ssc);
                        // await _context.SaveChangesAsync();
                       // _context.SubsubCategory.AddRange(ssc);
                    }
                   _context.Add(sc);
                    // await _context.SaveChangesAsync();
                    //_context.subCategory.AddRange(sc);
                }
                //  Console.WriteLine("subsub: " + SubCatList[i].SelectSingleNode("./Name").InnerXml);
                _context.Category.Add(c);
               
                

            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));




            //await _context.SaveChangesAsync();






        }

    }
}
