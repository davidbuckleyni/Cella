using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using System.Linq;

using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Cella.Models;
using Cella.Services;
using Cella.Services.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace CellaCrm.Core.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase {
        private IUserService _userService;

        public UsersController(IUserService userService) {
            _userService = userService;
        }

        private void setTokenCookie(string token) {
            var cookieOptions = new CookieOptions {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }

        private string ipAddress() {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("user/GetAllUsers")]
        public IActionResult GetAllUsers() {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequest model) {

            var response = await _userService.Authenticate(model, ipAddress());

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            setTokenCookie(response.JwtToken);

            return Ok(response);
        }
    }
}
