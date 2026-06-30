namespace RentaDepartamentosWeb.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Direccion { get; set; } = string.Empty;
        public string Colonia { get; set; } = string.Empty;
        public string Ciudad { get; set; } = string.Empty;
        public int Habitaciones { get; set; }
        public int Banios { get; set; }
        public decimal PrecioRenta { get; set; }
        public string Estado { get; set; } = string.Empty;
        public string? Arrendatario { get; set; }
        public DateTime? FechaInicioRenta { get; set; }
        public List<string> Imagenes { get; set; } = new();
        public string? Descripcion { get; set; }
        public List<string> Amenidades { get; set; } = new();
        public List<ImagenDepartamento> ImagenesRelacionadas { get; set; } = new();

    }
}