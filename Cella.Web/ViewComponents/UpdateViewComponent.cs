using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Cella.Models;
using Microsoft.AspNetCore.Identity;
using Cella.Domain;

namespace WareHouseCrm.Web.ViewComponents {

    [ViewComponent(Name = "UpdateList")]
    public class UpdateViewComponent : ViewComponent {
        private readonly IHttpContextAccessor _contextAccessor;
        private UserManager<ApplicationUser> _userManager;
        private readonly CellaDBContext db;
        public int CaseId { get; set; }
        public UpdateViewComponent(CellaDBContext context , IHttpContextAccessor contextAccessor, UserManager<ApplicationUser> userManager)  {
            db = context;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }



        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public async Task<Guid> GetCurrentTennantId() {
            ApplicationUser usr = await GetCurrentUserAsync();
            TempData["TeannantId"] = usr?.Id;

            Guid.TryParse(usr?.Id, out Guid resultTennantId);

            return resultTennantId;
        }
        public async Task<IViewComponentResult> InvokeAsync( string userId) {

            Guid.TryParse(userId, out Guid resultUserId);
            var items = await GetItemsAsync(resultUserId);
            
            return View(items);
        }
        private Task<List<Notifications>> GetItemsAsync(Guid userId) {        
         return db.Notifications.Where(x => x.isActive ==true && x.isDeleted==false && x.isRead==false  && x.SharedTo== userId.ToString() ).Include(c => c.SharedToUser).Include(c=>c.SharedFromUser).ToListAsync(); }
    }
    }
