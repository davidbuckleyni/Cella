using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cella.Models;
using AutoMapper;
using Warehouse.Domain;
using Warehouse.Domain.Interfaces;
using NToastNotify;
using WarehouseCrm.Web.Attribute;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Cella.Domain;

namespace Warehouse.Web.Controllers
{
    public class ProductItemsController : BaseController
    {
        private readonly IMapper mapper;

        private CellaDBContext _context;
        private readonly IToastNotification _toast;
        public ProductItemsController(CellaDBContext context, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleMgr, IToastNotification toast, IConfiguration config) : base(context, httpContextAccessor, userManager, roleMgr,toast,config)

        {
            _context = context;
            _toast = toast;
            this.mapper = mapper;

        }

        // GET: StockItems
         
        public async Task<IActionResult> Index()
        {
    StockItemVm stockVm = new StockItemVm();
            stockVm.StockItems = _context.Product.Where(w => w.isActive == true && w.isDeleted == false).ToList();
         stockVm.UserPermissions = UserHasPermssions("Read,Delete", "StockItems");
            return View("~/Views/StockItems/Index.cshtml", stockVm);
         
        }

        // GET: ProductItem/Details/5
        [HasPermissions("View")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
       
            var stockItem = await _context.Product.FindAsync(id);                
            if (stockItem == null)
            {
                return NotFound();
            }

            return View(stockItem);
        }

        // GET: StockItems/Create
     
   
        public IActionResult Create()
        {
            StockItemVm stockVm = new StockItemVm();
            stockVm.StockItems = _context.Product.Where(w => w.isActive == true && w.isDeleted == false).ToList();
            stockVm.UserPermissions = UserHasPermssions("Create,Update", "StockItems");


            if (stockVm.UserPermissions.Where(w => w.Action == "Create" && w.Authorized == false).Any())
                _toast.AddErrorToastMessage("User Cannot Create stock");


            return View();
        }

        // POST: Product/Submit
        //Each controller should have a submit function at the end of the day the user is submitting the record.

        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(Product viewModel)
        {
            if (ModelState.IsValid)
            {
                Product stockItem = mapper.Map<Product>(viewModel);

                // No id so we add it to database
                if (viewModel.Id <= 0)
                    {
                    //we want to map the view model over to the stock item model for saving.
                    try
                    {
                        await _context.Product.AddAsync(stockItem);
                    }catch(Exception ex)
                    {

                    }
                    }
                    // Has Id, therefore it's in database so we update
                    else
                    {
                     _context.Product.Update(stockItem);
                    }

                _context.SaveChanges();
                _toast.AddSuccessToastMessage("Product Item Saved");
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: StockItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockItem = await _context.Product.FindAsync(id);
            if (stockItem == null)
            {
                return NotFound();
            }

            StockItemVm stockItemVm = mapper.Map<StockItemVm>(stockItem);

            return View(stockItemVm);
        }

        
        
        // GET: StockItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockItem = await _context.Product.FindAsync(id);
                
            if (stockItem == null)
            {
                return NotFound();
            }

            return View(stockItem);
        }

        // POST: StockItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stockItem = await _context.Product.FindAsync(id);
            _context.Product.Remove(stockItem as Product);
          
            return RedirectToAction(nameof(Index));
        }

     
    }
}
