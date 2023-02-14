using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle
{

    //test23
    
   public class RrelationnelApiContext : DbContext
    {
       public RrelationnelApiContext(DbContextOptions<RrelationnelApiContext> options)
            : base(options)
        {
        }
        
        public DbSet<Ressource> Ressource { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Categorie> Category { get; set; }
        public DbSet<Roles> Role { get; set; }
        public DbSet<StatsDto> Stats { get; set; }
        public DbSet<Comments> Comments { get; set; }
    }
}
