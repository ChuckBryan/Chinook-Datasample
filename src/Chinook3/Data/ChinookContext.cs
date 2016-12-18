namespace Chinook3.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class ChinookContext : DbContext
    {

        public ChinookContext(DbContextOptions options) : base(options)
        {
            
        }

        public ChinookContext()
        {
            
        }

        public DbSet<Album> Albums { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

           // optionsBuilder.UseSqlServer(@"server=.;Database=Chinook;Trusted_Connection=True;");
        }
    }
}