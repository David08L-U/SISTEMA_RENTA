using RentaDepartamentosWeb.Models;

namespace RentaDepartamentosWeb.Services;

public class DepartamentoService : IDepartamentoService
{
    private static readonly string[] EstadosPermitidos = ["Disponible", "Rentado", "Mantenimiento"];

    public void ValidarDepartamento(Departamento departamento)
    {
        if (string.IsNullOrWhiteSpace(departamento.Direccion))
            throw new ArgumentException("La dirección no puede estar vacía.");

        if (string.IsNullOrWhiteSpace(departamento.Colonia))
            throw new ArgumentException("La colonia no puede estar vacía.");

        if (string.IsNullOrWhiteSpace(departamento.Ciudad))
            throw new ArgumentException("La ciudad no puede estar vacía.");

        if (departamento.Habitaciones <= 0)
            throw new ArgumentException("El número de habitaciones debe ser mayor a cero.");

        if (departamento.Banios <= 0)
            throw new ArgumentException("El número de baños debe ser mayor a cero.");

        if (departamento.PrecioRenta <= 0)
            throw new ArgumentException("El precio de renta debe ser mayor a cero.");

        if (!EstadosPermitidos.Contains(departamento.Estado))
            throw new ArgumentException($"El estado debe ser: {string.Join(", ", EstadosPermitidos)}.");

        if (departamento.Estado == "Rentado" && string.IsNullOrWhiteSpace(departamento.Arrendatario))
            throw new ArgumentException("Cuando el estado es 'Rentado', el nombre del arrendatario es obligatorio.");

        if (departamento.Estado == "Rentado" && departamento.FechaInicioRenta == null)
            throw new ArgumentException("Cuando el estado es 'Rentado', la fecha de inicio de renta es obligatoria.");
    }

    public void ValidarCambioEstado(string nuevoEstado, string? arrendatario)
    {
        if (!EstadosPermitidos.Contains(nuevoEstado))
            throw new ArgumentException($"El estado debe ser: {string.Join(", ", EstadosPermitidos)}.");

        if (nuevoEstado == "Rentado" && string.IsNullOrWhiteSpace(arrendatario))
            throw new ArgumentException("Para cambiar el estado a 'Rentado' se requiere el nombre del arrendatario.");
    }
}
