using ETicaret.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETicaret.Data.Concrete.EfCore
{
    public class ShopContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-5OA1FVG;Database=ShopDb; integrated security=true");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        //fluent api ile conction yani productcategory tablosunun birincil anahtarını bildireceğim
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
            .HasKey(c => new { c.CategoryId, c.ProductId });
        }
    }
}
