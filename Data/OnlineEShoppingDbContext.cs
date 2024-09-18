using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design.Internal;
using onlineEShopping.Models.Entities;

namespace onlineEShopping.Data
{
    public class OnlineEShoppingDbContext : DbContext
    {
         public OnlineEShoppingDbContext(DbContextOptions<OnlineEShoppingDbContext> options) : base (options)
         {

         }

         public DbSet<CategoryModel> Categories {get; set;}
         public DbSet<SubCategoryModel> SubCategories {get; set;}
         public DbSet<ProductModel> Products {get; set;}


         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             modelBuilder.Entity<CategoryModel>()
            .HasMany(c => c.Subcategories)
            .WithOne(sc => sc.Category)
            .HasForeignKey(sc => sc.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SubCategoryModel>()
            .HasMany(sc => sc.Products)
            .WithOne(p => p.SubCategories)
            .HasForeignKey(p => p.SubCategoryId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}