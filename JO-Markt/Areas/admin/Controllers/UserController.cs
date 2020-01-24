using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JOMarkt.Models;
using JOMarkt.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace JO_Markt.Controllers
{
    [Area("admin")]

    [Authorize(Roles = "Admin")]

    public class UserController : Controller
    {

        private readonly JOMarkt.Data.ApplicationDbContext _context;
       

        //private readonly ApplicationDbContext _context;
        
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly UserManager<ApplicationUser> _userManager;




        public UserController(JOMarkt.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: Users
        public async Task<IActionResult> Index()
        {
            List<ApplicationUser> list = new List<ApplicationUser>();
            foreach (var user in _userManager.Users)
            {
                ApplicationUser uvm = new ApplicationUser();
                uvm.Email = user.Email;
                uvm.Voornaam = user.Voornaam;
                uvm.Geboortedatum = user.Geboortedatum;
                uvm.Achternaam = user.Achternaam;
                uvm.Straat = user.Straat;
                uvm.Postcode = user.Postcode;
                uvm.Geslacht = user.Geslacht;
                uvm.Role = user.Role;

                uvm.Id = user.Id;



                list.Add(uvm);
            }
            return View(list);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Setadminrole(string id)
        {
            string loggedinuser = User.Identity.Name;
            ApplicationUser CurrentUser = _context.Users.Where(w => w.Email == id).First();

            if (User.Identity.Name == CurrentUser.Email)
            {
                return RedirectToAction("User", "index");
            }
            CurrentUser.Role = "Admin";
            await _userManager.AddToRoleAsync(CurrentUser, CurrentUser.Role);
            _context.Update(CurrentUser);
            _context.SaveChanges();
            return RedirectToAction("Admin", "Users");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Setmemberrole(string id)
        {
            string loggedinuser = User.Identity.Name;
            ApplicationUser CurrentUser = _context.Users.Where(w => w.Email == id).First();

            if (User.Identity.Name == CurrentUser.Email)
            {
                return RedirectToAction("index");
            }
            CurrentUser.Role = "User";
            await _userManager.AddToRoleAsync(CurrentUser, CurrentUser.Role);
            _context.Update(CurrentUser);
            _context.SaveChanges();
            return RedirectToAction("User", "index");
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Setauthorrole(string id)
        {
            string loggedinuser = User.Identity.Name;
            ApplicationUser CurrentUser = _context.Users.Where(w => w.Email == id).First();

            if (User.Identity.Name == CurrentUser.Email)
            {
                return RedirectToAction("User", "index");
            }

            string roleName = "WebManager";
            await _userManager.AddToRoleAsync(CurrentUser, roleName);
            CurrentUser.Role = "WebManager";
            _context.Update(CurrentUser);
            _context.SaveChanges();
            return RedirectToAction("User", "index");
        }
    }
}