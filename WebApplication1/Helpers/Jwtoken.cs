using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ApiGTT.Models;

namespace ApiGTT.Helpers
{
    public class Jwtoken
    {

        public static JwtSecurityToken BuildToken(Users data)
        {
            var claims = new[]{
              new Claim("userName", data.username),
              new Claim("id", data.id.ToString()),
              new Claim("role", data.role.ToString())
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
