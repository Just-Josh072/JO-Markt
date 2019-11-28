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
using System.Globalization;

namespace JO_Markt.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Product.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public async Task<IActionResult> Detailpagina(int? id)
        {
            MultipleProducts multipleProducts = new MultipleProducts();
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);

            List<Product> product = _context.Product.Where(w => w.Id == id).ToList();
            List<Product> Related = _context.Product.Where(w => w.Subcategory == products.Subcategory).ToList();
            List<Product> RelatedCategory = _context.Product.Where(w => w.Category == products.Category).ToList();
            List<Product> RandomRelated = new List<Product>();
            List<Product> RandomRelatedCategory = new List<Product>();

            int RelatedItems = 0;
            if (Related.Count <= 3)
            {
                RelatedItems = Related.Count;
            }
            else
            {
                RelatedItems = 4;
            }


            List<int> number = new List<int>();
            bool NumberCheck = false;
            int check = products.Id;
            number.Add(check);
            //products.LoadProductAndRelated(RelatedItems, NumberCheck, Related, RandomRelated, number);
            //products.LoadProductCategory(RelatedItems, NumberCheck, RelatedCategory, RandomRelatedCategory, number);

            multipleProducts.Product = product;
            multipleProducts.RelatedProducts = RandomRelated;
            multipleProducts.RelatedCategory = RandomRelatedCategory;

            if (products == null)
            {
                return NotFound();
            }

            foreach (var item in Related)
            {
                Console.WriteLine("Id : " + item.Id);
            }

            Console.WriteLine("Foreach " + number.Count);
            foreach (var item in number)
            {
                Console.WriteLine("Number in list : " + item);
            }

            return View(multipleProducts);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EAN,Title,Brand,Shortdescription,Fulldescription,Image,Weight,Price,Category,Subcategory")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", product.Id);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EAN,Title,Brand,Shortdescription,Fulldescription,Image,Weight,Price,Category,Subcategory")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }


        public async Task<IActionResult> LoadXML()
        {
            XElement xelement = XElement.Load("http://supermaco.starwave.nl/api/products");
            IEnumerable<XElement> products = xelement.Elements();

            foreach (var product in products)
            {
                Product p = new Product();
                p.EAN = (product.Element("EAN").Value);
                p.Title = (product.Element("Title").Value);
                p.Brand = (product.Element("Brand").Value);
                p.Shortdescription = (product.Element("Shortdescription").Value);
                p.Fulldescription = (product.Element("Fulldescription").Value);
                p.Image = (product.Element("Image").Value);
                p.Weight = (product.Element("Weight").Value);
                p.Price = Convert.ToDouble(product.Element("Price"),CultureInfo.InvariantCulture);

                p.Category = (product.Element("Category").Value);
                p.Subcategory = (product.Element("Subcategory").Value);
                p.Subsubcategory = (product.Element("Subsubcategory").Value);


                _context.Add(p);

                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
