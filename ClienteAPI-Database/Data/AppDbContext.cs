using ClienteAPI_Database.Model;
using Microsoft.EntityFrameworkCore;


namespace ClienteAPI_Database.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Cliente {get;set;}

        public DbSet<Usuario> Usuario { get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

     

    }
}
