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

    [ViewComponent(Name = "AddressesList")]
    public class AddressesViewComponent : ViewComponent {

        private readonly IHttpContextAccessor _contextAccessor;

        private readonly CellaDBContext db;
        public int CaseId { get; set; }
        public AddressesViewComponent(CellaDBContext context, IHttpContextAccessor contextAccessor) {
            db = context;
            _contextAccessor = contextAccessor;

        }
        public async Task<IViewComponentResult> InvokeAsync(int caseId) {
            

            var items = await GetItemsAsync(caseId);

            _contextAccessor.HttpContext.Session.SetString("CaseId", CaseId.ToString());

            return View(items);
        }

        private Task<List<Address>> GetItemsAsync(int caseId) {

            return db.Address.Where(x => x.isActive == true && x.WarehouseId == caseId && x.isDeleted == true).ToListAsync();
        }
    }
    }
