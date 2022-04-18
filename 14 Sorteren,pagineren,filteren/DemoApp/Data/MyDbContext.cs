using DemoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}