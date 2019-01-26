using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiGTT.Models;

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
            if (this._context.Jira.Count() == 0)
            {
                Console.WriteLine("No existen usuarios de jira.");
                Jira jiraUser = new Jira();
                jiraUser.username = "pakita";
                jiraUser.password = "12345";

                this._context.Jira.Add(jiraUser);
                this._context.SaveChanges();
            }
        }

        // GET: api/jira
        [HttpGet]
        public ActionResult<List<Jira>> GetAll()
        {
            return this._context.Jira.ToList();
        }

        // GET: api/Jira/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Jira
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Jira/5
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
