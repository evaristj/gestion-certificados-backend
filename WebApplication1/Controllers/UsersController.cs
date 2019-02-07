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
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            this._context = context;
            
            if (this._context.Users.Count() == 0)
            {
                Console.WriteLine("No existen usuarios.");
                Users usuario = new Users();
                usuario.username = "Evarist";
                usuario.password = Encrypt.Hash("12345");
                usuario.role = Role.admin;

                this._context.Users.Add(usuario);
                this._context.SaveChanges();
            }
            
            /*
            Users usuario2 = new Users();
            usuario2.username = "pepepa";
            usuario2.password = Encrypt.Hash("123123");

            this._context.Users.Add(usuario2);
            this._context.SaveChanges();
            */
        }

        // GET: api/users
        [HttpGet]
        public ActionResult<List<Users>> GetAll()
        {
            return this._context.Users.ToList();
        }

        // GET: api/users/5 encontrar user por id
        [HttpGet("{id}")]
        public ActionResult<Users> Get(long id)
        {
            Users user = this._context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // POST: api/Users crear usuarios
        [HttpPost]
        public ActionResult<Users> Post([FromBody] Users value)
        {
            if(value.username.Trim().Length < 4 || value.password.Trim().Length < 4 
                || value.password.Trim() == null || value.username.Trim() == null)
            {
                return StatusCode(411);
            }

            Users nameRepeat = _context.Users.Where(
                user => user.username.Trim() == value.username.Trim()).FirstOrDefault();
           
            if(nameRepeat == null)
            {
                value.username = value.username.Trim();
                value.password = Encrypt.Hash(value.password.Trim());
                this._context.Users.Add(value);
                this._context.SaveChanges();

                return value;
            }

            return StatusCode(409);

        }

        // PUT: api/Users/5 modificar usuario
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Users value)
        {
            Users user = this._context.Users.Find(id);
            user.username = value.username;
            user.password = Encrypt.Hash(value.password);
            user.role = value.role;
            this._context.SaveChanges();

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(long id)
        {
            Users userDelete = this._context.Users.Where(
                user => user.id == id).FirstOrDefault();
            if (userDelete == null)
            {
                return "usuario no existe";
            }

            // _context es el contexto de la entidad, de la aplicacion, para nosotros poder acceder
            // al contexto de la DB en este caso, se pueden añadir más contextos en su respectiva clase
            // se inyecta, NO se importa
            this._context.Remove(userDelete);
            this._context.SaveChanges();

            return "Se ha borrado: " + userDelete.id;

        }
    }
}
