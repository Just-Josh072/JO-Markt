using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using JOMarkt.Models;

namespace JOMarkt.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<JOMarkt.Models.Product> Product { get; set; }
        public DbSet<JOMarkt.Models.Category> Category { get; set; }
    }
}
