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
    [Route("[controller]")]
    public class RoleController : Controller
    {
        private readonly OnlineEShoppingDbContext _dbContext; 

        public RoleController(OnlineEShoppingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index() {
            var response = await _dbContext.Roles.ToListAsync(); 

            return View(response);
        }
    }
}