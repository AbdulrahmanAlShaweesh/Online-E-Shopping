using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using onlineEShopping.Data;

namespace onlineEShopping.Controllers
{
    
    public class ContactController : Controller
    {
         private readonly OnlineEShoppingDbContext _dbContext;

         public ContactController(OnlineEShoppingDbContext dbContext)
         {  
            _dbContext = dbContext;
         }

    }
}