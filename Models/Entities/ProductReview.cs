using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace onlineEShopping.Models.Entities
{
    public class ProductReview
    {
        [Key]
        public int ReviewId {get; set;}
        
        public string ProductName {get; set;} = string.Empty; 

        [Required] 
        public int Rating {get; set;} 

        public string Comment {get; set;} = string.Empty; 

        [Required]
        public DateTime ReviewDate {get; set;}

        public int UserId {get; set;}
        public UserModel? Users {get; set;}

        public int ProductId {get; set;}
        public ProductModel? Products {get; set;}

        
    }
}