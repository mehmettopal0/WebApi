using Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Authentication
{
    class JWTAuthenticationManager : IJWTAuthenticationManager
    {
        private string _key;
        public JWTAuthenticationManager(string key)
        {
            _key = key;
        }
        private readonly IDictionary<string, string> autperson = new Dictionary<string, string>
        {
            {"admin","admin12345" },{"user","user12345" }
        };
        public string Authenticate(string userName, string password)
        {
            if (!autperson.Any(x => x.Key == userName && x.Value == password))
            {
                return null;
            }


            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,userName)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
