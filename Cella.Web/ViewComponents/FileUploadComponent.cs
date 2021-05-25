using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  WareHouseDal.Dal;
using Microsoft.AspNetCore.Http;

using Microsoft.EntityFrameworkCore;
using WarehouseDal.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Warehouse.Web.Helpers;
using Microsoft.Extensions.Options;

namespace MISSystem.Web.ViewComponents {

    [ViewComponent(Name = "FileUploadComponent")]
    public class FileUploadComponent : ViewComponent
    {

        private readonly IHttpContextAccessor _contextAccessor;
        private UserManager<ApplicationUser> _userManager;

        private readonly WarehouseDBContext _context;


        public int CaseId { get; set; }

        public FileUploadComponent(WarehouseDBContext context, IHttpContextAccessor contextAccessor,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _userManager = userManager;


        }

        public IViewComponentResult Invoke(int Area, int? PoiId, int? VesselId)
        {

            ViewBag.UploadArea = Area;
            ViewBag.PoiId = PoiId;
            ViewBag.VesselId = VesselId;


            FileAttachmentsVM newUpload = new FileAttachmentsVM();
            return View(newUpload);

        }
    }
}
