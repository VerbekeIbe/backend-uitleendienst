using System;
using backend_uitleendienst.Configuration;
using backend_uitleendienst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace backend_uitleendienst.Data
{
    public class RegistrationContext : DbContext
    {
        public DbSet<Lener> Leners { get; set; }
        public DbSet<Lening> Leningen { get; set; }
        public DbSet<Materiaal> Materiaal { get; set; }

        private ConnectionStrings _connectionStrings;

        public RegistrationContext(DbContextOptions<RegistrationContext> options, IOptions<ConnectionStrings> connectionstrings){
            _connectionStrings = connectionstrings.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options){
            options.UseSqlServer(_connectionStrings.SQL);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Lener>().HasData(new Lener(){
                LenerId = Guid.NewGuid(),
                Naam = "Verbeke",
                Voornaam = "Ibe",
                Email = "ibeverbeke@gmail.com"
            });
            modelBuilder.Entity<Lener>().HasData(new Lener(){
                LenerId = Guid.NewGuid(),
                Naam = "Verbeke",
                Voornaam = "Briek",
                Email = "briekverbeke@gmail.com"
            });
            modelBuilder.Entity<Lener>().HasData(new Lener(){
                LenerId = Guid.NewGuid(),
                Naam = "Verdonck",
                Voornaam = "Robbe",
                Email = "robbeverdonck003@gmail.com"
            });

            modelBuilder.Entity<Materiaal>().HasData(new Materiaal(){
                MateriaalId = Guid.NewGuid(),
                    Naam = "Pak Wit Papier",
                    Stock = 4,
                    Categorie = "Klein",
                    Drempel = 1
            });
            modelBuilder.Entity<Materiaal>().HasData(new Materiaal(){
                MateriaalId = Guid.NewGuid(),
                    Naam = "Pak Schuursponsjes",
                    Stock = 6,
                    Categorie = "Keuken",
                    Drempel = 1
            });
            modelBuilder.Entity<Materiaal>().HasData(new Materiaal(){
                MateriaalId = Guid.NewGuid(),
                    Naam = "Voetbal",
                    Stock = 5,
                    Categorie = "Klein",
                    Drempel = 2
            });
            modelBuilder.Entity<Materiaal>().HasData(new Materiaal(){
                MateriaalId = Guid.NewGuid(),
                    Naam = "Bakken Bier",
                    Stock = 1,
                    Categorie = "Bar",
                    Drempel = 4
            });
            modelBuilder.Entity<Materiaal>().HasData(new Materiaal(){
                MateriaalId = Guid.NewGuid(),
                    Naam = "Zak Kolen BBQ",
                    Stock = 4,
                    Categorie = "Groot",
                    Drempel = 1
            });
        }
    }
}
