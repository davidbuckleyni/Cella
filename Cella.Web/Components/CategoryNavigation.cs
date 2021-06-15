using Cella.Domain;
using Cella.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cella.Web.Components
{
    public class CategoryNavigation : ViewComponent
    {
        private readonly CellaDBContext _context;
        public CategoryNavigation(CellaDBContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int currentCategoryId, int currentProductId)
        {
            CategoriesViewModel vm = new CategoriesViewModel();
            var categories = _context.Categories.ToList();
            vm.Categories = categories;
            return View(vm);

        }
    }
}
