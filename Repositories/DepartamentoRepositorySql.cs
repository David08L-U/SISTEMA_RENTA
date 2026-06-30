using Microsoft.EntityFrameworkCore;
using RentaDepartamentosWeb.Data;
using RentaDepartamentosWeb.Models;

namespace RentaDepartamentosWeb.Repositories;

public class DepartamentoRepositorySql : IDepartamentoRepository
{
    private readonly AppDbContext _contexto;

    public DepartamentoRepositorySql(AppDbContext contexto)
    {
        _contexto = contexto;
    }

    public IEnumerable<Departamento> ObtenerDepartamentos() =>
        _contexto.Departamentos.AsNoTracking().ToList();

    public IEnumerable<Departamento> ObtenerDisponibles() =>
        _contexto.Departamentos.AsNoTracking().Where(d => d.Estado == "Disponible").ToList();

    public IEnumerable<Departamento> BuscarDepartamentos(string? ciudad, string? colonia, string? estado, decimal? precioMin, decimal? precioMax)
    {
        var query = _contexto.Departamentos.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(ciudad))
        {
            var term = ciudad.Trim();
            query = query.Where(d => d.Direccion.Contains(term) || d.Colonia.Contains(term) || d.Ciudad.Contains(term));
        }
        if (!string.IsNullOrWhiteSpace(colonia))
            query = query.Where(d => d.Colonia.Contains(colonia));
        if (!string.IsNullOrWhiteSpace(estado))
            query = query.Where(d => d.Estado == estado);
        if (precioMin.HasValue)
            query = query.Where(d => d.PrecioRenta >= precioMin.Value);
        if (precioMax.HasValue)
            query = query.Where(d => d.PrecioRenta <= precioMax.Value);

        return query.ToList();
    }

    public Departamento? ObtenerPorId(int id) =>
        _contexto.Departamentos.AsNoTracking().FirstOrDefault(d => d.Id == id);

    public void AgregarDepartamento(Departamento departamento)
    {
        _contexto.Departamentos.Add(departamento);
        _contexto.SaveChanges();
    }

    public void ActualizarDepartamento(Departamento departamento)
    {
        var existente = _contexto.Departamentos.FirstOrDefault(d => d.Id == departamento.Id)
            ?? throw new InvalidOperationException("Departamento no encontrado.");

        existente.Direccion = departamento.Direccion;
        existente.Colonia = departamento.Colonia;
        existente.Ciudad = departamento.Ciudad;
        existente.Habitaciones = departamento.Habitaciones;
        existente.Banios = departamento.Banios;
        existente.PrecioRenta = departamento.PrecioRenta;
        existente.Estado = departamento.Estado;
        existente.Arrendatario = departamento.Arrendatario;
        existente.FechaInicioRenta = departamento.FechaInicioRenta;
        existente.Imagenes = departamento.Imagenes;
        existente.Descripcion = departamento.Descripcion;
        existente.Amenidades = departamento.Amenidades;

        _contexto.SaveChanges();
    }

    public void EliminarDepartamento(int id)
    {
        var departamento = _contexto.Departamentos.FirstOrDefault(d => d.Id == id)
            ?? throw new InvalidOperationException("Departamento no encontrado.");

        _contexto.Departamentos.Remove(departamento);
        _contexto.SaveChanges();
    }

    public void CambiarEstado(int id, string nuevoEstado, string? arrendatario, DateTime? fechaInicioRenta)
    {
        var departamento = _contexto.Departamentos.FirstOrDefault(d => d.Id == id)
            ?? throw new InvalidOperationException("Departamento no encontrado.");

        departamento.Estado = nuevoEstado;
        departamento.Arrendatario = arrendatario;
        departamento.FechaInicioRenta = fechaInicioRenta;

        _contexto.SaveChanges();
    }
}