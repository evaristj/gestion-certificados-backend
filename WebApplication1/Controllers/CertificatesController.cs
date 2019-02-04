﻿using System;
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
        public ActionResult<Certificates> Post([FromBody] Certificates value)
        {

            Certificates certificatesRepeat = new Certificates();

            try
            {
                if (value.alias.Trim().Length < 4 || value.alias.Trim() == null
                    || value.id_orga.Trim().Length < 4 || value.id_orga.Trim() == null
                    || value.nombre_cliente.Trim().Length < 4 || value.nombre_cliente.Trim() == null
                    || value.contacto_renovacion.Trim().Length < 4 || value.contacto_renovacion.Trim() == null)
                {
                    return StatusCode(411);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("error en la longitud de los campos del usuario.");
                return Unauthorized();           
            }

            try
            {
                certificatesRepeat = _context.Certificates.Where(
                    cert => cert.num_serie.Trim() == value.num_serie.Trim()).FirstOrDefault();
                if (certificatesRepeat != null)
                    return StatusCode(409);
            }
            catch (Exception)
            {
                Console.WriteLine("error el comprobar el usuario en la base de datos.");
                return Unauthorized();
            }

            try
            {
                if (certificatesRepeat == null)
                {
                    value.alias = value.alias;
                    value.contacto_renovacion = value.contacto_renovacion.Trim();
                    value.entidad_emisora = value.entidad_emisora.Trim();
                    value.id_orga = value.id_orga;
                    value.integration_list = value.integration_list.Trim();
                    value.nombre_cliente = value.nombre_cliente.Trim();
                    value.num_serie = value.num_serie;
                    value.password = Encrypt.Hash(value.password.Trim());
                    value.observaciones = value.observaciones.Trim();
                    value.repositorio_url = value.repositorio_url.Trim();
                    value.subject = value.subject.Trim();
                    value.caducidad = DateTime.UtcNow;
                    this._context.Certificates.Add(value);
                    this._context.SaveChanges();
                }
                return value;
            }
            catch (Exception)
            {
                Console.WriteLine("error al crear el usuario.");
            }

            return StatusCode(409);

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
