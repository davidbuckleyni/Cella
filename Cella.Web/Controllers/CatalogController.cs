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
using Cella.BL.Intefaces;
using Cella.Models.ViewModels;
using Microsoft.Extensions.Configuration;
using Cella.Domain;

namespace Warehouse.Web.Controllers
{
    public class CatalogController : BaseController
    {
        private readonly IMapper mapper;
        private IProductService _productService;

        private CellaDBContext _context;
        private readonly IToastNotification _toast;
        private readonly ICategoryService _categoryService;
        public CatalogController(CellaDBContext context, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleMgr, IToastNotification toast, ICategoryService service, IProductService productService, IConfiguration config) : base(context, httpContextAccessor, userManager, roleMgr,toast,config)

        {
            _context = context;
            _toast = toast;
            _categoryService = service;
            this.mapper = mapper;
            _productService = productService;

        }

        // GET: Categories         
        public async Task<IActionResult> Categories()
        {
            
            return View(_categoryService.GetAllCategoriesViewModel(UserId,StoreId));
        }


        public ActionResult ProductListings(int Id)
        {
            ProductListingsViewModel vm = new ProductListingsViewModel();

            var productListingsVIewModel = _productService.GetProductsByCategory(UserId, StoreId, 1);
            return View( productListingsVIewModel);

        }
        // GET: StockItems/Details/5
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
     
   
        

        // POST: StockItems/Submit
        //Each controller should have a submit function at the end of the day the user is submitting the record.

        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(Categories viewModel)
        {
            if (ModelState.IsValid)
            {
                Categories categoriesItem = mapper.Map<Categories>(viewModel);

                // No id so we add it to database
                if (viewModel.Id <= 0)
                    {
                    //we want to map the view model over to the stock item model for saving.
                    try
                    {
                        await _context.Categories.AddAsync(categoriesItem);
                    }catch(Exception ex)
                    {

                    }
                    }
                    // Has Id, therefore it's in database so we update
                    else
                    {
                     _context.Categories.Update(categoriesItem);
                    }

                _context.SaveChanges();
                _toast.AddSuccessToastMessage("Category Saved");
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockItem = await _context.Categories.FindAsync(id);
            if (stockItem == null)
            {
                return NotFound();
            }

            StockItemVm stockItemVm = mapper.Map<StockItemVm>(stockItem);

            return View(stockItemVm);
        }



        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockItem = await _context.Categories.FindAsync(id);
                
            if (stockItem == null)
            {
                return NotFound();
            }

            return View(stockItem);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriesItem = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(categoriesItem as Categories);
          
            return RedirectToAction(nameof(Index));
        }

     
    }
}
