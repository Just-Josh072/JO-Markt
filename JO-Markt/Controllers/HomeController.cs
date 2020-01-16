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
using System.Xml.Linq;
using System;
using System.Globalization;
using System.Xml;

namespace JOMarkt.Controllers
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

        //public IActionResult CategorieList()
        //{
        //    Categories categories = new Categories();
        //    categories.categorie = _context.Category.ToList();
        //    categories.subcategory = _context.SubCategory.ToList();
        //    categories.subsubcategory = _context.SubsubCategory.ToList();
        //    return View(categories);
        //}
        ////categorie pagina voor klanten
        //public IActionResult Categories()
        //{
        //    Categories categories = new Categories();
        //    categories.categorie = _context.Category.ToList();
        //    categories.subcategory = _context.SubCategory.ToList();
        //    categories.subsubcategory = _context.SubsubCategory.ToList();
        //    return View(categories);
        //}
        ////subcategorie pagina voor klanten
        //public IActionResult Subcategories()
        //{
        //    Categories categories = new Categories();
        //    categories.categorie = _context.Category.ToList();
        //    categories.subcategory = _context.SubCategory.ToList();
        //    categories.subsubcategory = _context.SubsubCategory.ToList();
        //    return View(categories);
        //}

        public IActionResult Index()
        {

            List<Promotions> model = new List<Promotions>();




            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
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

        public async Task<IActionResult> LoadXMLPromo()
        {
            XElement xelement = XElement.Load("https://supermaco.starwave.nl/api/promotions");
            IEnumerable<XElement> promo = xelement.Elements();


            foreach (var promotion in promo)
            {
                Product p = new Product();
                Promotions pro = new Promotions();

                pro.Title = (promotion.Element("Title").Value);
                pro.Discount_Id = Convert.ToInt32(promotion.Element("Discount_Id"));
                // pro.EAN = (promotion.Element("EAN").Value);
                pro.DiscountPrice = Convert.ToDouble(promotion.Element("DiscountPrice").Value, CultureInfo.InvariantCulture);
                pro.ValidUntil = Convert.ToDateTime(promotion.Element("ValidUntil"));

                // CultureInfo.InvariantCulture);



                _context.Add(pro);

                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        

    }
}
