using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ServerLibrary.DTO.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Repo.Services
{
    public class JWTService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _jwtkey;

        public JWTService(IConfiguration config) // Injecting IConfiguration
        {
            _config = config;
            _jwtkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"])); // Get jwt key from appsettings.json
        }

        public string CreateJWT(User user) 
        {
            // Claims for token
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
            };

            
            var credentials = new SigningCredentials(_jwtkey, SecurityAlgorithms.HmacSha256); // Create credentials for token with key and algorithm
            var tokenDescriptor = new SecurityTokenDescriptor  // Create token descriptor with claims, expiry date, credentials, issuer 
            {
                Subject = new ClaimsIdentity(userClaims),
                Expires = DateTime.Now.AddDays(int.Parse(_config["Jwt:ExpireInDays"])), // Get expiry date from appsettings.json
                SigningCredentials = credentials,
                Issuer = _config["Jwt:Issuer"], // Get issuer from appsettings.json
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwt = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(jwt);
        }
    }
}
