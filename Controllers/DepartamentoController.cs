using Microsoft.AspNetCore.Mvc;
using RentaDepartamentosWeb.Models;
using RentaDepartamentosWeb.Repositories;
using RentaDepartamentosWeb.Services;
using System.IO;

namespace RentaDepartamentosWeb.Controllers;

public class DepartamentoController : Controller
{
    private readonly IDepartamentoRepository _repositorio;
    private readonly IDepartamentoService _servicio;

    public DepartamentoController(IDepartamentoRepository repositorio, IDepartamentoService servicio)
    {
        _repositorio = repositorio;
        _servicio = servicio;
    }

    public IActionResult Dashboard()
    {
        var todos = _repositorio.ObtenerDepartamentos().ToList();
        ViewBag.Total = todos.Count;
        ViewBag.Disponibles = todos.Count(d => d.Estado == "Disponible");
        ViewBag.Rentados = todos.Count(d => d.Estado == "Rentado");
        ViewBag.Mantenimiento = todos.Count(d => d.Estado == "Mantenimiento");
        ViewBag.IngresosMes = todos.Where(d => d.Estado == "Rentado").Sum(d => d.PrecioRenta);
        ViewBag.TasaOcupacion = todos.Count > 0
            ? (int)Math.Round(todos.Count(d => d.Estado == "Rentado") * 100.0 / todos.Count)
            : 0;
        ViewBag.Recientes = todos.Where(d => d.Estado == "Rentado").Take(3).ToList();
        ViewBag.PropiedadesDestacadas = todos.Take(3).ToList();
        return View();
    }

    public IActionResult Index(string? estado)
    {
        var departamentos = _repositorio.ObtenerDepartamentos();
        if (!string.IsNullOrEmpty(estado))
            departamentos = departamentos.Where(d => d.Estado == estado);
        ViewBag.FiltroEstado = estado ?? "";
        return View(departamentos);
    }

    public IActionResult Disponibles()
    {
        var todos = _repositorio.ObtenerDepartamentos();
        return View(todos);
    }

    public IActionResult Buscar(string? ciudad, string? colonia, string? estado, decimal? precioMin, decimal? precioMax)
    {
        bool buscado = ciudad != null || colonia != null || estado != null || precioMin != null || precioMax != null;
        var resultados = buscado
            ? _repositorio.BuscarDepartamentos(ciudad, colonia, estado, precioMin, precioMax)
            : Enumerable.Empty<Departamento>();
        ViewBag.Buscado = buscado;
        ViewBag.Ciudad = ciudad;
        ViewBag.Colonia = colonia;
        ViewBag.Estado = estado;
        ViewBag.PrecioMin = precioMin;
        ViewBag.PrecioMax = precioMax;
        return View(resultados);
    }

    public IActionResult Details(int id)
    {
        var departamento = _repositorio.ObtenerPorId(id);
        if (departamento == null) return NotFound();
        return View(departamento);
    }

