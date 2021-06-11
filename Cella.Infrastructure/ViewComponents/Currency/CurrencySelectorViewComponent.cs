using Cella.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
namespace Cella.Infrastructure.ViewComponents.Currency
{
    public class CurrencySelectorViewComponent : CellaViewComponentBase
    {
        private CellaDBContext _cellaDBContext;
        public CurrencySelectorViewComponent(CellaDBContext cellaDBContext)
        {
            _cellaDBContext = cellaDBContext;
        }

        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var model = await _cellaDBContext.Currencies.ToListAsync();
            if (model.Count == 1)
                return View("");

            return View(model);
        }
    }
}
