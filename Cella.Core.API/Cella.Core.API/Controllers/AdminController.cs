using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cella.Domain;
using Cella.Models;
using Cella.Services;
using Cella.Services.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CellaCrm.Core.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AdminController  : ControllerBase

{
    
    private readonly UserManager<ApplicationUser> userManager;
    private readonly RoleManager<IdentityRole> roleManager;
    private readonly IConfiguration _configuration;
    private readonly CellaDBContext _context;
    private IUserService _userService;
    public AdminController(IUserService userService,CellaDBContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
        _userService = userService;
        _configuration = configuration;
        _context = context;
    }
    
    [AllowAnonymous]
    [HttpPost("/Login")]
    public async Task<ActionResult> Login([FromBody] AuthenticateRequest model)
    {
        var response = await _userService.Authenticate(model, ipAddress());
        if (response == null)
            return Unauthorized(new { message = "Login Details invalid" });

        setTokenCookie(response.JwtToken);
        return Ok(response);
    }
    
    [HttpPost]
    [Route("register-admin")]
    public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
    {
        var userExists = await userManager.FindByNameAsync(model.Username);
        if (userExists != null)
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

        ApplicationUser user = new ApplicationUser()
        {
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            EmailConfirmed = true,
            LockoutEnabled = false,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.Username
        };
        try
        {
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                StringBuilder errors = new StringBuilder();
             foreach (var item in result.Errors)
                {
                    errors.Append(item.Description);
                }
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response
                    {
                        Status = "Error",
                        ErrorExceptionMessage= errors.ToString(),
                        Message = "User creation failed! Please check user details and try again."
                    });
            }
        }
        catch (Exception ex)

        {
            
        }
        if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
            await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

        if (await roleManager.RoleExistsAsync(UserRoles.Admin))
        {
            await userManager.AddToRoleAsync(user, UserRoles.Admin);
        }

        return Ok();
    }
    private void setTokenCookie(string token)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddDays(7)
        };
        Response.Cookies.Append("refreshToken", token, cookieOptions);
    }
    private string ipAddress()
    {
        if (Request.Headers.ContainsKey("X-Forwarded-For"))
            return Request.Headers["X-Forwarded-For"];
        else
            return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
    }
}