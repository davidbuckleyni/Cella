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

    [ViewComponent(Name = "FileAttachmentList")]
    public class FileAttachmentComponent : ViewComponent {

        private readonly IHttpContextAccessor _contextAccessor;
        private UserManager<ApplicationUser> _userManager;

        private readonly WarehouseDBContext _context;


        public int CaseId { get; set; }
        public FileAttachmentComponent(WarehouseDBContext context, IHttpContextAccessor contextAccessor, UserManager<ApplicationUser> userManager) {
            _context = context;
            _contextAccessor = contextAccessor;
            _userManager = userManager;


        }
        public async Task<IViewComponentResult> InvokeAsync(int caseId, string fileExtension,int Area,int poiId,int VesselId) {


                var items = await GetItemsAsync(caseId, fileExtension, Area,poiId, VesselId);
            ViewBag.PoiId = poiId;
            ViewBag.VesselId = VesselId;

            _contextAccessor.HttpContext.Session.SetString("CaseId", CaseId.ToString());

            return View(items);
        }
        private Task<List<FileAttachments>> GetItemsAsync(int caseId, string fileExtension,int uploadArea,int poiId, int VesselId) {
            List<FileAttachments> items = new List<FileAttachments>();
            if (fileExtension != null) {                
                String[] extensions = fileExtension.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                //this is to allow the file list work in all sections.
                if(poiId !=0)
                    items = _context.FileAttachments.Where(x => extensions.Contains(x.Extension) && x.isActive == true && x.UploadAreaId == uploadArea && x.isDeleted == false && x.PoiID ==poiId).Include(c => c.UploadedByUser).ToList();
                else
                    items = _context.FileAttachments.Where(x => extensions.Contains(x.Extension)  && x.isActive == true && x.UploadAreaId== uploadArea && x.isDeleted == false && x.CaseId == caseId).Include(c => c.UploadedByUser).ToList();
                if(VesselId !=0)
                    items = _context.FileAttachments.Where(x => extensions.Contains(x.Extension) && x.isActive == true && x.UploadAreaId == uploadArea && x.isDeleted == false ).Include(c => c.UploadedByUser).ToList();
            } else {

                items = _context.FileAttachments.Where(x => x.isActive == true && x.isDeleted == false && x.CaseId == caseId ).Include(c => c.UploadedByUser).ToList();
            }
            return Task.FromResult<List<FileAttachments>>(items);
        }
    }
}
