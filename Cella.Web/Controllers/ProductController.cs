using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cella.BL.Intefaces;
using Cella.Domain;
using Cella.Domain.Interfaces;
using Cella.Models;
using Cella.Models.ViewModels;
 
namespace Warehouse.Web.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IMapper mapper;

        private CellaDBContext _context;
        private readonly IToastNotification _toast;
        private IProductService _productService;
        public ProductController(CellaDBContext context, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleMgr, IToastNotification toast, IProductService productService , IConfiguration config) : base(context, httpContextAccessor, userManager, roleMgr, toast,config)
        {
            _toast = toast;

            _context = context;
            this.mapper = mapper;

        }
       
        // GET: ShoppingCartController
        public ActionResult Index()
        {
            return View("~/Views/Admin/Product/Index");

        }

        // GET: ShoppingCartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShoppingCartController/Create
        public ActionResult Create()
        {
            return View();
        }
 
        public CategoriesViewModel RebindCats()
        {
            CategoriesViewModel categoriesViewModel = new CategoriesViewModel();
            categoriesViewModel.Categories = _context.Categories.Where(w => w.isActive == false && w.isDeleted == false).ToList();

            return categoriesViewModel;

        }
        [HttpPost]
        // GET: ShoppingCartController/Create
        public ActionResult SubmitCategories(Categories cat)
        {
            _context.Categories.Add(cat);
            _toast.AddSuccessToastMessage("Category added to Warehouse");
            
            return View(RebindCats());
        }

            // POST: ShoppingCartController/Create
            [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShoppingCartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShoppingCartController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShoppingCartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // GET: ShoppingCartController/Delete/5
        public ActionResult OrderForm()
        {
            return View();
        }



        // POST: ShoppingCartController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
