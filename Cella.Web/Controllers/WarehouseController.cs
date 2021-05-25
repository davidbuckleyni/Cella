using AutoMapper;
using Cella.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Domain;
using Warehouse.Domain.Interfaces;

namespace Warehouse.Web.Controllers
{
    public class WarehouseController : Controller
    {
        private readonly IMapper mapper;
        private readonly IToastNotification _toast;

        private IDataContext _context;
        public WarehouseController(IDataContext context, IMapper mapper, IToastNotification toast)
        {
            _context = context;

            _toast = toast;

            this.mapper = mapper;

        }
        // GET: ShoppingCartController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WarehouseLocations()
        {
            return View("~/Views/Admin/WarehouseLocations/Index.cshtml");

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
