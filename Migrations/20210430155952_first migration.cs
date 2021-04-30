using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend_uitleendienst.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leners",
                columns: table => new
                {
                    LenerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leners", x => x.LenerId);
                });

            migrationBuilder.CreateTable(
                name: "Leningen",
                columns: table => new
                {
                    LeningId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hoeveelheid = table.Column<int>(type: "int", nullable: false),
                    Pending = table.Column<bool>(type: "bit", nullable: false),
                    MateriaalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LenerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leningen", x => x.LeningId);
                });

            migrationBuilder.CreateTable(
                name: "Materiaal",
                columns: table => new
                {
                    MateriaalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Categorie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Drempel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiaal", x => x.MateriaalId);
                });

            migrationBuilder.InsertData(
                table: "Leners",
                columns: new[] { "LenerId", "Email", "Naam", "Voornaam" },
                values: new object[,]
                {
                    { new Guid("7653ca70-8e38-4c3a-af36-6bb0a3cb727f"), "ibeverbeke@gmail.com", "Verbeke", "Ibe" },
                    { new Guid("d709a6a5-1863-4922-83eb-7f0399c6c7f7"), "briekverbeke@gmail.com", "Verbeke", "Briek" },
                    { new Guid("eb1ba35d-c03b-4e9a-802f-c228abdcac45"), "robbeverdonck003@gmail.com", "Verdonck", "Robbe" }
                });

            migrationBuilder.InsertData(
                table: "Materiaal",
                columns: new[] { "MateriaalId", "Categorie", "Drempel", "Naam", "Stock" },
                values: new object[,]
                {
                    { new Guid("cb18b43d-a701-426f-b355-e40da34d1a38"), "Klein", 1, "Pak Wit Papier", 4 },
                    { new Guid("5afc7017-9d37-41f1-bb46-42e8e8dddfcd"), "Keuken", 1, "Pak Schuursponsjes", 6 },
                    { new Guid("c6017e86-80b3-48b3-a43f-447ad6a7df88"), "Klein", 2, "Voetbal", 5 },
                    { new Guid("58ffc5f8-9952-4704-87ae-4f246989debd"), "Bar", 4, "Bakken Bier", 1 },
                    { new Guid("1b7235e4-3e02-4b15-bc82-1dfbdb24ba54"), "Groot", 1, "Zak Kolen BBQ", 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leners");

            migrationBuilder.DropTable(
                name: "Leningen");

            migrationBuilder.DropTable(
                name: "Materiaal");
        }
    }
}
