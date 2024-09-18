using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineEShopping.Models.Entities
{
    public class OrderProduct
    {
        public int OrderId {get; set;} 
        public OrderModel? Order {get; set;}

        public int ProductId {get; set;} 
        public ProductModel? Product {get; set;}
    }
}