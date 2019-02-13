using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/*
 * Author Evarist J.
 */

namespace ApiGTT.Models
{
    public class Certificates
    {
        public long id { get; set; }
        public string alias { get; set; }
        public string entidad_emisora { get; set; }
        public string num_serie { get; set; }
        public string subject { get; set; }
        public DateTime caducidad { get; set; }
        public string password { get; set; }
        public string id_orga { get; set; }
        public string nombre_cliente { get; set; }
        public string contacto_renovacion { get; set; }
        public string repositorio_url { get; set; }
        public string observaciones { get; set; }
        public string integration_list { get; set; }
        public Boolean eliminado { get; set; }
        public string cifrado { get; set; }
        public string nombre_archivo { get; set; }
        public Boolean caducado { get; set; }
        public Boolean proxCaducidad { get; set; }

    }
}
