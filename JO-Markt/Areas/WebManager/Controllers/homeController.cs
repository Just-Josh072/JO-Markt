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

namespace JOMarkt.Areas.WebManager.Controllers
{
    public class homeController : Controller
    {
        ApplicationDbContext _context;
        
        RoleManager<IdentityRole> _roleManager;

        public homeController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        

        }

        [Area("WebManager")]

        [Authorize(Roles = "WebManager")]

       

        public IActionResult Index()
        {
         
         
            return View();
        }
    }
}