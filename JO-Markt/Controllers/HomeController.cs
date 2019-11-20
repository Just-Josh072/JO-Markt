using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using JOMarkt.Models;
using JOMarkt.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Coma_Supermarkt.Controllers
{
    public class HomeController : Controller
    {
        Product products = new Product();
        List<Product> producten = new List<Product>();
        articles articles = new articles();
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _usermanager;
        Category categories = new Category();

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        //categorien inladen method moet nog even aangemaakt worden, nu wordt telkens hetzelfde hergebruikt, excuus - Omar <3

        public IActionResult CategorieList()
        {
            Categories categories = new Categories();
            categories.categorie = _context.Category.ToList();
            categories.subcategory = _context.subCategory.ToList();
            categories.subsubcategory = _context.SubsubCategory.ToList();
            return View(categories);
        }
        //categorie pagina voor klanten
        public IActionResult Categories()
        {
            Categories categories = new Categories();
            categories.categorie = _context.Category.ToList();
            categories.subcategory = _context.subCategory.ToList();
            categories.subsubcategory = _context.SubsubCategory.ToList();
            return View(categories);
        }
        //subcategorie pagina voor klanten
        public IActionResult Subcategories()
        {
            Categories categories = new Categories();
            categories.categorie = _context.Category.ToList();
            categories.subcategory = _context.subCategory.ToList();
            categories.subsubcategory = _context.SubsubCategory.ToList();
            return View(categories);
        }

        public IActionResult Index()
        {
            List<Product> producten = _context.Product.ToList();
            List<Promotions> promotions = _context.Promotions.ToList();
            List<Product> model = new List<Product>();
            if (producten.Count == 0)
            {
                products.UpdateProducts(_context);
            }

            foreach (var item in promotions)
            {
                Product product = _context.Product.Where(w => w.EAN == item.EAN).First();
                model.Add(product);
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
        public async Task<IActionResult> Xml()
        {
            string LoggedInUser = User.Identity.Name;
            //deliveryslots.UpdateDeliveryslots(_context);
            //categories.UpdateCategory(_context);
            products.UpdateProducts(_context);
            //products.UpdatePromotions(_context);
            //products.LinkPromotions(_context);
            //articles.CreateArticle(_context,"image","Title","Content","Publisher",true);
            return RedirectToAction("Dashboard", "Cms");
        }

        public IActionResult article()
        {
            List<articles> articles = _context.articles.ToList();
            return View(articles);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult DeleteData(string table)
        {
            table = "Products";
            _context.Database.ExecuteSqlCommand("TRUNCATE TABLE [" + table + "]");
            return RedirectToAction("Index");
        }
    }
}