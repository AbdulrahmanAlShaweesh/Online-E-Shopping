using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace onlineEShopping.Models.Entities
{
    public class SubCategoryModel
    {
        [Key]
        public int SubCategoryId {get; set;} 
        [StringLength(100, ErrorMessage ="The Name's Length between 0-100")]
        public string SubCategoryName {get; set;} = string.Empty;
        public bool isActive {get; set;} 

        public int CategoryId {get; set;}

        public CategoryModel? Category {get; set;}    // navigation refferance

        public DateTime CreatedDate {get; set;}
    }
}