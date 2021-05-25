using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 

using Microsoft.AspNetCore.Http;

using Microsoft.EntityFrameworkCore;
using Cella.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cella.Domain;

namespace WareHouseCrm.Web.ViewComponents {

    [ViewComponent(Name = "UserDropDownComponent")]
    public class UsersDropDownViewComponent : ViewComponent {

        private readonly IHttpContextAccessor _contextAccessor;
        private UserManager<ApplicationUser> _userManager;

        private readonly CellaDBContext _context;
        public int CaseId { get; set; }
        public UsersDropDownViewComponent(CellaDBContext context, IHttpContextAccessor contextAccessor, UserManager<ApplicationUser> userManager) {
            _context = context;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
            GetUsersList();
        }
        public void GetUsersList() {
            var test = GetCurrentTennantId().ToString();
                var items = _context.Users.Where(w => w.Id != GetCurrentTennantId().ToString()).Select(sm => new {
                    Name = sm.FirstName + " " + sm.LastName,
                    Id = sm.Id.ToString()
                }).ToList();

                ViewBag.UserList = items;
            }

         
       
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public async Task<Guid> GetCurrentTennantId() {
            ApplicationUser usr = await GetCurrentUserAsync();
            TempData["TeannantId"] = usr?.Id;

            Guid.TryParse(usr?.Id, out Guid resultTennantId);

            return resultTennantId;
        }
        public async Task<IViewComponentResult> InvokeAsync(int caseId) {
            

            var items = await GetItemsAsync(caseId);
            GetUsersList();
            _contextAccessor.HttpContext.Session.SetString("CaseId", CaseId.ToString());

            return View(items);
        }

        private async Task<List<ApplicationUser>> GetItemsAsync(int caseId) {
            string currentUser = GetCurrentTennantId().Result.ToString();
            var excludeCurrentUser = await _userManager.Users.Where(w => w.Id != currentUser).ToListAsync();
            return excludeCurrentUser;
            
        }
    }
    }
