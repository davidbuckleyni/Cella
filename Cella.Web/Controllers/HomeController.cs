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
using Cella.BL.Interfaces;

namespace Warehouse.Web.Controllers
{
    public class HomeController : BaseController
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _config;

        private readonly IToastNotification _toast;
        private CellaDBContext _context;
        private readonly IPriceFormatter _priceFormatter;
        public HomeController(CellaDBContext context, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleMgr, IToastNotification toast,IConfiguration config, IPriceFormatter priceFormatter) :  base(context, httpContextAccessor, userManager, roleMgr, toast,config)
        { 
            _context = context;
            _context.AddPluginModulesToDB();
            _userManager = userManager;
            _roleManager = roleMgr;
            _priceFormatter = priceFormatter;
            _config = config;
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
        public async Task<IActionResult> IndexAsync()
        {


            ProductListingsViewModel vm = new ProductListingsViewModel();
            List<Product> productList = new List<Product>();
            Product product = new Product();
            product.Name = "Test";
            int.TryParse(_config[Constants.FrontEndDefaultLanguageId], out int selectedLaguage);

            var currency = _context.Currencies.Where(w => w.Id == selectedLaguage).FirstOrDefault();
            string price =await _priceFormatter.FormatPriceAsync(Convert.ToDecimal(19.99), true, currency, 1, false, false) ;
                        
            product.Price = price;
            productList.Add(product);
            vm.Products = productList;

            return View(vm);
        }
    }
}
