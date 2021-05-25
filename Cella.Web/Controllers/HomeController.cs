using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cella.Models.Permissions;
using Microsoft.AspNetCore.Identity;
using Cella.Models;
using Microsoft.AspNetCore.Http;
using Cella.Models.ViewModels;
using NToastNotify;
using WarehouseCrm.Web.Helpers;
using Microsoft.Extensions.Configuration;
using Cella.Domain;

namespace Warehouse.Web.Controllers
{
    public class HomeController : BaseController
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        private readonly IToastNotification _toast;
        private CellaDBContext _context;
        
        public HomeController(CellaDBContext context, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleMgr, IToastNotification toast,IConfiguration config) :  base(context, httpContextAccessor, userManager, roleMgr, toast,config)
        { 
            _context = context;
            _context.AddPluginModulesToDB();
            _userManager = userManager;
            _roleManager = roleMgr;
            _toast = toast;
        //     AddPermissions();

    }

       
        public async void AddPermissions()
        {
         //   var appPermissions = new AppWarehouseUserPermmissions
            //{
            //    UserId = AppUser.Id.ToString(),
            // Name = "Create",
            //    Controller = "StockItems",
            //    Area = "Index",
            //    isAcitve = true
            //};

            //_context.AppWarehouseUserPermmissions.Add(appPermissions);
            //_context.SaveChanges();
        }
        public IActionResult Error(CustomErrorViewModel vm)
        {
            return View(vm);
        }
        public IActionResult Index()
        {
             

            return View();
        }
    }
}
