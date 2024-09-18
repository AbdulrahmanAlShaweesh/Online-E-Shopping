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
         public DbSet<RoleModel> Roles {get; set;}
         public DbSet<UserModel> Users {get; set;}
         public DbSet<ProductReview> Review {get; set;}
         public DbSet<WishListModel> WishList {get; set;}
         public DbSet<ShoppingCart> Cart {get; set;} 
         public DbSet<ContactModel> Contacts {get; set;} 
         
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

              base.OnModelCreating(modelBuilder);           

            // Explicitly configure the one-to-many relationship between User and Role
            modelBuilder.Entity<UserModel>()
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId)
            .OnDelete(DeleteBehavior.Restrict); 

            // Configure Review-Product relationship with Cascade Delete
            modelBuilder.Entity<ProductReview>()
            .HasOne(r => r.Products)
            .WithMany(p => p.Reviews)
            .HasForeignKey(r => r.ProductId)
            .OnDelete(DeleteBehavior.Cascade); // Delete reviews when a product is deleted

            // Configure Review-User relationship with Cascade Delete
            modelBuilder.Entity<ProductReview>()
            .HasOne(r => r.Users)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade); // Delete reviews when a user is deleted

            modelBuilder.Entity<WishListModel>() 
            .HasOne(r => r.User)
            .WithMany(r => r.WishList)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WishListModel>() 
            .HasOne(r => r.Products)
            .WithMany(r => r.WishLists)
            .HasForeignKey(r => r.ProductId)      // FK inside whishlist for peoduct
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ShoppingCart>() 
            .HasOne(r => r.Users)
            .WithMany(r => r.Cart)
            .HasForeignKey(r => r.UserId)      // FK inside whishlist for peoduct
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductModel>() 
            .HasOne(r => r.Cart)
            .WithMany(r => r.Prodcuts)
            .HasForeignKey(r => r.ShoppingCartId)      // FK inside whishlist for peoduct
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}