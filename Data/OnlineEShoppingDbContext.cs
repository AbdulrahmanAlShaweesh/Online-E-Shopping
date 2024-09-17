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
        //  public DbSet<SubCategoryModel> SubCategories {get; set;}
    }
}