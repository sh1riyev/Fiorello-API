using System;
using System.Reflection;
using Fiorello_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_API.Data
{
	public class AppDbContext : DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<Info> Infos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}

