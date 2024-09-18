using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using onlineEShopping.Models.Enums;

namespace onlineEShopping.Models.Entities
{
    public class OrderModel
    {
        [Key]
        public int OrderId {get; set;}

        public string OrderNumber {get; set;} = string.Empty; 

        public int Quantity {get; set;} 

        public OrderStatus Orders {get; set;} 

        public DateTime OrderedDate {get; set;}

        public ICollection<OrderProduct>? OrderProducts {get; set;} 

        public int UserId {get; set; }
        public UserModel? Users {get; set;}

        public int PaymentId {get; set; }
        public PaymentModel? Payment {get; set;} 
    
        [Required]
        public bool IsCanceled {get; set;} 

    }
}