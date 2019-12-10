using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using JOMarkt.Models;
using Microsoft.AspNetCore.Identity;

namespace JOMarkt.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<JOMarkt.Models.Product> Product { get; set; }
        public DbSet<JOMarkt.Models.Category> Category { get; set; }
        public DbSet<JOMarkt.Models.SubCategory> SubCategory { get; set; }
        public DbSet<JOMarkt.Models.SubsubCategory> SubsubCategory { get; set; }
        public DbSet<JOMarkt.Models.articles> articles { get; set; }
        public DbSet<Promotions> Promotions { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
      
    }
}
