using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Cella.Models;
using Cella.Models.Permissions;
using Cella.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain;
using Cella.Domain;

namespace Warehouse.Web.Controllers
{
    public class ThemesController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private IPasswordHasher<ApplicationUser> passwordHasher;
        private IPasswordValidator<ApplicationUser> passwordValidator;
        private IUserValidator<ApplicationUser> userValidator;
        private readonly CellaDBContext _context;
        private CellaCrmApiCoreClient _client;
        public ThemesController(UserManager<ApplicationUser> usrMgr, IPasswordHasher<ApplicationUser> passwordHash, IPasswordValidator<ApplicationUser> passwordVal, IUserValidator<ApplicationUser> userValid, CellaDBContext context)
        {
            userManager = usrMgr;
            passwordHasher = passwordHash;
            passwordValidator = passwordVal;
            userValidator = userValid;
            _context = context;
        }

        public IActionResult EditPlugin(int id)
        {
            var plugin = _context.Plugins.Where(w => w.Id == id).FirstOrDefault();

            return View("~/Views/Admin/PluginManager/Edit.cshtml", plugin);

        }
        [HttpPost]
        public IActionResult SubmitPlugin(PluginList record)
        {
            if (record.Id == 0)
            {


            }
            else
            {
                var pluginRecord = _context.Plugins.Where(w => w.ModuleId == record.ModuleId).FirstOrDefault();
                if (pluginRecord != null)
                {
                    _context.Plugins.Update(record);
                    _context.SaveChanges();



                }

            }
            return View();
        }

        public IActionResult PluginManager()
        {

            return View("~/Views/Admin/PluginManager/Index.cshtml", _context.Plugins.ToList());

        }

 
        public IActionResult Index()
        {
            GetUserName();

            ThemeListItemVM vm = new ThemeListItemVM();
            vm.ThemeListItem = _context.ThemeSetup.ToList();
            return View(vm);
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);

        public async Task<Guid> GetCurrentTennantId()
        {
            ApplicationUser usr = await GetCurrentUserAsync();
            TempData["TeannantId"] = usr?.Id;
            Guid.TryParse(usr?.Id, out Guid resultGuid);

            return resultGuid;
        }


        public async Task<int> GetNotificationsCount()
        {
            Guid userId = await GetCurrentTennantId();
            //the not should show all the notifcations should only check the desnitation user id
            return _context.Notifications.Where(w => w.SharedTo == userId.ToString()).Count();
        }


        public void GetUserName()
        {
            var tennantId = GetCurrentTennantId().Result;
            var items = _context.Users.Where(w => w.Id == tennantId.ToString()).FirstOrDefault();
            ViewBag.UserName = items.FirstName + " " + items.LastName;

        }
        public IActionResult Setup()
        {

            var setup = _context.SystemSetup.FirstOrDefault();
            return View(setup);
        }


        public IActionResult Assign()
        {
            return View();
        }

        public ViewResult Create() => View();

        [HttpGet]
        public ViewResult EditUserPermissions (string id)
        {
            UserPermissionsViewModel userPermissionsViewModel = new UserPermissionsViewModel();
            var user = userManager.FindByIdAsync(id).Result;
            userPermissionsViewModel.UserPermmissions = _context.CellaUserPermmissions.Where(w => w.UserId == id).ToList();
 
            return View(userPermissionsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = new ApplicationUser
                {
                    UserName = user.Username,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,


                };

                IdentityResult result = await userManager.CreateAsync(appUser, user.Password);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            return View(user);
        }

        public async Task<IActionResult> Update(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if (user != null)
                return View(user);
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id, string email, string password, int age, string country, string firstName, string lastName)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult validEmail = null;
                if (!string.IsNullOrEmpty(email))
                {
                    validEmail = await userValidator.ValidateAsync(userManager, user);
                    if (validEmail.Succeeded)
                    {
                        user.FirstName = firstName;
                        user.LastName = lastName;
                        user.Email = email;
                    }
                    else
                        Errors(validEmail);
                }
                else
                    ModelState.AddModelError("", "Email cannot be empty");

                IdentityResult validPass = null;
                if (!string.IsNullOrEmpty(password))
                {
                    validPass = await passwordValidator.ValidateAsync(userManager, user, password);
                    if (validPass.Succeeded)
                        user.PasswordHash = passwordHasher.HashPassword(user, password);
                    else
                        Errors(validPass);
                }
                else
                    ModelState.AddModelError("", "Password cannot be empty");

                if (validEmail != null && validPass != null && validEmail.Succeeded && validPass.Succeeded)
                {
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                        return RedirectToAction("Index");
                    else
                        Errors(result);
                }
            }
            else
                ModelState.AddModelError("", "User Not Found");



            return View(user);
        }


        void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View("Index", userManager.Users);
        }
       
     
    }
}