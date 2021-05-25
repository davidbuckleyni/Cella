using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using Microsoft.EntityFrameworkCore;
using Cella.Models;
using Cella.Domain;

namespace WareHouseCrm.Web.ViewComponents {

    [ViewComponent(Name = "PhotosList")]
    public class PhotosViewComponent : ViewComponent {

        private readonly IHttpContextAccessor _contextAccessor;

        private readonly CellaDBContext db;
        public int CaseId { get; set; }
        public PhotosViewComponent(CellaDBContext context, IHttpContextAccessor contextAccessor) {
            db = context;
            _contextAccessor = contextAccessor;

        }
        public async Task<IViewComponentResult> InvokeAsync(int caseId) {
            

            var items = await GetItemsAsync(caseId);

            _contextAccessor.HttpContext.Session.SetString("CaseId", CaseId.ToString());

            return View(items);
        }

        private Task<List<Photos>> GetItemsAsync(int caseId) {

            return db.Photos.Where(x => x.IsActive == true && x.WarehouseId == caseId).ToListAsync();
        }
    }
    }
