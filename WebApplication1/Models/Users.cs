﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGTT.Models
{
    public class Users
    {
        public long id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public string email { get; set; }

        public Users()
        {
        }
    }
}
