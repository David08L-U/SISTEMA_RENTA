using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RentaDepartamentosWeb.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Colonia = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Habitaciones = table.Column<int>(type: "int", nullable: false),
                    Banios = table.Column<int>(type: "int", nullable: false),
                    PrecioRenta = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Arrendatario = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    FechaInicioRenta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Imagenes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Amenidades = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "Id", "Amenidades", "Arrendatario", "Banios", "Ciudad", "Colonia", "Descripcion", "Direccion", "Estado", "FechaInicioRenta", "Habitaciones", "Imagenes", "PrecioRenta" },
                values: new object[,]
                {
                    { 1, "", null, 1, "Ciudad de México", "Centro", null, "Av. Reforma 123", "Disponible", null, 2, "", 8500m },
                    { 2, "", "Juan Pérez", 2, "Ciudad de México", "Doctores", null, "Calle 5 de Mayo 45", "Rentado", new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "", 12000m },
                    { 3, "", null, 1, "Guadalajara", "Del Valle", null, "Blvd. Insurgentes 800", "Mantenimiento", null, 1, "", 6000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departamentos");
        }
    }
}
