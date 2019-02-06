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
    public class JiraController : ControllerBase
    {

        private readonly AppDbContext _context;

        public JiraController(AppDbContext context)
        {
            this._context = context;

            // comentamos la creacion de este usuario porque de momento no nos interesa
            /*
            if (this._context.Jira.Count() == 0)
            {
                Console.WriteLine("No existen usuarios de jira.");
                Jira jiraUser = new Jira();
                jiraUser.username = "pakita";
                jiraUser.password = Encrypt.Hash("12345");

                this._context.Jira.Add(jiraUser);
                this._context.SaveChanges();
            }
            */
        }

        // GET: api/jira
        [HttpGet]
        public ActionResult<List<Jira>> GetAll()
        {
            return this._context.Jira.ToList();
        }

        // GET: api/Jira/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Jira> Get(long id)
        {
            Jira jira = this._context.Jira.Find(id);
            if (jira == null)
            {
                return NotFound();
            }
            return jira;
        }

        // POST: api/Jira - crear usuario jira
        [HttpPost]
        public ActionResult<Jira> Post([FromBody] Jira value)
        {
            if (value.username.Trim().Length < 4 || value.password.Trim().Length < 4
                || value.password.Trim() == null || value.username.Trim() == null)
            {
                return StatusCode(411);
            }

            Jira nameRepeat = _context.Jira.Where(
                jira => jira.username.Trim() == value.username.Trim()).FirstOrDefault();

            if (nameRepeat == null)
            {
                value.user_id = value.user_id;
                value.username = value.username.Trim();
                value.password = Encrypt.Hash(value.password.Trim());
                this._context.Jira.Add(value);
                this._context.SaveChanges();

                return value;
            }

            return Unauthorized();

        }

        // PUT: api/Jira/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Jira value)
        {
            Jira jira = this._context.Jira.Find(id);
            jira.user_id = value.user_id;
            jira.username = value.username;
            jira.password = Encrypt.Hash(value.password);
            jira.url = value.url;
            jira.project = value.project;
            jira.component = value.component;
            this._context.SaveChanges();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(long id)
        {
            Jira jiraUserDelete = this._context.Jira.Where(
                jira => jira.id == id).FirstOrDefault();
            if (jiraUserDelete == null)
            {
                return "usuario no existe";
            }

            // _context es el contexto de la entidad, de la aplicacion, para nosotros poder acceder
            // al contexto de la DB en este caso, se pueden añadir más contextos en su respectiva clase
            // se inyecta, NO se importa
            this._context.Remove(jiraUserDelete);
            this._context.SaveChanges();

            return "Se ha borrado: " + jiraUserDelete.id;
        }
    }
}
