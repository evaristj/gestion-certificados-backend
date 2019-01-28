using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGTT.Models
{
    public class Jira
    {
        public long id { get; set; }
        public Users user_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string url { get; set; }
        public string project { get; set; }
        public string component { get; set; }
        
        /*
            user_id int primary key,
	        foreign key(user_id) references users(id),
            username varchar(32) unique not null,
            password varchar(32) not null,
            url varchar(32) not null,
            project varchar(32) not null,
            component varchar(32) not null
         */

    }
}
