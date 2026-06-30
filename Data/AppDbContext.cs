using Microsoft.EntityFrameworkCore;
using RentaDepartamentosWeb.Models;

namespace RentaDepartamentosWeb.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Departamento> Departamentos => Set<Departamento>();
    public DbSet<ImagenDepartamento> ImagenesDepartamento => Set<ImagenDepartamento>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.ToTable("Departamentos");
            entity.HasKey(d => d.Id);

            entity.Property(d => d.Direccion).IsRequired().HasMaxLength(200);
            entity.Property(d => d.Colonia).IsRequired().HasMaxLength(120);
            entity.Property(d => d.Ciudad).IsRequired().HasMaxLength(120);
            entity.Property(d => d.Estado).IsRequired().HasMaxLength(30);
            entity.Property(d => d.Arrendatario).HasMaxLength(150);
            entity.Property(d => d.Descripcion).HasMaxLength(2000);
            entity.Property(d => d.PrecioRenta).HasColumnType("decimal(12,2)");

            entity.Property(d => d.Imagenes)
                .HasConversion(
                    lista => string.Join('|', lista),
                    texto => string.IsNullOrEmpty(texto)
                        ? new List<string>()
                        : texto.Split('|', StringSplitOptions.RemoveEmptyEntries).ToList())
                .HasColumnName("Imagenes")
                .Metadata.SetValueComparer(new Microsoft.EntityFrameworkCore.ChangeTracking.ValueComparer<List<string>>(
                    (a, b) => (a ?? new()).SequenceEqual(b ?? new()),
                    v => v.Aggregate(0, (hash, s) => HashCode.Combine(hash, s.GetHashCode())),
                    v => v.ToList()));

            entity.Property(d => d.Amenidades)
                .HasConversion(
                    lista => string.Join('|', lista),
                    texto => string.IsNullOrEmpty(texto)
                        ? new List<string>()
                        : texto.Split('|', StringSplitOptions.RemoveEmptyEntries).ToList())
                .HasColumnName("Amenidades")
                .Metadata.SetValueComparer(new Microsoft.EntityFrameworkCore.ChangeTracking.ValueComparer<List<string>>(
                    (a, b) => (a ?? new()).SequenceEqual(b ?? new()),
                    v => v.Aggregate(0, (hash, s) => HashCode.Combine(hash, s.GetHashCode())),
                    v => v.ToList()));
        });

        modelBuilder.Entity<ImagenDepartamento>(entity =>
        {
            entity.ToTable("ImagenesDepartamento");
            entity.HasKey(i => i.Id);

            entity.Property(i => i.Url).IsRequired().HasMaxLength(500);

            entity.HasOne(i => i.Departamento)
                .WithMany(d => d.ImagenesRelacionadas)
                .HasForeignKey(i => i.DepartamentoId)
                .OnDelete(DeleteBehavior.Cascade); // si se borra el depto, se borran sus imágenes
        });

        modelBuilder.Entity<Departamento>().HasData(
            new Departamento
            {
                Id = 1, Direccion = "Av. Reforma 123", Colonia = "Centro", Ciudad = "Ciudad de México",
                Habitaciones = 2, Banios = 1, PrecioRenta = 8500, Estado = "Disponible",
                Descripcion = "Moderno departamento en el corazón de la ciudad, a pasos del Ángel de la Independencia. Piso 8 con vista panorámica, cocina integral y áreas comunes de primer nivel.",
                Amenidades = new List<string> { "Internet de alta velocidad", "Cocina equipada", "Seguridad 24/7", "Estacionamiento" },
                Imagenes = new List<string> { "https://images.unsplash.com/photo-1522708323590-d24dbb6b0267?w=800" }
            },
            new Departamento
            {
                Id = 2, Direccion = "Calle 5 de Mayo 45", Colonia = "Doctores", Ciudad = "Ciudad de México",
                Habitaciones = 3, Banios = 2, PrecioRenta = 12000, Estado = "Rentado",
                Arrendatario = "Juan Pérez", FechaInicioRenta = new DateTime(2025, 1, 15),
                Descripcion = "Espacioso departamento familiar en zona céntrica. Tres habitaciones amplias, dos baños completos, sala-comedor integrado y balcón con vista a la calle.",
                Amenidades = new List<string> { "Internet de alta velocidad", "Lavandería", "Estacionamiento", "Seguridad 24/7" },
                Imagenes = new List<string> { "https://images.unsplash.com/photo-1502672260266-1c1ef2d93688?w=800" }
            },
            new Departamento
            {
                Id = 3, Direccion = "Blvd. Insurgentes 800", Colonia = "Del Valle", Ciudad = "Guadalajara",
                Habitaciones = 1, Banios = 1, PrecioRenta = 6000, Estado = "Mantenimiento",
                Descripcion = "Departamento tipo estudio en zona tranquila de Guadalajara. Ideal para profesionistas solteros. Actualmente en mantenimiento preventivo.",
                Amenidades = new List<string> { "Internet de alta velocidad", "Cocina equipada" },
                Imagenes = new List<string> { "https://images.unsplash.com/photo-1560448204-e02f11c3d0e2?w=800" }
            },
            new Departamento
            {
                Id = 4, Direccion = "Av. Ámsterdam 210", Colonia = "Condesa", Ciudad = "Ciudad de México",
                Habitaciones = 2, Banios = 2, PrecioRenta = 15000, Estado = "Disponible",
                Descripcion = "Elegante departamento en la exclusiva colonia Condesa, rodeado de parques y restaurantes de moda. Pisos de madera, techos altos y ventanas de piso a techo.",
                Amenidades = new List<string> { "Internet de alta velocidad", "Cocina equipada", "Balcón", "Acceso a gimnasio", "Seguridad 24/7" },
                Imagenes = new List<string> { "https://images.unsplash.com/photo-1493809842364-78817add7ffb?w=800" }
            },
            new Departamento
            {
                Id = 5, Direccion = "Calle Orizaba 88", Colonia = "Roma Norte", Ciudad = "Ciudad de México",
                Habitaciones = 3, Banios = 2, PrecioRenta = 18500, Estado = "Disponible",
                Descripcion = "Loft de lujo en la bohemia Roma Norte. Diseño industrial con ladrillo aparente, cocina gourmet y terraza privada. A dos cuadras del Parque México.",
                Amenidades = new List<string> { "Internet de alta velocidad", "Cocina equipada", "Balcón", "Amueblado", "Mascotas permitidas" },
                Imagenes = new List<string> { "https://images.unsplash.com/photo-1512917774080-9991f1c4c750?w=800" }
            },
            new Departamento
            {
                Id = 6, Direccion = "Paseo de la Reforma 505", Colonia = "Polanco", Ciudad = "Ciudad de México",
                Habitaciones = 4, Banios = 3, PrecioRenta = 35000, Estado = "Rentado",
                Arrendatario = "Sofía Martínez", FechaInicioRenta = new DateTime(2024, 9, 1),
                Descripcion = "Penthouse de lujo con vista al Bosque de Chapultepec. Cuatro recámaras en suite, sala de cine, roof garden privado y dos cajones de estacionamiento.",
                Amenidades = new List<string> { "Internet de alta velocidad", "Cocina equipada", "Alberca", "Acceso a gimnasio", "Seguridad 24/7", "Estacionamiento", "Amueblado" },
                Imagenes = new List<string> { "https://images.unsplash.com/photo-1600596542815-ffad4c1539a9?w=800" }
            },
            new Departamento
            {
                Id = 7, Direccion = "Av. Vallarta 1200", Colonia = "Americana", Ciudad = "Guadalajara",
                Habitaciones = 2, Banios = 1, PrecioRenta = 9500, Estado = "Disponible",
                Descripcion = "Departamento moderno en el corazón de Guadalajara, sobre la avenida más importante de la ciudad. Cerca de universidades, hospitales y centros comerciales.",
                Amenidades = new List<string> { "Internet de alta velocidad", "Cocina equipada", "Estacionamiento", "Seguridad 24/7" },
                Imagenes = new List<string> { "https://images.unsplash.com/photo-1554995207-c18c203602cb?w=800" }
            },
            new Departamento
            {
                Id = 8, Direccion = "Calle 60 Norte 350", Colonia = "Centro Histórico", Ciudad = "Mérida",
                Habitaciones = 2, Banios = 1, PrecioRenta = 7200, Estado = "Disponible",
                Descripcion = "Encantador departamento en casa colonial restaurada en el Centro Histórico de Mérida. Techos altos, piso de barro y patio interior con fuente.",
                Amenidades = new List<string> { "Internet de alta velocidad", "Aire acondicionado", "Seguridad 24/7" },
                Imagenes = new List<string> { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?w=800" }
            },
            new Departamento
            {
                Id = 9, Direccion = "Blvd. Kukulcán Km 12", Colonia = "Zona Hotelera", Ciudad = "Cancún",
                Habitaciones = 1, Banios = 1, PrecioRenta = 11000, Estado = "Rentado",
                Arrendatario = "Carlos Ramírez", FechaInicioRenta = new DateTime(2025, 3, 1),
                Descripcion = "Studio frente al mar en la Zona Hotelera de Cancún. Vista al Mar Caribe desde la cama. Alberca, playa privada y acceso a amenidades del condominio.",
                Amenidades = new List<string> { "Internet de alta velocidad", "Alberca", "Aire acondicionado", "Amueblado", "Seguridad 24/7" },
                Imagenes = new List<string> { "https://images.unsplash.com/photo-1571896349842-33c89424de2d?w=800" }
            },
            new Departamento
            {
                Id = 10, Direccion = "Av. Constitución 780", Colonia = "San Pedro Garza García", Ciudad = "Monterrey",
                Habitaciones = 3, Banios = 2, PrecioRenta = 22000, Estado = "Disponible",
                Descripcion = "Departamento ejecutivo en San Pedro, la zona más exclusiva de Monterrey. Acabados de lujo, cocina italiana, smart home y vista a la Sierra.",
                Amenidades = new List<string> { "Internet de alta velocidad", "Cocina equipada", "Acceso a gimnasio", "Estacionamiento", "Seguridad 24/7", "Calefacción" },
                Imagenes = new List<string> { "https://images.unsplash.com/photo-1505691938895-1758d7feb511?w=800" }
            },
            new Departamento
            {
                Id = 11, Direccion = "Calle Hidalgo 45", Colonia = "Centro", Ciudad = "Querétaro",
                Habitaciones = 2, Banios = 1, PrecioRenta = 8000, Estado = "Disponible",
                Descripcion = "Departamento en el Centro Histórico de Querétaro, Patrimonio de la Humanidad. Arquitectura colonial con amenidades modernas, a pasos del Acueducto.",
                Amenidades = new List<string> { "Internet de alta velocidad", "Cocina equipada", "Seguridad 24/7" },
                Imagenes = new List<string> { "https://images.unsplash.com/photo-1484154218962-a197022b5858?w=800" }
            },
            new Departamento
            {
                Id = 12, Direccion = "Av. Revolución 2500", Colonia = "San Ángel", Ciudad = "Ciudad de México",
                Habitaciones = 2, Banios = 2, PrecioRenta = 13500, Estado = "Mantenimiento",
                Descripcion = "Departamento en la pintoresca colonia San Ángel, conocida por su mercado de artesanías y ambiente artístico. En proceso de remodelación integral.",
                Amenidades = new List<string> { "Internet de alta velocidad", "Estacionamiento", "Balcón" },
                Imagenes = new List<string> { "https://images.unsplash.com/photo-1545324418-cc1a3fa10c00?w=800" }
            },
            new Departamento
            {
                Id = 13, Direccion = "Calle Morelos 120", Colonia = "Providencia", Ciudad = "Guadalajara",
                Habitaciones = 3, Banios = 2, PrecioRenta = 14000, Estado = "Disponible",
                Descripcion = "Amplio departamento familiar en la elegante colonia Providencia. Terraza con jardín privado, cuarto de servicio y bodega. Zona escolar y comercial de primer nivel.",
                Amenidades = new List<string> { "Internet de alta velocidad", "Cocina equipada", "Lavandería", "Estacionamiento", "Mascotas permitidas", "Seguridad 24/7" },
                Imagenes = new List<string> { "https://images.unsplash.com/photo-1556909114-f6e7ad7d3136?w=800" }
            }
        );
    }
}