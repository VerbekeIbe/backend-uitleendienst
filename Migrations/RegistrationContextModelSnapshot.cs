﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend_uitleendienst.Data;

namespace backend_uitleendienst.Migrations
{
    [DbContext(typeof(RegistrationContext))]
    partial class RegistrationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("backend_uitleendienst.Models.Lener", b =>
                {
                    b.Property<Guid>("LenerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Voornaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LenerId");

                    b.ToTable("Leners");

                    b.HasData(
                        new
                        {
                            LenerId = new Guid("a1239221-2ed4-4ade-9ce7-bc8f3919452f"),
                            Email = "ibeverbeke@gmail.com",
                            Naam = "Verbeke",
                            Voornaam = "Ibe"
                        },
                        new
                        {
                            LenerId = new Guid("d0c69252-9673-4779-bd9c-bbbdcd733dd9"),
                            Email = "briekverbeke@gmail.com",
                            Naam = "Verbeke",
                            Voornaam = "Briek"
                        },
                        new
                        {
                            LenerId = new Guid("0fec10f8-30a2-411e-bebb-130b076ddf3f"),
                            Email = "robbeverdonck003@gmail.com",
                            Naam = "Verdonck",
                            Voornaam = "Robbe"
                        });
                });

            modelBuilder.Entity("backend_uitleendienst.Models.Lening", b =>
                {
                    b.Property<Guid>("LeningId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Hoeveelheid")
                        .HasColumnType("int");

                    b.Property<Guid>("LenerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MateriaalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Pending")
                        .HasColumnType("bit");

                    b.HasKey("LeningId");

                    b.ToTable("Leningen");
                });

            modelBuilder.Entity("backend_uitleendienst.Models.Materiaal", b =>
                {
                    b.Property<Guid>("MateriaalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Categorie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Drempel")
                        .HasColumnType("int");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("MateriaalId");

                    b.ToTable("Materiaal");

                    b.HasData(
                        new
                        {
                            MateriaalId = new Guid("53f01f4a-0586-4859-a6df-a1d0045e62a8"),
                            Categorie = "Klein",
                            Drempel = 1,
                            Naam = "Pak Wit Papier",
                            Stock = 4
                        },
                        new
                        {
                            MateriaalId = new Guid("f9f211a4-7c7f-4cbd-a063-0eee6f614df5"),
                            Categorie = "Keuken",
                            Drempel = 1,
                            Naam = "Pak Schuursponsjes",
                            Stock = 6
                        },
                        new
                        {
                            MateriaalId = new Guid("479880c8-effa-4681-abba-106e9a987995"),
                            Categorie = "Klein",
                            Drempel = 2,
                            Naam = "Voetbal",
                            Stock = 5
                        },
                        new
                        {
                            MateriaalId = new Guid("f8cd3eef-2535-4065-8fe5-994261a31c90"),
                            Categorie = "Bar",
                            Drempel = 4,
                            Naam = "Bakken Bier",
                            Stock = 1
                        },
                        new
                        {
                            MateriaalId = new Guid("93ebaf7e-69f6-4d1d-848a-f077ed69663d"),
                            Categorie = "Groot",
                            Drempel = 1,
                            Naam = "Zak Kolen BBQ",
                            Stock = 4
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
