namespace RentaDepartamentosWeb.Models;

public class ImagenDepartamento
{
    public int Id { get; set; }

    // Relación con el departamento dueño de la imagen
    public int DepartamentoId { get; set; }
    public Departamento? Departamento { get; set; }

    // Ruta o nombre del archivo guardado (ej: "/uploads/departamentos/3/foto1.jpg")
    public string Url { get; set; } = string.Empty;

    // Para mostrar en orden (la primera imagen como portada, etc.)
    public int Orden { get; set; }

    public DateTime FechaSubida { get; set; } = DateTime.UtcNow;
}