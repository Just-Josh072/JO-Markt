using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JOMarkt.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using JOMarkt.Models;
using System.Collections;

namespace JOMarkt.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _context;
        
        RoleManager<IdentityRole> _roleManager;

        public HomeController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        

        }

        [Area("Admin")]

        [Authorize(Roles = "Admin")]

       

        public IActionResult Index()
        {
         
         
            return View();
        }
    }
}