    public IActionResult Create() => View(new Departamento());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Departamento departamento, List<IFormFile>? archivosImagenes, string? urlsImagenes, List<string>? Amenidades)
    {
        try
        {
            if (Amenidades != null) departamento.Amenidades = Amenidades;
            departamento.Imagenes = await ProcesarImagenes(archivosImagenes, urlsImagenes, departamento.Imagenes);
            _servicio.ValidarDepartamento(departamento);
            _repositorio.AgregarDepartamento(departamento);
            TempData["Exito"] = "Departamento registrado correctamente.";
            return RedirectToAction(nameof(Index));
        }
        catch (ArgumentException ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View(departamento);
        }
    }

    public IActionResult Edit(int id)
    {
        var departamento = _repositorio.ObtenerPorId(id);
        if (departamento == null) return NotFound();
        return View(departamento);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Departamento departamento, List<IFormFile>? archivosImagenes, string? urlsImagenes, string? imagenesExistentes, List<string>? Amenidades)
    {
        try
        {
            if (Amenidades != null) departamento.Amenidades = Amenidades;
            // Conservar imágenes existentes que no se eliminaron
            if (!string.IsNullOrEmpty(imagenesExistentes))
                departamento.Imagenes = imagenesExistentes.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();

            departamento.Imagenes = await ProcesarImagenes(archivosImagenes, urlsImagenes, departamento.Imagenes);
            _servicio.ValidarDepartamento(departamento);
            _repositorio.ActualizarDepartamento(departamento);
            TempData["Exito"] = "Departamento actualizado correctamente.";
            return RedirectToAction(nameof(Details), new { id = departamento.Id });
        }
        catch (ArgumentException ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View(departamento);
        }
    }

    private async Task<List<string>> ProcesarImagenes(List<IFormFile>? archivos, string? urls, List<string> existentes)
    {
        var resultado = new List<string>(existentes);

        // Archivos subidos desde dispositivo
        if (archivos != null && archivos.Count > 0)
        {
            var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            Directory.CreateDirectory(uploadsPath);

            foreach (var archivo in archivos)
            {
                if (archivo.Length > 0)
                {
                    var extension = Path.GetExtension(archivo.FileName).ToLowerInvariant();
                    var permitidas = new[] { ".jpg", ".jpeg", ".png", ".webp", ".gif" };
                    if (!permitidas.Contains(extension)) continue;

                    var nombreArchivo = $"{Guid.NewGuid()}{extension}";
                    var rutaCompleta = Path.Combine(uploadsPath, nombreArchivo);
                    using var stream = new FileStream(rutaCompleta, FileMode.Create);
                    await archivo.CopyToAsync(stream);
                    resultado.Add($"/uploads/{nombreArchivo}");
                }
            }
        }

        // URLs agregadas manualmente
        if (!string.IsNullOrWhiteSpace(urls))
        {
            var listaUrls = urls.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                .Select(u => u.Trim())
                                .Where(u => u.StartsWith("http://") || u.StartsWith("https://") || u.StartsWith("/"));
            resultado.AddRange(listaUrls);
        }

        return resultado;
    }

    public IActionResult Delete(int id)
    {
        var departamento = _repositorio.ObtenerPorId(id);
        if (departamento == null) return NotFound();
        return View(departamento);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _repositorio.EliminarDepartamento(id);
        TempData["Exito"] = "Departamento eliminado correctamente.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CambiarEstado(int id, string nuevoEstado, string? arrendatario, DateTime? fechaInicioRenta)
    {
        try
        {
            _servicio.ValidarCambioEstado(nuevoEstado, arrendatario);
            _repositorio.CambiarEstado(id, nuevoEstado, arrendatario, fechaInicioRenta);
            TempData["Exito"] = "Estado actualizado correctamente.";
        }
        catch (ArgumentException ex)
        {
            TempData["Error"] = ex.Message;
        }
        return RedirectToAction(nameof(Details), new { id });
    }

    [HttpGet]
    public IActionResult Sugerencias(string q)
    {
        if (string.IsNullOrWhiteSpace(q) || q.Length < 2)
            return Json(new List<object>());

        var todos = _repositorio.ObtenerDepartamentos();
        var term = q.Trim().ToLower();

        var resultados = todos
            .Where(d =>
                d.Direccion.ToLower().Contains(term) ||
                d.Colonia.ToLower().Contains(term) ||
                d.Ciudad.ToLower().Contains(term))
            .Take(6)
            .Select(d => new {
                id = d.Id,
                label = $"{d.Direccion}",
                sub = $"{d.Colonia}, {d.Ciudad}",
                estado = d.Estado,
                precio = d.PrecioRenta.ToString("C0")
            })
            .ToList();

        return Json(resultados);
    }

    public IActionResult Contabilidad() => View();

    public IActionResult Reportes()
    {
        var todos = _repositorio.ObtenerDepartamentos().ToList();
        ViewBag.TotalIngresos = todos.Where(d => d.Estado == "Rentado").Sum(d => d.PrecioRenta);
        ViewBag.Departamentos = todos;
        return View();
    }
}
