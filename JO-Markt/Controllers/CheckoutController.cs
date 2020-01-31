using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using JOMarkt.Data;
using JOMarkt.Models;
using Microsoft.AspNetCore.Authorization;

namespace JOMarkt.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public CheckoutController(ApplicationDbContext context, UserManager<ApplicationUser> userMan)
        {
            _context = context;
            _userManager = userMan;
        }
        [HttpGet]
        public IActionResult Index()
        {
            CheckoutViewModel cvm = new CheckoutViewModel();

            List<CartItem> cart = new List<CartItem>();

            string cartString = HttpContext.Session.GetString("cart");
            if (cartString != null)
                cart = JsonConvert.DeserializeObject<List<CartItem>>(cartString);


            List<CartItemViewModel> cartvm = new List<CartItemViewModel>();

            double totalPrice = 0;
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

                totalPrice += ci.Amount * p.Price;

                cartvm.Add(civm);
            }

            cvm.CartItems = cartvm;
            cvm.TotalPrice = totalPrice;

            return View(cvm);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CheckoutViewModel model)
        {
            Order order = new Order();
            ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);

            order.Address = model.Adres;
            order.City = model.Stad;
            order.Name = model.Naam;

            order.User = user;
            order.OrderLines = new List<OrderLine>();

            List<CartItem> cart = new List<CartItem>();

            string cartString = HttpContext.Session.GetString("Cart");
            if (cartString != null)
                cart = JsonConvert.DeserializeObject<List<CartItem>>(cartString);

            foreach (CartItem ci in cart)
            {
                Product p = _context.Product.Find(ci.ProductId);
                OrderLine po = new OrderLine();
                po.Amount = ci.Amount;
                po.Price = p.Price;
                po.ProductId = ci.ProductId;
                order.OrderLines.Add(po);

                try
                {
                    _context.Add(order);
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    return StatusCode(500);
                }

            }

            return View("Confirm");
        }

    }
}