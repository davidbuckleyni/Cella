 
using System;
using System.Text.Json.Serialization;

namespace Cella.Models{
    public class AuthenticateResponse {
        [JsonIgnore] // refresh token is returned in http only cookie 
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string JwtToken { get; set; }

        [JsonIgnore] // refresh token is returned in http only cookie
        public string RefreshToken { get; set; }
     
        public AuthenticateResponse(ApplicationUser user, string jwtToken, string refreshToken,int playerId, ErrorModel? error)
        { 
            Id =user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.UserName;
            JwtToken = jwtToken;
            RefreshToken = refreshToken;
          
        }
    }
}