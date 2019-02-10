﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/*
 * Author Evarist J.
 */

namespace ApiGTT.Models
{
    public enum Role { user, admin }

    public class Users
    {
        public long id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public Role role { get; set; }

        public Users()
        {
        }
    }
}
