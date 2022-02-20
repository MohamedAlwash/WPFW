using _7_MVC_2.Models;
using Microsoft.EntityFrameworkCore;
public class BoekDbContext : DbContext
{
    public BoekDbContext(DbContextOptions<BoekDbContext> options)
        : base(options)
    {
    }
    public DbSet<Boek> Boeken { get; set; }
}