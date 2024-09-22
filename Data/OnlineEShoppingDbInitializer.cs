using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.EntityFrameworkCore;
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

                // ........................ Cart ................................
                if(!context.Cart.Any()){
                    var user1 = context.Users.Find(1);
                    var user2 = context.Users.Find(2);

                    if(user1 != null && user2 != null) {
                        var Cart1 = new ShoppingCart {
                            Quantity = 2, AddedDate = new DateTime(2024, 9, 21, 14, 30, 0), UserId = user1!.UsrId,
                        };

                        var Cart2 = new ShoppingCart {
                            Quantity = 4, AddedDate =  DateTime.Now, UserId = user2!.UsrId,
                        };
                        
                        context.Cart.AddRange(Cart1, Cart2);
                        context.SaveChanges();
                    }
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
                if (!context.Products.Any())
                {
                    // Check if SubCategories exist
                    var subCategory1 = context.SubCategories.Find(1);
                    var subCategory2 = context.SubCategories.Find(2);

                    // Check if ShoppingCarts exist
                    var shoppingCart1 = context.Cart.Find(1);
                    var shoppingCart2 = context.Cart.Find(2);

                    if (subCategory1 != null || subCategory2 != null || shoppingCart1 != null || shoppingCart2 != null)
                    {
                        var product1 = new ProductModel
                        {
                            ProductName = "Laptop",
                            ProductDescription = "This is a new HP Laptop",
                            ProductImage = "https://www.hp.com/content/dam/sites/worldwide/personal-computers/consumer/laptops-and-2-in-1s/new/colorways/HP_15.6_Laptop_Intel_Natural_Silver@2x.jpg",
                            ProductPrice = 34534,
                            StockQuantity = 3,
                            ProductSize = "16 Inches",
                            Colors = new List<ProductColors> { ProductColors.Black, ProductColors.White, ProductColors.Brown },
                            CompanyName = "HP",
                            SoldOut = 2,
                            IsCustomeSize = true,
                            isActive = true,
                            CreatedDate = new DateTime(2024, 9, 21, 14, 30, 0),
                            SubCategoryId = 1,
                            ShoppingCartId = 3,
                        };

                        var product2 = new ProductModel
                        {
                            ProductName = "Phone",
                            ProductDescription = "This is a new iPhone 16 Pro Max",
                            ProductImage = "https://alephksa.com/cdn/shop/files/iPhone_16_Pro_Max_White_Titanium_PDP_Image_Position_1__en-ME.jpg?v=1725974641",
                            ProductPrice = 65346,
                            StockQuantity = 32,
                            ProductSize = "3.5 Inches",
                            Colors = new List<ProductColors> { ProductColors.Black, ProductColors.White, ProductColors.Brown, ProductColors.Grey, ProductColors.Gold },
                            CompanyName = "Apple",
                            SoldOut = 2,
                            IsCustomeSize = true,
                            isActive = true,
                            CreatedDate = new DateTime(2024, 9, 21, 14, 30, 0),
                            SubCategoryId = 2,
                            ShoppingCartId = 4,
                        };

                        context.Products.AddRange(product1, product2);

                        try
                        {
                            context.SaveChanges();
                        }
                        catch (DbUpdateException ex)
                        {
                            // Log the error message for debugging
                            Console.WriteLine($"An error occurred while saving products: {ex.InnerException?.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Required subcategories or shopping carts do not exist.");
                    }
                }

                // ............................. Payment ...........................
                if(!context.Payment.Any()){
                     
                    var payment1 = new PaymentModel
                        {
                            PaymentName = "Abdulrahman Ibraheem",
                            CardNumber = "1234 5678 9012 3456",
                            ExpireDate = "12/26",
                            CvvNumber = 123,
                            EmailAddress = "abdulrahmanibraheem@example.com",
                            PaymentMode = "Credit Card",
                        };

                        var payment2 = new PaymentModel
                        {
                            PaymentName = "Salah Nader",
                            CardNumber = "9876 5432 1098 7654",
                            ExpireDate = "11/25",
                            CvvNumber = 456,
                            EmailAddress = "salahnader@example.com",
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
                     // Ensure users exist
                    var user1 = context.Users.Find(1);
                    var user2 = context.Users.Find(2);

                    
                    if(user1 != null && user2 != null) {
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
                }

                // ............................. Order Products .............................
                if(!context.Products.Any()){
                    
                    var order1 = context.Orders.FirstOrDefault(o => o.OrderNumber == "ORD12345");
                    var product1 = context.Products.FirstOrDefault(p => p.ProductName == "Laptop");

                    var order2 = context.Orders.FirstOrDefault(o => o.OrderNumber == "XDOM2341B3");
                    var product2 = context.Products.FirstOrDefault(p => p.ProductName == "Phone");

                    if (order1 != null && product1 != null)
                    {
                        // Check if this combination already exists
                        if (!context.OrderProduct.Any(op => op.OrderId == order1.OrderId && op.ProductId == product1.ProductId))
                        {
                            var orderProduct1 = new OrderProduct
                            {
                                OrderId = order1.OrderId,
                                ProductId = product1.ProductId
                            };

                            context.OrderProduct.Add(orderProduct1);
                        }
                    }
                    if (order2 != null && product2 != null)
                    {
                        // Check if this combination already exists
                        if (!context.OrderProduct.Any(op => op.OrderId == order2.OrderId && op.ProductId == product2.ProductId))
                        {
                            var orderProduct2 = new OrderProduct
                            {
                                OrderId = order2.OrderId,
                                ProductId = product2.ProductId
                            };

                            context.OrderProduct.Add(orderProduct2);
                        }
                    }
                     context.SaveChanges();
                }

                // ................................... Reviews ...................................
                if (!context.Review.Any())
                {
                    var product1 = context.Products.Find(7);
                    var product2 = context.Products.Find(8);

                    if (product1 != null && product2 != null) // Ensure products exist
                    {
                        var review1 = new ProductReview
                        {
                            ProductName = product1.ProductName,
                            Rating = 4,
                            Comment = "It's cool, and I received it in very good condition.",
                            ReviewDate = DateTime.Now,
                            UserId = 1,
                            ProductId = 7,
                        };

                        var review2 = new ProductReview
                        {
                            ProductName = product2.ProductName,
                            Rating = 4,
                            Comment = "It's cool, and I received it in very good condition.",
                            ReviewDate = DateTime.Now,
                            UserId = 2,
                            ProductId = 8,
                        };

                        context.Review.AddRange(review1, review2); 
                        context.SaveChanges();

                        // Check if a review already exists for the user and product
                        if (!context.Review.Any(r => r.UserId == review1.UserId && r.ProductId == review1.ProductId))
                        {
                            context.Review.Add(review1);
                        }

                        if (!context.Review.Any(r => r.UserId == review2.UserId && r.ProductId == review2.ProductId))
                        {
                            context.Review.Add(review2);
                        }

                        context.SaveChanges(); // Save reviews
                    }
                }


                // .............................. Roles .............................. 
                if(!context.Roles.Any()){
                    var role1 = new RoleModel {
                            RoleName = "User", 
                    };

                    var role2 = new RoleModel {
                        RoleName = "User",
                    };

                    context.Roles.AddRange(role1, role2);
                    context.SaveChanges();
                }

                // ................................... SubCategoory ...................................
                if(!context.SubCategories.Any()){
                    var subCategory1 = new SubCategoryModel{
                        SubCategoryName = "Smartphones", isActive = true, CategoryId = 1, CreatedDate = DateTime.Now,  
                    };

                     var subCategory2 = new SubCategoryModel{
                        SubCategoryName = "Laptops", isActive = true, CategoryId = 1, CreatedDate = DateTime.Now,  
                    };

                    context.SubCategories.AddRange(subCategory1, subCategory2);
                    context.SaveChanges();
                }
                // ................................... Users ...................................
                if(!context.Users.Any()){
                    var user1 = new UserModel {
                        UserName = "Abdulrahman Ibraheem", UserEmail = "abdulrahmanibraheem@gmail.com", UserMobileNumber = "+43245765483",  
                        UserAddress = "Malaysia, Kula Lumpure", UserPostCode = "P432cvx", Password = "abood123", UserImageUrl = "https://img.freepik.com/free-photo/waist-up-portrait-handsome-serious-unshaven-male-keeps-hands-together-dressed-dark-blue-shirt-has-talk-with-interlocutor-stands-against-white-wall-self-confident-man-freelancer_273609-16320.jpg", RoleId = 1,
                        CreatedDate = DateTime.Now, 
                    };
                    
                    var user2 = new UserModel {
                        UserName = "Salah Nafer", UserEmail = "salahnader@gmail.com", UserMobileNumber = "+665478827432",  
                        UserAddress = "Malaysia, Kula Lumpure", UserPostCode = "P432cvx", Password = "salahnader123", UserImageUrl = "https://www.shutterstock.com/image-photo/happy-confident-handsome-fit-sporty-260nw-2412368199.jpg", RoleId = 2,
                        CreatedDate = DateTime.Now, 
                    };

                    context.Users.AddRange(user1, user2);
                    context.SaveChanges();
                }

                // ................................... Wishlist ...................................
                if(!context.WishList.Any()){
                    var wishlist1 = new WishListModel {
                        UserId = 1, ProductId = 7, CreatedDate = DateTime.Now,
                    };

                     var wishlist2 = new WishListModel {
                        UserId = 2, ProductId = 8, CreatedDate = DateTime.Now,
                    };

                    context.WishList.AddRange(wishlist1, wishlist2); 
                    context.SaveChanges();
                }
            }
        }
    }
}