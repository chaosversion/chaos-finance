using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChaosFinance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Condition = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TemperatureC = table.Column<decimal>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Weather",
                columns: new[] { "Id", "Condition", "Date", "Description", "TemperatureC" },
                values: new object[,]
                {
                    { 1, "SUNNY", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", 25m },
                    { 2, "CLOUDY", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", 16m },
                    { 3, "SNOWY", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", -5m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weather");
        }
    }
}
