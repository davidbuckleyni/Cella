using System;
using System.Collections;
using Cella.Domain;
using Cella.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NToastNotify;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Cella.BL.Services;

public class StockService
{ 
    private CellaDBContext _context;
    private readonly IToastNotification _toast;

    public StockService(CellaDBContext context, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleMgr, IToastNotification toast)
    {
        _context = context;
        _toast = toast;
    }


    public void AddStockItem(StockItem stockItem)
    {
        _context.StockItem.Add(stockItem);
        _context.SaveChanges();
    }

    public void UpdateStockItem(StockItem stockItem)
    {
        var existingStockItemRecord = _context.StockItem.Where(w => w.Id == stockItem.Id).FirstOrDefault();
        
        _context.Entry(existingStockItemRecord).CurrentValues.SetValues(stockItem);

        _context.SaveChanges();
    }

    
    public bool DeleteStockItem(StockItem stockItem)
    {
        var existingStockItemRecord = _context.StockItem.Where(w => w.Id == stockItem.Id).FirstOrDefault();
        bool isDeleted = false;
        try
        {
            _context.StockItem.Remove(existingStockItemRecord);
            isDeleted=true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            isDeleted=false;
        }

        return isDeleted;
    }

    public async Task<IEnumerable<StockItem>> GetStockItems()
    {
        return _context.StockItem.Where(w => w.IsActive == true && w.isDeleted == false).AsEnumerable();
    }
}