using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace onlineEShopping.Models.Entities
{
    public class ShoppingCart
    {
        [Key]
        public int CartId {get; set;} 
        public int Quantity {get; set;} 

         public ICollection<ProductModel>? Prodcuts {get; set;}
         
         public int UserId {get; set;}
         public UserModel? Users {get; set;}
         
         public DateTime AddedDate {get; set;}
    }
}