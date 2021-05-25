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

    [ViewComponent(Name = "Uploader")]
    public class UploaderViewComponent : ViewComponent {
        private readonly IHttpContextAccessor _contextAccessor;
        private UserManager<ApplicationUser> _userManager;
        private readonly CellaDBContext db;
        public int CaseId { get; set; }
        public UploaderViewComponent(CellaDBContext context , IHttpContextAccessor contextAccessor, UserManager<ApplicationUser> userManager)  {
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
        public async Task<IViewComponentResult> InvokeAsync( PluginList model) {


           // var items = await GetItemsAsync(resultUserId);
            
            return View();
        }
        private Task<List<PluginList>> GetItemsAsync(Guid userId) {
            return db.Plugins.Where(x => x.isEnabled == "true").ToListAsync();
        }
    }
    }
