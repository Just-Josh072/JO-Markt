using JOMarkt.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOMarkt.Data
{
    public class Seed
    {

        public static void SeedUser(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
             if (roleManager.FindByNameAsync("Admin").Result == null)
            {
                IdentityRole role = new IdentityRole { Name = "Admin" };
                roleManager.CreateAsync(role).Wait();

            }
            if (userManager.FindByEmailAsync("admin@admin.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com"
                };


                IdentityResult result = userManager.CreateAsync(user, "Password123!").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();

                }
            }
            if (roleManager.FindByNameAsync("WebManager").Result == null)
            {
                IdentityRole role = new IdentityRole { Name = "WebManager" };
                roleManager.CreateAsync(role).Wait();

            }
            if (userManager.FindByEmailAsync("Web@Web.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "Web@Web.com",
                    Email = "Web@Web.com"
                };


                IdentityResult result = userManager.CreateAsync(user, "Password123!").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "WebManager").Wait();

                }
            }
        }
    }
}
