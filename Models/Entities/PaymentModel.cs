using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace onlineEShopping.Models.Entities
{
    public class PaymentModel
    {
        [Key]
        public int PaymentId {get; set;} 

        public string PaymentName {get; set;} = string.Empty; 

        [StringLength(50)]
        public string CardNumber {get; set;} = string.Empty; 

        [StringLength(50)]
        public string ExpireDate {get; set;} = string.Empty; 

        public int CvvNumber {get; set;} 

        public string EmailAddress {get; set;} = string.Empty; 

        public string PaymentMode {get; set;} = string.Empty; 

        public OrderModel? Order {get; set;}
    }
}