using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JOMarkt.Data;
using JOMarkt.Models;
using System.Xml.Linq;
using System.Globalization;
using Newtonsoft.Json;


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
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Product.ToListAsync());
        //}

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var product = _context.Product
               .Where(sc => sc.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        public async Task<IActionResult> Index(string searchString)
        {
            var products = from m in _context.Product
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Title.Contains(searchString));
            }

            return View(await products.ToListAsync());
        }
        public async Task<IActionResult> detailss(string searchString)
        {
            var products = from m in _context.Product
                           select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Title.Contains(searchString));
            }

            return View(await products.ToListAsync());
        }
        public async Task<IActionResult> Detailpagina(int? id)
        {
            MultipleProducts multipleProducts = new MultipleProducts();
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);

           
           // List<Product> Related = _context.Product.Where(w => w.Subcategory == product.Subcategory).ToList();
           // List<Product> RelatedCategory = _context.Product.Where(w => w.Category == product.Category).ToList();
            List<Product> RandomRelated = new List<Product>();
            List<Product> RandomRelatedCategory = new List<Product>();

            int RelatedItems = 0;
            //if (Related.Count <= 3)
            //{
            //    RelatedItems = Related.Count;
            //}
            //else
            //{
            //    RelatedItems = 4;
            //}


            List<int> number = new List<int>();
            bool NumberCheck = false;
            int check = product.Id;
            number.Add(check);
            //products.LoadProductAndRelated(RelatedItems, NumberCheck, Related, RandomRelated, number);
            //products.LoadProductCategory(RelatedItems, NumberCheck, RelatedCategory, RandomRelatedCategory, number);

            multipleProducts.Product = product;
            multipleProducts.RelatedProducts = RandomRelated;
            multipleProducts.RelatedCategory = RandomRelatedCategory;

            if (product == null)
            {
                return NotFound();
            }

            //foreach (var item in Related)
            //{
            //    Console.WriteLine("Id : " + item.Id);
            //}

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

       
       
        public async Task<IActionResult> LoadXML()
        {
            XElement xelement = XElement.Load("https://supermaco.starwave.nl/api/products");
            IEnumerable<XElement> products = xelement.Elements();

            var subcategories = _context.SubCategory.ToList();
            var categories = _context.Category.ToList();

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
                p.Price = Convert.ToDouble(product.Element("Price").Value,CultureInfo.InvariantCulture);

                p.Category = (categories.FirstOrDefault(sc => sc.Name == product.Element("Category").Value.Trim()));
                p.Subcategory = (subcategories.FirstOrDefault(sc => sc.Name == product.Element("Subcategory").Value.Trim()));
             //   p.Subcategory = (product.Element("Subcategory").Value);
             //   p.Subsubcategory = (product.Element("Subsubcategory").Value);


                _context.Add(p);

                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteData(string table)
        {
            table = "Products";
            _context.Database.ExecuteSqlCommand("TRUNCATE TABLE [" + table + "]");
            return RedirectToAction("Index");
        }




        //public IActionResult AddToCart(int id)
        //{
        //    List<CartItem> cart = new List<CartItem>();

        //    string cartString = HttpContext.Session.GetString("cart");

        //    if (cartString != null)
        //        cart = JsonConvert.DeserializeObject<List<CartItem>>(cartString);


        //    CartItem item = new CartItem();
        //    CartItem item2 = cart.Find(ci => ci.ProductId == id);

        //    if (item2 != null)
        //    {
        //        item2.Amount++;
        //    }
        //    else
        //    {
        //        cart.Add(item);
        //    }

        //    cartString = JsonConvert.SerializeObject(cart);
        //    HttpContext.Session.SetString("cart", cartString);

        //    return RedirectToAction("index");
        //}

        public IActionResult AddToCart(int id)
        {
            List<CartItem> cart = new List<CartItem>();

            string cartString = HttpContext.Session.GetString("cart");
            if (cartString != null)
                cart = JsonConvert.DeserializeObject<List<CartItem>>(cartString);


            CartItem item = new CartItem
            {
                Amount = 1,
                ProductId = id

            };
            CartItem item2 = cart.Find(c => c.ProductId == id);
            if (item2 != null)
            {
                item2.Amount++;
            }
            else
            {
                cart.Add(item);
            }
            cartString = JsonConvert.SerializeObject(cart);
            HttpContext.Session.SetString("cart", cartString);

            TempData["Message"] = "Success";

            return RedirectToAction("index");
        }

       
        public IActionResult Cart()
        {
            List<CartItem> cart = new List<CartItem>();

            string cartString = HttpContext.Session.GetString("cart");
            if (cartString != null)
                cart = JsonConvert.DeserializeObject<List<CartItem>>(cartString);


            List<CartItemViewModel> cartvm = new List<CartItemViewModel>();

            ViewBag.totalAmount = 0;

            foreach (CartItem ci in cart)
            {
                CartItemViewModel civm = new CartItemViewModel();

                civm.ProductId = ci.ProductId;
                civm.Amount = ci.Amount;

                Product p = _context.Product.Find(ci.ProductId);

                 civm.Name = p.Title;
                civm.Price = p.Price;
                civm.ImageUrl = p.Image;
                ViewBag.totalAmount += civm.Amount;

                cartvm.Add(civm);
            }


            return View(cartvm);
        }


        public IActionResult Delete(int id)
        {
            List<CartItem> cart = new List<CartItem>();

            string cartString = HttpContext.Session.GetString("cart");
            if (cartString != null)
                cart = JsonConvert.DeserializeObject<List<CartItem>>(cartString);
            
            CartItem item = cart.Find(c => c.ProductId == id);
            cart.Remove(item);

            cartString = JsonConvert.SerializeObject(cart);
            HttpContext.Session.SetString("cart", cartString);

            return RedirectToAction("Cart");
        }

        public IActionResult IncreaseAmount(int ProductId, [Bind("Amount, ProductId")] CartItemViewModel civm)
        {
            List<CartItem> cart = new List<CartItem>();

            string cartString = HttpContext.Session.GetString("cart");
            if (cartString != null)
                cart = JsonConvert.DeserializeObject<List<CartItem>>(cartString);


            CartItem item = cart.Find(c => c.ProductId == ProductId);
            item.Amount = civm.Amount;


            cartString = JsonConvert.SerializeObject(cart);
            HttpContext.Session.SetString("cart", cartString);

            return RedirectToAction("Cart");
        }


    }
}
