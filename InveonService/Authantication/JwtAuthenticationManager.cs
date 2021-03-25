using InveonService.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InveonService.Authantication
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly string tokenKey;

        public JwtAuthenticationManager(string token)
        {
            this.tokenKey = token;

        }
        public string Authenticate(User userData)
        {
            if (userData == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(tokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userData.UserName),
                    new Claim(ClaimTypes.UserData, userData.Id.ToString()),
                    new Claim(ClaimTypes.Role, userData.UserType)
                    

                }),
                Expires = DateTime.UtcNow.AddYears(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}

