using RentaDepartamentosWeb.Models;

namespace RentaDepartamentosWeb.Services;

public interface IDepartamentoService
{
    void ValidarDepartamento(Departamento departamento);
    void ValidarCambioEstado(string nuevoEstado, string? arrendatario);
}
