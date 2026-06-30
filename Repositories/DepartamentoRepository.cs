using RentaDepartamentosWeb.Models;

namespace RentaDepartamentosWeb.Repositories;

// Repositorio en memoria — se reemplazará por SQL Server al final del proyecto
public class DepartamentoRepository : IDepartamentoRepository
{
    private static readonly List<Departamento> _departamentos = new()
    {
        new Departamento { Id = 1, Direccion = "Av. Reforma 123", Colonia = "Centro", Ciudad = "Ciudad de México", Habitaciones = 2, Banios = 1, PrecioRenta = 8500, Estado = "Disponible" },
        new Departamento { Id = 2, Direccion = "Calle 5 de Mayo 45", Colonia = "Doctores", Ciudad = "Ciudad de México", Habitaciones = 3, Banios = 2, PrecioRenta = 12000, Estado = "Rentado", Arrendatario = "Juan Pérez", FechaInicioRenta = new DateTime(2025, 1, 15) },
        new Departamento { Id = 3, Direccion = "Blvd. Insurgentes 800", Colonia = "Del Valle", Ciudad = "Guadalajara", Habitaciones = 1, Banios = 1, PrecioRenta = 6000, Estado = "Mantenimiento" },
    };

    private static int _siguienteId = 4;

    public IEnumerable<Departamento> ObtenerDepartamentos() => _departamentos.ToList();

    public IEnumerable<Departamento> ObtenerDisponibles() =>
        _departamentos.Where(d => d.Estado == "Disponible").ToList();

    public IEnumerable<Departamento> BuscarDepartamentos(string? ciudad, string? colonia, string? estado, decimal? precioMin, decimal? precioMax)
    {
        var resultado = _departamentos.AsEnumerable();

        // El campo "ciudad" funciona como término libre — busca en dirección, colonia y ciudad
        if (!string.IsNullOrWhiteSpace(ciudad))
        {
            var term = ciudad.Trim();
            resultado = resultado.Where(d =>
                d.Direccion.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                d.Colonia.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                d.Ciudad.Contains(term, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(colonia))
            resultado = resultado.Where(d => d.Colonia.Contains(colonia, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(estado))
            resultado = resultado.Where(d => d.Estado == estado);

        if (precioMin.HasValue)
            resultado = resultado.Where(d => d.PrecioRenta >= precioMin.Value);

        if (precioMax.HasValue)
            resultado = resultado.Where(d => d.PrecioRenta <= precioMax.Value);

        return resultado.ToList();
    }

    public Departamento? ObtenerPorId(int id) =>
        _departamentos.FirstOrDefault(d => d.Id == id);

    public void AgregarDepartamento(Departamento departamento)
    {
        departamento.Id = _siguienteId++;
        _departamentos.Add(departamento);
    }

    public void ActualizarDepartamento(Departamento departamento)
    {
        var existente = _departamentos.FirstOrDefault(d => d.Id == departamento.Id)
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
    }

    public void EliminarDepartamento(int id)
    {
        var departamento = _departamentos.FirstOrDefault(d => d.Id == id)
            ?? throw new InvalidOperationException("Departamento no encontrado.");

        _departamentos.Remove(departamento);
    }

    public void CambiarEstado(int id, string nuevoEstado, string? arrendatario, DateTime? fechaInicioRenta)
    {
        var departamento = _departamentos.FirstOrDefault(d => d.Id == id)
            ?? throw new InvalidOperationException("Departamento no encontrado.");

        departamento.Estado = nuevoEstado;
        departamento.Arrendatario = arrendatario;
        departamento.FechaInicioRenta = fechaInicioRenta;
    }
}
