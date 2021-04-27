using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend_uitleendienst.Migrations
{
    public partial class seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Leners",
                columns: new[] { "LenerId", "Email", "Naam", "Voornaam" },
                values: new object[,]
                {
                    { new Guid("a1239221-2ed4-4ade-9ce7-bc8f3919452f"), "ibeverbeke@gmail.com", "Verbeke", "Ibe" },
                    { new Guid("d0c69252-9673-4779-bd9c-bbbdcd733dd9"), "briekverbeke@gmail.com", "Verbeke", "Briek" },
                    { new Guid("0fec10f8-30a2-411e-bebb-130b076ddf3f"), "robbeverdonck003@gmail.com", "Verdonck", "Robbe" }
                });

            migrationBuilder.InsertData(
                table: "Materiaal",
                columns: new[] { "MateriaalId", "Categorie", "Drempel", "Naam", "Stock" },
                values: new object[,]
                {
                    { new Guid("53f01f4a-0586-4859-a6df-a1d0045e62a8"), "Klein", 1, "Pak Wit Papier", 4 },
                    { new Guid("f9f211a4-7c7f-4cbd-a063-0eee6f614df5"), "Keuken", 1, "Pak Schuursponsjes", 6 },
                    { new Guid("479880c8-effa-4681-abba-106e9a987995"), "Klein", 2, "Voetbal", 5 },
                    { new Guid("f8cd3eef-2535-4065-8fe5-994261a31c90"), "Bar", 4, "Bakken Bier", 1 },
                    { new Guid("93ebaf7e-69f6-4d1d-848a-f077ed69663d"), "Groot", 1, "Zak Kolen BBQ", 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Leners",
                keyColumn: "LenerId",
                keyValue: new Guid("0fec10f8-30a2-411e-bebb-130b076ddf3f"));

            migrationBuilder.DeleteData(
                table: "Leners",
                keyColumn: "LenerId",
                keyValue: new Guid("a1239221-2ed4-4ade-9ce7-bc8f3919452f"));

            migrationBuilder.DeleteData(
                table: "Leners",
                keyColumn: "LenerId",
                keyValue: new Guid("d0c69252-9673-4779-bd9c-bbbdcd733dd9"));

            migrationBuilder.DeleteData(
                table: "Materiaal",
                keyColumn: "MateriaalId",
                keyValue: new Guid("479880c8-effa-4681-abba-106e9a987995"));

            migrationBuilder.DeleteData(
                table: "Materiaal",
                keyColumn: "MateriaalId",
                keyValue: new Guid("53f01f4a-0586-4859-a6df-a1d0045e62a8"));

            migrationBuilder.DeleteData(
                table: "Materiaal",
                keyColumn: "MateriaalId",
                keyValue: new Guid("93ebaf7e-69f6-4d1d-848a-f077ed69663d"));

            migrationBuilder.DeleteData(
                table: "Materiaal",
                keyColumn: "MateriaalId",
                keyValue: new Guid("f8cd3eef-2535-4065-8fe5-994261a31c90"));

            migrationBuilder.DeleteData(
                table: "Materiaal",
                keyColumn: "MateriaalId",
                keyValue: new Guid("f9f211a4-7c7f-4cbd-a063-0eee6f614df5"));
        }
    }
}
