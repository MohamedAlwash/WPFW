using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

public class MyDatabase : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder b) => b.UseSqlServer("Server=localhost;Database=master;Trusted_Connection=True;");
    
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<Car> Cars { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Owner>()
        .HasIndex(o => o.Email).IsUnique();
        modelBuilder.Entity<Tenant>()
        .HasIndex(t => t.Email).IsUnique();
        modelBuilder.Entity<LeaseAgreement>()
        .HasKey(key => new { key.CarId, key.TenantId });
    }

}

public class Owner
{
    [Key]
    public int Id { get; set; }
    [Required]
    public String Name { get; set; }
    public int PhoneNumber { get; set; }
    [Required]
    public String Email { get; set; }
    [Required]
    public String Address { get; set; }
    [InverseProperty("Owner")]
    public List<Car> Car { get; set; }

}

public class Tenant
{
    [Key]
    public int Id { get; set; }
    [Required]
    public String Name { get; set; }
    public int PhoneNumber { get; set; }
    [Required]
    public String Email { get; set; }
    public String Address { get; set; }
}

public class Car
{
    [Key]
    public int Id { get; set; }
    [Required]
    public String Brand { get; set; }
}

public class LeaseAgreement
{
    [Required]
    [ForeignKey("CarId")]
    public int CarId { get; set; }
    [Required]
    [ForeignKey("TentantId")]
    public int TenantId { get; set; }
    [Required]
    public DateTime BeginDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
}

public class DummyData
{

    public static void AddDummyToDatabase()
    {

        MyDatabase m = new MyDatabase();

        m.Owners.Add(new Owner() { Name = "Mohamed", Email = "Mohamed@live.com", PhoneNumber = 06186654,  Address = "Prinses Annalaan 520" } );
        m.Owners.Add(new Owner() { Name = "Kees", Email = "Kees@live.com", Address = "Hofkade 220" } );
        m.Owners.Add(new Owner() { Name = "Kevin", Email = "Kevin@live.com", PhoneNumber = 0655465, Address = "Wassenaar 280" } );

        m.Tenants.Add(new Tenant() { Name = "Richard", Email = "Richard@live.com", PhoneNumber = 06186654,  Address = "Spakeburgsestraat"});
        m.Tenants.Add(new Tenant() { Name = "Ali", Email = "Ali@live.com", PhoneNumber = 06186654,  Address = "Spakeburgsestraat"});
        m.Tenants.Add(new Tenant() { Name = "Han", Email = "Han@live.com", PhoneNumber = 06186654,  Address = "Spakeburgsestraat"});

        m.SaveChanges();
    }
}