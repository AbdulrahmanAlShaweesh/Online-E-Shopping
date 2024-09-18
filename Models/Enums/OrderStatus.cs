using System.ComponentModel.DataAnnotations;

namespace onlineEShopping.Models.Enums
{
    public enum OrderStatus
    {
        [Display(Name = "Order Pending")]
        Pending, 

        [Display(Name = "Order Processing")]
        Processing, 
        [Display(Name = "Order Completed")]
        Completed, 
        
        [Display(Name = "Order Canceled")]
        Canceled,
    }
}