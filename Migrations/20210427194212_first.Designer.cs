﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend_uitleendienst.Data;

namespace backend_uitleendienst.Migrations
{
    [DbContext(typeof(RegistrationContext))]
    [Migration("20210427194212_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                });
#pragma warning restore 612, 618
        }
    }
}