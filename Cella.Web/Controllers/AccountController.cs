using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Cella.Models;

namespace Warehouse.Web.Controllers {
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;

        public AccountController(SignInManager<ApplicationUser> signInManager, ILogger<AccountController> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

      //  [HttpPost]
        //[ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Logout() { 
  //            await _signInManager.SignOutAsync();            
//            return RedirectToAction(nameof(Account), "Home");
      //  }

    }
}
