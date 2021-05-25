using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Cella.Models;
using Cella.Domain;

namespace MISSystem.Web.ViewComponents
{
    public class CompaniesController : Controller
    {
        private readonly CellaDBContext _context;

        private readonly UserManager<ApplicationUser> _userManager;
        public CompaniesController(CellaDBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private void SetupViewBags()
        {
            GetUserName();

        }
        // GET: Companies
        public async Task<IActionResult> Index()
        {
            ViewBag.NotificationCount = await GetNotificationsCount();
              SetupViewBags();
            return View(await _context.Companies.ToListAsync());
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(this.User);


        public void GetUserName()
        {
            var tennantId = GetCurrentTennantId().Result;
            var items = _context.Users.Where(w => w.Id == tennantId.ToString()).FirstOrDefault();
            ViewBag.UserName = items.FirstName + " " + items.LastName;

        }
        public async Task<Guid> GetCurrentTennantId()
        {
            ApplicationUser usr = await GetCurrentUserAsync();
            TempData["TeannantId"] = usr?.Id;
            Guid.TryParse(usr?.Id, out Guid resultGuid);

            return resultGuid;
        }
        public async Task<int> GetNotificationsCount()
        {
            var userId = await GetCurrentTennantId();
            //the not should show all the notifcations should only check the desnitation user id
            return _context.Notifications.Where(w => w.SharedTo == userId.ToString()).Count();
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            var count = GetNotificationsCount().GetAwaiter();
            ViewBag.NotificationCount = count;

            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyName,CompanyAddress1,CompanyAddress2,CompanyCity,CompanyPostCode,IMOCompanyNumber,CountryofRegistration,Country,isDeleted,isActive,CreatedDate,CreatedBy")] Company company)
        {
            if (ModelState.IsValid)
            {
                  SetupViewBags();
                _context.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.NotificationCount = await GetNotificationsCount();
               SetupViewBags();
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyName,CompanyAddress1,CompanyAddress2,CompanyCity,CompanyPostCode,IMOCompanyNumber,CountryofRegistration,Country,isDeleted,isActive,CreatedDate,CreatedBy")] Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                  SetupViewBags();
                return RedirectToAction(nameof(Index));
            }
              SetupViewBags();
            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }
    }
}
