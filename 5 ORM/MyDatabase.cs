using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

public class MyDatabase : DbContext
{
    protected override void OnConfiguring(
        DbContextOptionsBuilder builder) =>
        builder.UseSqlServer("Server=localhost;Database=master;Trusted_Connection=True;");

    public DbSet<Huurder> Huurder { get; set; }
    public DbSet<Verhuurder> Verhuurder { get; set; }
    public DbSet<Auto> Auto { get; set; }
    public DbSet<HuurContract> HuurContract { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Huurder>()
        .HasIndex(h => h.Email)
        .IsUnique();

        modelBuilder.Entity<Verhuurder>()
        .HasIndex(v => v.Email)
        .IsUnique();

        modelBuilder.Entity<HuurContract>()
        .HasKey(h => new { h.HuurderId, h.AutoId });
    }

    // public static void DummyData()
    // {
    //     MyDatabase myData = new MyDatabase();
    //     myData.Huurder.Add(new Huurder() { Naam = "Kees", TelNummer = "0546846", Email = "mohamed@live.nl", Adres = "Prins Annalaan" });
    //     myData.Huurder.Add(new Huurder() { Naam = "Mo", TelNummer = "6564864", Email = "mo@live.nl", Adres = "Prins Annalaan" });

    //     myData.Verhuurder.Add(new Verhuurder()
    //     {
    //         Naam = "Hans",
    //         TelNummer = "265486",
    //         Email = "hans@live.nl",
    //         Adres = "Prins Annalaan",
    //     });
    //     myData.Verhuurder.Add(new Verhuurder()
    //     {
    //         Naam = "Johan",
    //         TelNummer = "265486",
    //         Email = "Johan@live.nl",
    //         Adres = "Kijezerstaat"
    //     });

    //     myData.Auto.Add(new Auto() {Merk = "BMW"});
    //     myData.Auto.Add(new Auto() {Merk = "Audi"});

    //     myData.SaveChanges();
    // }
}

// id, naam, tel-nummer, email (uniek), adres
[Table("Huurders")]
public class Huurder
{
    [Required] public int Id { get; set; }
    public string Naam { get; set; }
    public string TelNummer { get; set; }
    public string Email { get; set; }
    public string Adres { get; set; }
}

// id, naam, tel-nummer, email, adres (not null)
public class Verhuurder
{
    [Required] public int Id { get; set; }
    public string Naam { get; set; }
    public string TelNummer { get; set; }
    public string Email { get; set; }
    [Required] public string Adres { get; set; }

    // [InverseProperty("Verhuurder")]
    public List<Auto> Auto { get; set; }
}

// id, merk
public class Auto
{
    [Required] public int Id { get; set; }
    public string Merk { get; set; }
}

// HuurderId, AutoId, BeginDatum, EindDatum
public class HuurContract
{
    [ForeignKey("huurder_fk")]
    [Key] public int HuurderId { get; set; }

    [ForeignKey("auto_fk")]
    [Key] public int AutoId { get; set; }

    [Required] public DateTime BeginDatum { get; set; }

    [Required] public DateTime EindDatum { get; set; }
}