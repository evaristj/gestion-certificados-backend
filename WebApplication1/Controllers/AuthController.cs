using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiGTT.Models;
using ApiGTT.Helpers;

using System.IdentityModel.Tokens.Jwt;
/*
 * Author Evarist J.
 */

namespace ApiGTT.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context) {
            this._context = context;
        }

        // GET: api/Auth
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST: api/auth
        [HttpPost]
        public ActionResult Post([FromBody] Users value)
        {
            try
            {
                if (value.username.Trim().Length < 4 || value.username == null 
                    || value.password.Trim().Length < 4 || value.password == null)
                {
                    return StatusCode(411);
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
           

            try {
                Users userNameLogin = this._context.Users.Where(
                user => user.username.Trim() == value.username.Trim()).First();

                if (userNameLogin.password.Trim() == Encrypt.Hash(value.password.Trim()) 
                    && userNameLogin.username.Trim() == value.username.Trim())
                {
                    JwtSecurityToken token = Jwtoken.BuildToken(userNameLogin);
                    var handlerToken = new JwtSecurityTokenHandler().WriteToken(token);
                    var sendToken = new { handlerToken, userNameLogin.id, userNameLogin.role, userNameLogin.username };

                    return Ok(sendToken);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error  => " + ex.Message);
                return NotFound();
            }

            return Unauthorized();
            
        }

        // PUT: api/Auth/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
