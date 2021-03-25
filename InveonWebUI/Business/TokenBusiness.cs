using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace InveonWebUI.Business
{
    public class TokenBusiness
    {
        private string TokenKey = "This is my test private key";

        public TokenBusiness()
        {
           
        }

        public string GetUserName(string jwttoken)
        {
            var key = Encoding.ASCII.GetBytes(TokenKey);
            var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            var claims = handler.ValidateToken(jwttoken, validations, out var tokenSecure);
            return claims.Identity.Name;
        }

        public string GetUserId(string jwttoken)
        {
            var key = Encoding.ASCII.GetBytes(TokenKey);
            var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            var claims = handler.ValidateToken(jwttoken, validations, out var tokenSecure);
            return claims.FindFirstValue(ClaimTypes.UserData);
        }

        public string GetUserType(string jwttoken)
        {
            var key = Encoding.ASCII.GetBytes(TokenKey);
            var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            var claims = handler.ValidateToken(jwttoken, validations, out var tokenSecure);
            return claims.FindFirstValue(ClaimTypes.Role);
        }
    }
}
