using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ApiGTT.Helpers;
using ApiGTT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
/*
 * Author Evarist J.
 */

namespace ApiGTT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificatesController : ControllerBase
    {

        private readonly AppDbContext _context;

        public CertificatesController(AppDbContext context)
        {
            _context = context;
           
        }

        // GET: api/Certificates
        [HttpGet]
        public ActionResult<List<Certificates>> GetAll()
        {
            return this._context.Certificates.ToList();
        }
        

        
        // GET: api/Certificates/5
        [HttpGet("{id}")]
        public ActionResult<Certificates> Get(long id)
        {
            Certificates cert = this._context.Certificates.Find(id);

            if (cert == null)
            {
                return NotFound();
            }
            return cert;
        }


        // POST: api/Certificates
        [Authorize]
        [HttpPost]
        public ActionResult<X509Certificate2> Post([FromBody] Certificates value)
        {

            try
            {
                byte[] arrCifrado = Convert.FromBase64String(value.cifrado);

                value.password = Encrypt.Hash(value.password);

                X509Certificate2 certificate2 = new X509Certificate2(arrCifrado, value.password);

                value.caducidad = certificate2.NotAfter;
                value.num_serie = certificate2.GetSerialNumberString();
                value.subject = certificate2.Subject;
                value.entidad_emisora = certificate2.Issuer;


                this._context.Certificates.Add(value);
                this._context.SaveChanges();

                return certificate2;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(401);
            }            
           
        }

        // PUT: api/Certificates/5
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<Certificates> Put(long id, [FromBody] Certificates value)
        {
            Certificates cert = this._context.Certificates.Find(id);
            cert.eliminado = value.eliminado;
            this._context.SaveChanges();

            return cert;
        }

        // DELETE: api/ApiWithActions/5
        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
        }
    }
}
