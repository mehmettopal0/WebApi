using DataAccess;
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

        //private readonly IDictionary<string, string> autperson = new Dictionary<string, string>
        //{
        //    {"admin","admin12345" },{"user","user12345" }
        //};

        public string Authenticate(string userName, string password)
        {
            using (WebApiDbContext context = new WebApiDbContext())
            {
                User autperson = context.Users.FirstOrDefault(c => c.Name == userName);     

                if (autperson != null)
                {
                    if (autperson.Phone == password)
                    {
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
                                new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                        };
                        var token = tokenHandler.CreateToken(tokenDescriptor);
                        return tokenHandler.WriteToken(token);
                    }
                    return null;
                }

                return null;


            }






        }
    }
}
