using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using onlineEShopping.Models.Enums;

namespace onlineEShopping.Models.Entities
{
    public class ProductModel
    {   
        [Key]
        public int ProductId {get; set;}
        [StringLength(100)]
        public string ProductName {get; set;} = string.Empty; 
        [Required]
        public string ProductDescription {get; set;} = string.Empty; 
        [Required]
        public string ProductImage {get; set;} = string.Empty;
        [Required]
        public decimal ProductPrice {get; set;} 
        public int StockQuantity {get; set;}
        public string ProductSize {get; set;} = string.Empty; 
        public ProductColors Colors {get; set;}
        public string CompanyName {get; set;} = string.Empty;
        // public int CategoryId {get; set;} 
        // public CategoryModel? Category {get; set;}
        public int SubCategoryId {get; set;} 
        public SubCategoryModel? SubCategories {get; set;} 
        public int SoldOut {get; set;}     
        public bool IsCustomeSize {get; set;}
        [Required]
        public bool isActive {get; set;} 
        [Required]
        public DateTime CreatedDate {get; set;}
    }
}