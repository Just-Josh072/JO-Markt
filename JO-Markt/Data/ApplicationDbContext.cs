using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using JOMarkt.Models;
using Microsoft.AspNetCore.Identity;

namespace JOMarkt.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
       
            builder.Entity<Product>().
                HasOne(p => p.Category).
                WithMany(c => c.Product).
                HasForeignKey(p => p.CategoryId).
                OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Product>().
            HasOne(p => p.Subcategory).
            WithMany(c => c.Products).
            HasForeignKey(p => p.SubcategoryId).
            OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(builder);

        }
        public DbSet<JOMarkt.Models.Product> Product { get; set; }
        public DbSet<JOMarkt.Models.Bezorgslot> Bezorgslots { get; set; }
        public DbSet<JOMarkt.Models.Category> Category { get; set; }
        public DbSet<JOMarkt.Models.SubCategory> SubCategory { get; set; }
        public DbSet<JOMarkt.Models.SubsubCategory> SubsubCategory { get; set; }
        public DbSet<JOMarkt.Models.articles> articles { get; set; }
        public DbSet<Promotions> Promotions { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<JOMarkt.Models.Deliveryslots> Deliveryslots { get; set; }

    }
}
