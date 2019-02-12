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

                X509Certificate2 certificate2 = new X509Certificate2(arrCifrado, value.password);

                Certificates certRepeat = _context.Certificates.Where(
                    cert => cert.num_serie.Trim() == certificate2.GetSerialNumberString()).FirstOrDefault();

                if (certRepeat == null)
                {
                    value.password = Encrypt.Hash(value.password);
                    value.caducidad = certificate2.NotAfter;
                    value.num_serie = certificate2.GetSerialNumberString();
                    value.subject = certificate2.Subject;
                    value.entidad_emisora = certificate2.Issuer;

                    this._context.Certificates.Add(value);
                    this._context.SaveChanges();

                    return certificate2;
                }
                return StatusCode(409);
                


                
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
            try
            {
                Certificates cert = this._context.Certificates.Find(id);
                cert.alias = value.alias;
                cert.contacto_renovacion = value.contacto_renovacion;
                cert.id_orga = value.id_orga;
                cert.nombre_cliente = cert.id_orga;
                cert.nombre_archivo = value.nombre_archivo;
                cert.integration_list = value.integration_list;
                cert.observaciones = value.observaciones;
                cert.repositorio_url = value.repositorio_url;
                cert.eliminado = value.eliminado;
                this._context.SaveChanges();

                return cert;
            }
            catch (Exception)
            {
                return Unauthorized();
            }
            
        }

        // DELETE: api/ApiWithActions/5
        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
        }
    }
}
