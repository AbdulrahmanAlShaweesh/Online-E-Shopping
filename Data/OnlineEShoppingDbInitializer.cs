using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Humanizer;
using onlineEShopping.Models.Entities;
using onlineEShopping.Models.Enums;

namespace onlineEShopping.Data
{
    public class OnlineEShoppingDbInitializer
    {
        public  static void Seed(IServiceProvider builder) {
            using (var applicationServices = builder.CreateScope()){
                
                var context = applicationServices.ServiceProvider.GetRequiredService<OnlineEShoppingDbContext>();

                context.Database.EnsureCreated(); 

                // Cart
                if(!context.Cart.Any()){
                    
                    var Cart1 = new ShoppingCart {
                        Quantity = 2, AddedDate = new DateTime(2024, 9, 21, 14, 30, 0), 
                    };

                    context.Cart.AddRange(Cart1);
                    context.SaveChanges();
                }

                // .................................. Category ...................... 
                if(!context.Categories.Any()){
                    var Category1 = new CategoryModel {
                        CategoryName = "Electronics", CategoryImage = "https://www.codrey.com/wp-content/uploads/2017/12/Consumer-Electronics.png", isActive = true, CreatedDate = new DateTime(2024, 9, 21, 14, 30, 0),
                    };

                    var Category2 = new CategoryModel {
                        CategoryName = "Grocery", CategoryImage = "https://thumbs.dreamstime.com/z/busy-day-local-grocery-vibrant-bustling-supermarket-scene-image-captures-hustle-bustle-store-customers-all-332683778.jpg", isActive = true, CreatedDate = new DateTime(2024, 9, 21, 14, 30, 0),
                    };

                    context.Categories.AddRange(Category1, Category2);
                    context.SaveChanges();
                }

                // ........................... Contacts ........................
                if(!context.Contacts.Any()){
                    var contact1 = new ContactModel {
                        ContactName = "Abdulrahman Ibraheem", ContactEmail = "abdulrahmanibraheem@gmail.com", Subject = "Product Inquiry", Messages = "Hi, I’m interested in knowing more about your latest laptop models. Can you provide specifications and availability?", CreatedDate = new DateTime(2024, 9, 21, 14, 30, 0),
                    };
                    var contact2 = new ContactModel {
                        ContactName = "Sarah Nader", ContactEmail = "sarahnader2023@gmail.com", Subject = "Login Issues", Messages = "I’m having trouble logging into my account. I’ve tried resetting my password, but I still can’t access my account.", CreatedDate = new DateTime(2024, 9, 21, 14, 30, 0),
                    };

                    var contact3 = new ContactModel {
                        ContactName = "Ahmed Salah", ContactEmail = "ahmedsaleh2323@gmail.com", Subject = "Feedback on your service", Messages = "I recently used your service and wanted to provide some feedback. The website is user-friendly, but I had issues with payment processing.", CreatedDate = new DateTime(2024, 9, 21, 14, 30, 0),
                    };

                    context.Contacts.AddRange(contact1, contact2, contact3);
                    context.SaveChanges();
                }

                // .............................. Product .....................
                if(!context.Products.Any()){
                    var product1 = new ProductModel {
                        ProductName = "Laptop",ProductDescription = "This is a new Hp Laprotp", ProductImage = "https://www.hp.com/content/dam/sites/worldwide/personal-computers/consumer/laptops-and-2-in-1s/new/colorways/HP_15.6_Laptop_Intel_Natural_Silver@2x.jpg",
                        ProductPrice = 34534, StockQuantity = 3, ProductSize = "16 Inches", Colors =  new List<ProductColors>{ProductColors.Black, ProductColors.White, ProductColors.Brown,}, 
                        CompanyName = "Hp", SoldOut = 2, IsCustomeSize = true, isActive = true, CreatedDate =  new DateTime(2024, 9, 21, 14, 30, 0), 
                    };

                    var product2 = new ProductModel {
                        ProductName = "Phone",ProductDescription = "This is a new IPhone 16 Pro Max", ProductImage = "https://alephksa.com/cdn/shop/files/iPhone_16_Pro_Max_White_Titanium_PDP_Image_Position_1__en-ME.jpg?v=1725974641",
                        ProductPrice = 65346, StockQuantity = 32, ProductSize = "3.5 Inches", Colors =  new List<ProductColors>{ProductColors.Black, ProductColors.White, ProductColors.Brown, ProductColors.Grey, ProductColors.Gold}, 
                        CompanyName = "Apple", SoldOut = 2, IsCustomeSize = true, isActive = true, CreatedDate =  new DateTime(2024, 9, 21, 14, 30, 0), 
                    };

                    context.Products.AddRange(product1, product2);
                    context.SaveChanges();
                }
                
                // ............................. Payment ...........................
                if(!context.Payment.Any()){
                     
                    var payment1 = new PaymentModel
                        {
                            PaymentName = "John Doe",
                            CardNumber = "1234 5678 9012 3456",
                            ExpireDate = "12/26",
                            CvvNumber = 123,
                            EmailAddress = "johndoe@example.com",
                            PaymentMode = "Credit Card",
                        };

                        var payment2 = new PaymentModel
                        {
                            PaymentName = "Jane Smith",
                            CardNumber = "9876 5432 1098 7654",
                            ExpireDate = "11/25",
                            CvvNumber = 456,
                            EmailAddress = "janesmith@example.com",
                            PaymentMode = "PayPal",
                        };

                        context.Payment.AddRange(payment1, payment2); // Ensure payments are added
                        context.SaveChanges();
                }
                
                // ............................. Orders ............................
                if (!context.Orders.Any())
                {
                    // Retrieve the existing payments that were just added
                    var payment1 = context.Payment.FirstOrDefault(p => p.PaymentName == "John Doe");
                    var payment2 = context.Payment.FirstOrDefault(p => p.PaymentName == "Jane Smith");

                    // Add orders with the correct payment IDs
                    var Order1 = new OrderModel
                    {
                        OrderNumber = "ORD12345",
                        Quantity = 2,
                        Orders = OrderStatus.Pending,
                        OrderedDate = DateTime.Now,
                        IsCanceled = false,
                        UserId = 1, // Assuming user already exists
                        PaymentId = 1, // Reference existing payment ID
                    };

                    var Order2 = new OrderModel
                    {
                        OrderNumber = "XDOM2341B3",
                        Quantity = 4,
                        Orders = OrderStatus.Processing,
                        OrderedDate = DateTime.Now,
                        IsCanceled = false,
                        UserId = 1, // Assuming user already exists
                        PaymentId = 2, // Reference existing payment ID
                    };

                    context.Orders.AddRange(Order1, Order2);
                    context.SaveChanges();
                }

                // ............................. Order Products .............................
                if(!context.Products.Any()){
                     
                    var order1 = context.Orders.FirstOrDefault(o => o.OrderNumber == "ORD12345");
                    var product1 = context.Products.FirstOrDefault(p => p.ProductName == "Laptop");

                    var order2 = context.Orders.FirstOrDefault(o => o.OrderNumber == "XDOM2341B3");
                    var product2 = context.Products.FirstOrDefault(p => p.ProductName == "Phone");

                    var orderProduct1 = new OrderProduct
                    {
                        OrderId = order1!.OrderId,
                        ProductId = product1!.ProductId
                    };

                    var orderProduct2 = new OrderProduct
                    {
                        OrderId = order2!.OrderId,
                        ProductId = product2!.ProductId
                    };

                    context.OrderProduct.AddRange(orderProduct1, orderProduct2);
                    context.SaveChanges();
                }

                // Reviews
                if(!context.Review.Any()){

                }
                // Roles
                if(!context.Roles.Any()){

                }
                // SubCategoory
                if(!context.SubCategories.Any()){

                }
                // Users
                if(!context.Users.Any()){

                }
                // Wishlist
                if(!context.WishList.Any()){

                }
            }
        }
    }
}