using week9Xunit1.Models;
using Microsoft.EntityFrameworkCore;

namespace week9Xunit1.Data
{
    public class BoekDbContext : DbContext
    {
        public BoekDbContext(DbContextOptions<BoekDbContext> options)
            : base(options)
        {
        }
        public DbSet<Boek> Boeken { get; set; }
    }
}