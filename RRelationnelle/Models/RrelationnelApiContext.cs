using Microsoft.EntityFrameworkCore;
using RessourcesRelationelles.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle.Models
{

    //test23
    
   public class RrelationnelApiContext : DbContext
    {
        public RrelationnelApiContext(DbContextOptions<RrelationnelApiContext> options)
            : base(options)
        {
        }
        
        public DbSet<Ressource> Ressource { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
