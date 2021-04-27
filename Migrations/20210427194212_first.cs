using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend_uitleendienst.Migrations
{
    public partial class first : Migration
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
