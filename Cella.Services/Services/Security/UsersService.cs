using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Cella.Models;
using Cella.Models.App;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Cella.Services.Security;

public class UsersService :IUserService
{

    // users hardcoded for simplicity, store in a db with hashed passwords in production applications
    private List<User> _users = new List<User>
    {
        new User { Id=1, Username="David",Password="Test12345" }
    };

    public Appsettings _appSettings;
    public UserManager<ApplicationUser> userManager;
    public SignInManager<ApplicationUser> signinManager;

    public UsersService(IOptions<Appsettings> appSettings, UserManager<ApplicationUser> user, SignInManager<ApplicationUser> signin)
    {
        _appSettings = appSettings.Value;
        userManager = user;
        signinManager = signin;
    }
    public bool RevokeToken(string token, string ipAddress)
    {
        var user = _users.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));

//if no user found with token
        if (user == null) return false;        // return false 

        var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

        // return false if token is not active
        if (!refreshToken.IsActive) return false;

        // revoke token and save
        refreshToken.Revoked = DateTime.UtcNow;
        refreshToken.RevokedByIp = ipAddress;


        return true;
    }

    public User GetById(int id)
    {
        return _users.Where(w => w.Id == id).FirstOrDefault();
    }
    public IEnumerable<User> GetAll()
    {
        return _users;
    }
    private string generateJwtToken(ApplicationUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Id.ToString())
            }),
            Expires = DateTime.UtcNow.AddMinutes(15),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    
    
    private RefreshToken generateRefreshToken(string ipAddress)
    {
        using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
        {
            var randomBytes = new byte[64];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomBytes),
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow,
                CreatedByIp = ipAddress
            };
        }
    }
    public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model, string ipAddress)
    {

        var user = await userManager.FindByEmailAsync(model.Username);

        var validCredentials = await signinManager.UserManager.CheckPasswordAsync(user, model.Password);
        StringContent httpContent;
        ErrorModel error = new ErrorModel();
            
        if (validCredentials == false)
        {
            var tags = new List<string>() { "Authentication", "Login" };
            error.ErrorMessage = "Authentication Failure";
            error.EventName = "Authentication";
            error.ErrorDate = DateTime.UtcNow;
            error.StatusCode = System.Net.HttpStatusCode.Unauthorized;
            

        }
        // return null if user not found
        if (user == null)
            return null;
         // authentication successful so generate jwt and refresh tokens
        var jwtToken = generateJwtToken(user);
        //  var refreshToken = generateRefreshToken(ipAddress);

        // save refresh token
        //user.RefreshTokens.Add(refreshToken);

        return new AuthenticateResponse(user, jwtToken, null,0,error);

    }


}

 
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model, string ipAddress);

        bool RevokeToken(string token, string ipAddress);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
 