using Microsoft.EntityFrameworkCore;
using Opdracht1.Models;

namespace Opdracht1.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
    }
}