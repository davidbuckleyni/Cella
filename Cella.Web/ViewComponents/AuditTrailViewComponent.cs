using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using  WareHouseDal.Dal;
using Microsoft.AspNetCore.Http;
using WarehouseDal.Models;

namespace MISSystem.Web.ViewComponents
{

    [ViewComponent(Name = "AudiTrailList")]
    public class AuditTrailViewComponent : ViewComponent
    {
        private readonly IHttpContextAccessor _contextAccessor;

        private readonly WarehouseDBContext db;
        public int CaseId { get; set; }
        public AuditTrailViewComponent(WarehouseDBContext context, IHttpContextAccessor contextAccessor)
        {
            db = context;
            _contextAccessor = contextAccessor;

        }


        //   public async Task<IViewComponentResult> InvokeAsync(
        //int caseId) {
        //       CaseId = caseId;

        //     //  var items = await GetItemsAsync(caseId);

        //       _contextAccessor.HttpContext.Session.SetString("CaseId",CaseId.ToString());
        //        return View(items);
        //   }
        //    private Task<List<WareHouseAuditTrail>> GetItemsAsync(int caseId) {
        //     //   ViewBag.CaseId = caseId;
        //      //  return db.MisAuditTrail.Where(x => x.isActive ==true &&  x.WarehouseId == caseId).ToListAsync();
        //    }
        //}

    }
}
