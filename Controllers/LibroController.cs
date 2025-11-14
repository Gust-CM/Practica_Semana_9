using Microsoft.AspNetCore.Mvc;
using PracticaSemana9.Data;
using PracticaSemana9.Models;
using PracticaSemana9.ViewModels;
using System.Linq;

namespace PracticaSemana9.Controllers
{
    public class LibroController : Controller
    {
        public IActionResult Index()
        {
            var lista = LibroRepository.ObtenerLibros();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View(new Libro());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Libro libro)
        {
            if (libro.AnioPublicacion > DateTime.Now.Year)
                ModelState.AddModelError(nameof(libro.AnioPublicacion), "Año no puede ser futuro.");

            if (LibroRepository.ExisteCodigo(libro.CodigoInterno))
                ModelState.AddModelError(nameof(libro.CodigoInterno), "El código ya existe.");

            if (!ModelState.IsValid)
                return View(libro);

            LibroRepository.AgregarLibro(libro);

            TempData["Success"] = "Libro registrado con éxito.";
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Dashboard()
        {
            var libros = LibroRepository.ObtenerLibros();

            var modelo = new DashboardLibroViewModel
            {
                Total = libros.Count,
                Disponibles = libros.Count(x => x.Disponible == true),
                NoDisponibles = libros.Count(x => x.Disponible == false),

                PorCategoria = libros
                    .GroupBy(x => x.Categoria)
                    .Select(g => new ConteoCategoria
                    {
                        Categoria = g.Key,
                        Cantidad = g.Count()
                    })
                    .ToList(),

                Ultimos = libros
                    .TakeLast(5)
                    .ToList()
            };

            return View(modelo);
        }
    }
}