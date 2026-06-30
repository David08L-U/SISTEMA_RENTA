using RentaDepartamentosWeb.Models;

namespace RentaDepartamentosWeb.Repositories;

public interface IDepartamentoRepository
{
    IEnumerable<Departamento> ObtenerDepartamentos();
    IEnumerable<Departamento> ObtenerDisponibles();
    IEnumerable<Departamento> BuscarDepartamentos(string? ciudad, string? colonia, string? estado, decimal? precioMin, decimal? precioMax);
    Departamento? ObtenerPorId(int id);
    void AgregarDepartamento(Departamento departamento);
    void ActualizarDepartamento(Departamento departamento);
    void EliminarDepartamento(int id);
    void CambiarEstado(int id, string nuevoEstado, string? arrendatario, DateTime? fechaInicioRenta);
}
