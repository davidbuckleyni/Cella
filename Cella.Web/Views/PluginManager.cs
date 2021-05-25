using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseCrm.Web.Views
{
    public class PluginManager : Controller
    {
        // GET: PluginManager
        public ActionResult Index()
        {
            return View();
        }

        // GET: PluginManager/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PluginManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PluginManager/Create
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

        // GET: PluginManager/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PluginManager/Edit/5
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

        // GET: PluginManager/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PluginManager/Delete/5
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
