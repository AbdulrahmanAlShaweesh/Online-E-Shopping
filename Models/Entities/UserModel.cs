using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace onlineEShopping.Models.Entities
{
    public class UserModel
    {
        [Key]
        public int UsrId { get; set; }

        [StringLength(100)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string UserEmail { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string UserMobileNumber { get; set; } = string.Empty;

        public string UserAddress { get; set; } = string.Empty;

        public string UserPostCode { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string UserImageUrl { get; set; } = string.Empty;

        // Foreign key for Role
        public int RoleId {get; set;}
        public RoleModel? Role { get; set; } // Not nullable, unless allowed
        
        [Required]
        public DateTime CreatedDate { get; set; }

        public ICollection<ProductReview>? Reviews {get; set;}

        public ICollection<WishListModel>? WishList {get; set;}

        public ICollection<ShoppingCart>? Cart {get; set;}
    }
}
