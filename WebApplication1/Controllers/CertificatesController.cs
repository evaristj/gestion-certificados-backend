using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiGTT.Helpers;
using ApiGTT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGTT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificatesController : ControllerBase
    {

        private readonly AppDbContext _context;

        public CertificatesController(AppDbContext context)
        {
            this._context = context;
            Users userPrueba = this._context.Users.FirstOrDefault();

            // certificates.user_id.id = userPrueba.id;

            if (this._context.Certificates.Count() == 0)
            {
                Console.WriteLine("No existen Certificados.");
                Certificates certificates = new Certificates();
                certificates.alias = "Evarist Certificated";
                certificates.contacto_renovacion = "asd";
                certificates.entidad_emisora = "asd";
                certificates.id_orga = "asd";
                certificates.integration_list = "asd";
                certificates.nombre_cliente = "asd";
                certificates.num_serie = "asd";
                certificates.password = Encrypt.Hash("12345");
                certificates.observaciones = "asd";
                certificates.repositorio_url = "asd";
                certificates.subject = "asd";
                certificates.caducidad = new DateTime();
                //certificates.user_id.id = 3;
                // usuario.password = "12345";
                this._context.Certificates.Add(certificates);
                this._context.SaveChanges();
            }
           
        }

        // GET: api/Certificates
        [HttpGet]
        public ActionResult<List<Certificates>> GetAll()
        {
            return _context.Certificates.ToList();
        }
        

            /*
        // GET: api/Certificates/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        */

        // POST: api/Certificates
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Certificates/5
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
