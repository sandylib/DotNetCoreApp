using Microsoft.EntityFrameworkCore;

namespace DotnetCoreApp.Entities
{
    public class DotnetCoreAppDbContext : DbContext
    {
        public DotnetCoreAppDbContext(DbContextOptions options):base(options)
        {

            
        }
        public DbSet<MovieData> Movies { get; set; }
    }
}
