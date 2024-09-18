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
            modelBuilder.Entity<SubCategoryModel>()
                .HasOne(s => s.Category)
                .WithMany(c => c.Subcategories)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);     // Configuring ON DELETE CASCADE
            base.OnModelCreating(modelBuilder);

    //         // Configuring ON DELETE CASCADE FOR Product
             modelBuilder.Entity<ProductModel>()
                .HasOne(s => s.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);     // Configuring ON DELETE CASCADE
            base.OnModelCreating(modelBuilder);

            // Configuring ON DELETE CASCADE FOR Product
            //  modelBuilder.Entity<ProductModel>()
            //     .HasOne(s => s.SubCategories)
            //     .WithMany(c => c.Products)
            //     .HasForeignKey(s => s.SubCategoryId)
            //     .OnDelete(DeleteBehavior.Cascade);     // Configuring ON DELETE CASCADE
            // base.OnModelCreating(modelBuilder);
        }
    
    }
}