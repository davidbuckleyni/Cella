using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using Cella.Models;
using Cella.Domain;

namespace Warehouse.Web.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly CellaDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public NotificationsController(CellaDBContext context, UserManager<ApplicationUser> userManager) {
       
            _context = context;
            _userManager = userManager;

        }

        // GET: Notifications
        public async Task<IActionResult> Index() {
            var tennantId = GetCurrentTennantId().Result;
 
           
            var notifcations = await _context.Notifications.Include(c => c.SharedFromUser).Where(w => w.SharedTo == tennantId.ToString()).ToListAsync();
            return View(notifcations);
        }

        // GET: Notifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notifications = await _context.Notifications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notifications == null)
            {
                return NotFound();
            }

            return View(notifications);
        }

        // GET: Notifications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Message,CaseId,ReplyMessage,SharedFrom,isReply,DestinationUserId,WarehouseId,isRead,isAccepted,CreateDated,isActive,isDeleted")] Notifications notifications)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notifications);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(notifications);
        }

        // GET: Notifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notifications = await _context.Notifications.FindAsync(id);
            if (notifications == null)
            {
                return NotFound();
            }
            // when there in editing the edit function their reading the email.
            notifications.isRead = true;
            await _context.SaveChangesAsync();
 
            return View(notifications);
        }

        // POST: Notifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Message,CaseId,ReplyMessage,SharedFrom,isReply,DestinationUserId,WarehouseId,isRead,isAccepted,CreateDated,isActive,isDeleted")] Notifications notifications)
        {
            if (id != notifications.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notifications);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotificationsExists(notifications.Id))
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
            return View(notifications);
        }

        // GET: Notifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notifications = await _context.Notifications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notifications == null)
            {
                return NotFound();
            }

            return View(notifications);
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(this.User);

        public async Task<Guid> GetCurrentTennantId() {
            ApplicationUser usr = await GetCurrentUserAsync();
            TempData["TeannantId"] = usr?.Id;
            Guid.TryParse(usr?.Id, out Guid resultGuid);

            return resultGuid;
        }
        public async Task<int> GetNotificationsCount() {
            Guid userId = await GetCurrentTennantId();
            var test = _context.Notifications.Where(w => w.DestinationUserId == userId).Count();
            //the not should show all the notifcations should only check the desnitation user id
            return _context.Notifications.Where(w => w.SharedTo == userId.ToString()).Count();
        }
        // POST: Notifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notifications = await _context.Notifications.FindAsync(id);
            _context.Notifications.Remove(notifications);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotificationsExists(int id)
        {
            return _context.Notifications.Any(e => e.Id == id);
        }
    }
}
