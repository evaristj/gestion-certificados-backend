using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiGTT.Models;
using ApiGTT.Helpers;

namespace ApiGTT.Controllers
{
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

        /*
        // GET: api/Auth/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        */

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
                Console.WriteLine(value.username + "***************");

                if (userNameLogin.password.Trim() == Encrypt.Hash(value.password.Trim()) 
                    && userNameLogin.username.Trim() == value.username.Trim())
                {
                    return Ok(userNameLogin);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error  => " + ex.Message);
                return NotFound();
            }
            Console.WriteLine("usuario o contraseña incorrectas ***********************");

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
