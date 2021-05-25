using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cella.Models.ViewModels;
using Cella.Domain;

namespace CellaCrm.Core.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ThemeApiController : ControllerBase
    {


        private readonly ILogger<ThemeApiController> _logger;
        private CellaDBContext _context;
        public ThemeApiController(ILogger<ThemeApiController> logger,CellaDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
       
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IEnumerable<ThemeListItem> GetThemesByUserIdStoreId(Guid UserId, Guid StoreId)
        {
            return _context.ThemeSetup.Where(W => W.isActive == true && W.isDeleted == false && W.UserId == UserId && W.StoreId == StoreId).AsEnumerable();
            
        }
    }
}
