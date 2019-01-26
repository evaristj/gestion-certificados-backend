using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiGTT.Models
{
    //Extendemos de la clase DbContext
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Jira> Jira { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<Certificates> Certificates { get; set; }
    }
}
