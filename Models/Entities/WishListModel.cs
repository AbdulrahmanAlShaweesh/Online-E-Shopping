using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace onlineEShopping.Models.Entities
{
    public class WishListModel
    {
        [Key]
        public int WishListId {get; set;} 

        // user one-to-many  
        public int UserId {get; set;} 
        public UserModel? User {get; set;}

        // products one-to-many ...
        public int ProductId {get; set;} 
        public ProductModel? Products {get; set;}

        public DateTime CreatedDate {get; set;}
    }
}

