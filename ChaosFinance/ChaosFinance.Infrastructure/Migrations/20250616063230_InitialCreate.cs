using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChaosFinance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ImagemUrl = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Preco = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false),
                    ImagemUrl = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Estoque = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 1),
                    DataCadastro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CategoriaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "ImagemUrl", "Nome" },
                values: new object[,]
                {
                    { 1, "material.jpg", "Material Escolar" },
                    { 2, "eletronicos.jpg", "Eletrônicos" },
                    { 3, "acessorios.jpg", "Acessórios" }
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

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaId",
                table: "Produtos",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Weather");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
