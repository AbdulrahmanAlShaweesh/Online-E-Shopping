using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace onlineEShopping.Models.Entities
{
    public class CategoryModel
    {
        [Key]
        public int CategoryId {get; set;} 

        [StringLength(100, MinimumLength=10, ErrorMessage = "The name must be between 10 and 100 characters.")]
        public string CategoryName {get; set;} = string.Empty; 

        public string CategoryImage {get; set;} = string.Empty; 
        public bool isActive {get; set;}
        public DateTime CreatedDate {get; set;}
        public ICollection<SubCategoryModel> Subcategories {get; set;}

    }
}