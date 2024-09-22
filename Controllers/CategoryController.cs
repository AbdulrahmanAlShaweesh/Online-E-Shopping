using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using onlineEShopping.Data;

namespace onlineEShopping.Controllers
{
    
    public class CategoryController : Controller
    {
        private readonly OnlineEShoppingDbContext _Dbcontext;

        public CategoryController(OnlineEShoppingDbContext dbContext)
        {   
            _Dbcontext = dbContext;               // inject dependancy
        }

        public async Task<IActionResult> Index() {
            var response = await _Dbcontext!.Categories.ToListAsync();

            return View(response);
        }
    }
}