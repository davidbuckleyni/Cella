using Cella.BL.Interfaces;
using Cella.Models.ViewModels;
using Cella.Services.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Cella.Domain;
using Syncfusion.EJ2.Linq;
using System.Linq;
using Cella.Models;

namespace Cella.Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockItemController :   ControllerBase
    {
        private IStockItemInterface _stockItemInterface;

         private CellaDBContext _context;

        
         public StockItemController(IStockItemInterface stockItemInterface, CellaDBContext cellaDBContext)
        {
            _stockItemInterface = stockItemInterface;
            _context = cellaDBContext;
        }

        [HttpGet("GetAllStockItems")]
        public IEnumerable<StockItem> GetAllStockItems()
        {
            return _context.StockItem.Where(W => W.IsActive == true && W.isDeleted == false).AsEnumerable();

        }

        [HttpGet("GetStockById")]
        public IEnumerable<StockItem> GetAllStockById(int id)
        {
            return _context.StockItem.Where(W => W.IsActive == true && W.isDeleted == false && W.Id==id).AsEnumerable();

        }

    }
}
