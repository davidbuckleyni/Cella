using AutoMapper;
using Cella.Domain;
using Cella.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        private readonly IConfiguration _config;
        private CellaDBContext _context;
        public WarehouseController(CellaDBContext context, IMapper mapper, IToastNotification toast, IConfiguration config)
        {
            _context = context;
            _config = config;
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

    [HttpPost]
    public IActionResult SetCurrency(IFormCollection forms,string returnUrl)
    {
        string storeLocale = forms["customerCurrency"].ToString();

        var record = _context.Currencies.Where(w => w.DisplayLocale == storeLocale).FirstOrDefault();
            
        var currentLanguageId = _context.Appsettings.Where(w => w.Key == Constants.FrontEndDefaultLanguageId).FirstOrDefault();

        if (record != null)
            {
            _config[Constants.FrontEndDefaultLanguageId] = record.Id.ToString();
            currentLanguageId.Value = record.Id.ToString();
            _context.SaveChanges();
            _toast.AddAlertToastMessage("Currecy changed to " + record.Name); 
        }           
            
        return LocalRedirect(returnUrl);
    }
        [HttpPost]
        public IActionResult SetCulture(string culture, string returnUrl)
        {

            var record = _context.Appsettings.Where(w => w.Key == Constants.FrontEndDefaultLanguageId).FirstOrDefault();
            if (culture == "en")
                record.Value = "1";

            if (culture == "fr")
                record.Value = "2";

            
            _context.SaveChangesAsync();
            _toast.AddSuccessToastMessage("Language changed to :" + record.Key);

            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
            return LocalRedirect(returnUrl);
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
