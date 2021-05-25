using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cella.Models;
using Cella.Domain;

namespace Warehouse.Web.Controllers
{
    public class SystemSetupsController : Controller
    {
        private readonly CellaDBContext _context;

        public SystemSetupsController(CellaDBContext context)
        {
            _context = context;
        }

        // GET: SystemSetups
        public async Task<IActionResult> Index()
        {
            return View(await _context.SystemSetup.ToListAsync());
        }

        // GET: SystemSetups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemSetup = await _context.SystemSetup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (systemSetup == null)
            {
                return NotFound();
            }

            return View(systemSetup);
        }

        // GET: SystemSetups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SystemSetups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Language,MaraineTrafficApiUrl,MaraineTrafficApiKey,SendGridApiKey,SendGridUserName,SendGridPassword,TwilloUrl,TwillioUserName,TwillioPassword,UploadFolderPath,TeannatId,GridItems,Version")] SystemSetup systemSetup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(systemSetup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(systemSetup);
        }

        // GET: SystemSetups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemSetup = await _context.SystemSetup.FindAsync(id);
            if (systemSetup == null)
            {
                return NotFound();
            }
            return View(systemSetup);
        }

        // POST: SystemSetups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Language,MaraineTrafficApiUrl,MaraineTrafficApiKey,SendGridApiKey,SendGridUserName,SendGridPassword,TwilloUrl,TwillioUserName,TwillioPassword,UploadFolderPath,TeannatId,GridItems,Version")] SystemSetup systemSetup)
        {
            if (id != systemSetup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(systemSetup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SystemSetupExists(systemSetup.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(systemSetup);
        }

        // GET: SystemSetups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemSetup = await _context.SystemSetup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (systemSetup == null)
            {
                return NotFound();
            }

            return View(systemSetup);
        }

        // POST: SystemSetups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var systemSetup = await _context.SystemSetup.FindAsync(id);
            _context.SystemSetup.Remove(systemSetup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SystemSetupExists(int id)
        {
            return _context.SystemSetup.Any(e => e.Id == id);
        }
    }
}
