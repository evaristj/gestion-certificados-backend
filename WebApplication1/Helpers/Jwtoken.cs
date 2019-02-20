using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ApiGTT.Models;
/*
 * Author Evarist J.
 */

namespace ApiGTT.Helpers
{
    public class Jwtoken
    {

        private readonly AppDbContext _context;

        public Jwtoken(AppDbContext context)
        {
            this._context = context;
        }

        public static JwtSecurityToken BuildToken(Users data)
        {
            // datos de usuario que queremos que aparezcan en el payload
            var claims = new[]{
              new Claim(ClaimTypes.Name, data.username),
              new Claim(ClaimTypes.NameIdentifier, data.id.ToString()),
              new Claim(ClaimTypes.Role, data.role.ToString())
          };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("123456 secretsecretsecret"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "Evarist S.A",
                audience: "Evarist S.A",
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
            return token;
        }
    }
}
