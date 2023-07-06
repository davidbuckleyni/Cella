using Microsoft.AspNetCore.Mvc;

namespace CellaCrm.Core.API.Controllers;

public class ControllerBase:Controller
{
   

        public int? UserId { get; set; }
     
}