using Microsoft.EntityFrameworkCore;


namespace RRelationnelle
{
   public class RrelationnelApiContext : DbContext
    {
       public RrelationnelApiContext(DbContextOptions<RrelationnelApiContext> options)
            : base(options)
        {
        }
        
        public DbSet<Ressource> Ressource { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Roles> Role { get; set; }
        public DbSet<Stats> Stats { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
