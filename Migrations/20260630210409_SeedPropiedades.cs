using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RentaDepartamentosWeb.Migrations
{
    /// <inheritdoc />
    public partial class SeedPropiedades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Amenidades", "Descripcion", "Imagenes" },
                values: new object[] { "Internet de alta velocidad|Cocina equipada|Seguridad 24/7|Estacionamiento", "Moderno departamento en el corazón de la ciudad, a pasos del Ángel de la Independencia. Piso 8 con vista panorámica, cocina integral y áreas comunes de primer nivel.", "https://images.unsplash.com/photo-1522708323590-d24dbb6b0267?w=800" });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Amenidades", "Descripcion", "Imagenes" },
                values: new object[] { "Internet de alta velocidad|Lavandería|Estacionamiento|Seguridad 24/7", "Espacioso departamento familiar en zona céntrica. Tres habitaciones amplias, dos baños completos, sala-comedor integrado y balcón con vista a la calle.", "https://images.unsplash.com/photo-1502672260266-1c1ef2d93688?w=800" });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Amenidades", "Descripcion", "Imagenes" },
                values: new object[] { "Internet de alta velocidad|Cocina equipada", "Departamento tipo estudio en zona tranquila de Guadalajara. Ideal para profesionistas solteros. Actualmente en mantenimiento preventivo.", "https://images.unsplash.com/photo-1560448204-e02f11c3d0e2?w=800" });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "Id", "Amenidades", "Arrendatario", "Banios", "Ciudad", "Colonia", "Descripcion", "Direccion", "Estado", "FechaInicioRenta", "Habitaciones", "Imagenes", "PrecioRenta" },
                values: new object[,]
                {
                    { 4, "Internet de alta velocidad|Cocina equipada|Balcón|Acceso a gimnasio|Seguridad 24/7", null, 2, "Ciudad de México", "Condesa", "Elegante departamento en la exclusiva colonia Condesa, rodeado de parques y restaurantes de moda. Pisos de madera, techos altos y ventanas de piso a techo.", "Av. Ámsterdam 210", "Disponible", null, 2, "https://images.unsplash.com/photo-1493809842364-78817add7ffb?w=800", 15000m },
                    { 5, "Internet de alta velocidad|Cocina equipada|Balcón|Amueblado|Mascotas permitidas", null, 2, "Ciudad de México", "Roma Norte", "Loft de lujo en la bohemia Roma Norte. Diseño industrial con ladrillo aparente, cocina gourmet y terraza privada. A dos cuadras del Parque México.", "Calle Orizaba 88", "Disponible", null, 3, "https://images.unsplash.com/photo-1512917774080-9991f1c4c750?w=800", 18500m },
                    { 6, "Internet de alta velocidad|Cocina equipada|Alberca|Acceso a gimnasio|Seguridad 24/7|Estacionamiento|Amueblado", "Sofía Martínez", 3, "Ciudad de México", "Polanco", "Penthouse de lujo con vista al Bosque de Chapultepec. Cuatro recámaras en suite, sala de cine, roof garden privado y dos cajones de estacionamiento.", "Paseo de la Reforma 505", "Rentado", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "https://images.unsplash.com/photo-1600596542815-ffad4c1539a9?w=800", 35000m },
                    { 7, "Internet de alta velocidad|Cocina equipada|Estacionamiento|Seguridad 24/7", null, 1, "Guadalajara", "Americana", "Departamento moderno en el corazón de Guadalajara, sobre la avenida más importante de la ciudad. Cerca de universidades, hospitales y centros comerciales.", "Av. Vallarta 1200", "Disponible", null, 2, "https://images.unsplash.com/photo-1554995207-c18c203602cb?w=800", 9500m },
                    { 8, "Internet de alta velocidad|Aire acondicionado|Seguridad 24/7", null, 1, "Mérida", "Centro Histórico", "Encantador departamento en casa colonial restaurada en el Centro Histórico de Mérida. Techos altos, piso de barro y patio interior con fuente.", "Calle 60 Norte 350", "Disponible", null, 2, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?w=800", 7200m },
                    { 9, "Internet de alta velocidad|Alberca|Aire acondicionado|Amueblado|Seguridad 24/7", "Carlos Ramírez", 1, "Cancún", "Zona Hotelera", "Studio frente al mar en la Zona Hotelera de Cancún. Vista al Mar Caribe desde la cama. Alberca, playa privada y acceso a amenidades del condominio.", "Blvd. Kukulcán Km 12", "Rentado", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://images.unsplash.com/photo-1571896349842-33c89424de2d?w=800", 11000m },
                    { 10, "Internet de alta velocidad|Cocina equipada|Acceso a gimnasio|Estacionamiento|Seguridad 24/7|Calefacción", null, 2, "Monterrey", "San Pedro Garza García", "Departamento ejecutivo en San Pedro, la zona más exclusiva de Monterrey. Acabados de lujo, cocina italiana, smart home y vista a la Sierra.", "Av. Constitución 780", "Disponible", null, 3, "https://images.unsplash.com/photo-1505691938895-1758d7feb511?w=800", 22000m },
                    { 11, "Internet de alta velocidad|Cocina equipada|Seguridad 24/7", null, 1, "Querétaro", "Centro", "Departamento en el Centro Histórico de Querétaro, Patrimonio de la Humanidad. Arquitectura colonial con amenidades modernas, a pasos del Acueducto.", "Calle Hidalgo 45", "Disponible", null, 2, "https://images.unsplash.com/photo-1484154218962-a197022b5858?w=800", 8000m },
                    { 12, "Internet de alta velocidad|Estacionamiento|Balcón", null, 2, "Ciudad de México", "San Ángel", "Departamento en la pintoresca colonia San Ángel, conocida por su mercado de artesanías y ambiente artístico. En proceso de remodelación integral.", "Av. Revolución 2500", "Mantenimiento", null, 2, "https://images.unsplash.com/photo-1545324418-cc1a3fa10c00?w=800", 13500m },
                    { 13, "Internet de alta velocidad|Cocina equipada|Lavandería|Estacionamiento|Mascotas permitidas|Seguridad 24/7", null, 2, "Guadalajara", "Providencia", "Amplio departamento familiar en la elegante colonia Providencia. Terraza con jardín privado, cuarto de servicio y bodega. Zona escolar y comercial de primer nivel.", "Calle Morelos 120", "Disponible", null, 3, "https://images.unsplash.com/photo-1556909114-f6e7ad7d3136?w=800", 14000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Amenidades", "Descripcion", "Imagenes" },
                values: new object[] { "", null, "" });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Amenidades", "Descripcion", "Imagenes" },
                values: new object[] { "", null, "" });

            migrationBuilder.UpdateData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Amenidades", "Descripcion", "Imagenes" },
                values: new object[] { "", null, "" });
        }
    }
}
