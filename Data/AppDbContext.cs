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
            new Departamento { Id = 1, Direccion = "Av. Reforma 123", Colonia = "Centro", Ciudad = "Ciudad de México", Habitaciones = 2, Banios = 1, PrecioRenta = 8500, Estado = "Disponible" },
            new Departamento { Id = 2, Direccion = "Calle 5 de Mayo 45", Colonia = "Doctores", Ciudad = "Ciudad de México", Habitaciones = 3, Banios = 2, PrecioRenta = 12000, Estado = "Rentado", Arrendatario = "Juan Pérez", FechaInicioRenta = new DateTime(2025, 1, 15) },
            new Departamento { Id = 3, Direccion = "Blvd. Insurgentes 800", Colonia = "Del Valle", Ciudad = "Guadalajara", Habitaciones = 1, Banios = 1, PrecioRenta = 6000, Estado = "Mantenimiento" }
        );
    }
}