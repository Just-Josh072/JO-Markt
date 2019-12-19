﻿using System;
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
    }
}