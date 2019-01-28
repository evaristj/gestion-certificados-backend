using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGTT.Models
{
    public class Certificates
    {
        public long id { get; set; }
        public string alias { get; set; }
        public string entidad_emisora { get; set; }
        public string num_serie { get; set; }
        public string subject { get; set; }
        public string caducidad { get; set; }
        public string password { get; set; }
        public string id_orga { get; set; }
        public string nombre_cliente { get; set; }
        public string contacto_renovacion { get; set; }
        public string repositorio_url { get; set; }
        public string observaciones { get; set; }
        public string integration_list { get; set; }

    /*
        alias varchar(32) not null unique,
    entidad_emisora varchar(32) not null,
    num_serie varchar(50) not null unique,
    subject varchar(32) not null,
    caducidad date not null,
    password varchar(32) not null,
    id_orga varchar(32) not null,
    nombre_cliente varchar(32) not null,
    contacto_renovacion varchar(32) not null,
    repositorio_url varchar(100) not null,
    observaciones longtext,
    integration_list varchar(200),
    user_id int not null,
    foreign key(user_id) references users(id)
    */
    }
}
