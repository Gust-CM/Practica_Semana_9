using Microsoft.AspNetCore.Mvc;
using PracticaSemana9.Data;
using PracticaSemana9.Models;
using PracticaSemana9.ViewModels;
using System.Linq;

namespace PracticaSemana9.Controllers
{
    public class InscripcionController : Controller
    {
        public IActionResult Index()
        {
            var lista = InscripcionRepository.ObtenerInscripciones();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View(new Inscripcion { FechaTaller = DateTime.Today });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Inscripcion inscripcion)
        {
            if (inscripcion.FechaTaller.HasValue &&
                inscripcion.FechaTaller.Value.Date < DateTime.Today)
            {
                ModelState.AddModelError(nameof(inscripcion.FechaTaller), "La fecha no puede ser pasada.");
            }

            if (!ModelState.IsValid)
            {
                return View(inscripcion);
            }

            InscripcionRepository.AgregarInscripcion(inscripcion);
            TempData["Success"] = $"Inscripción de {inscripcion.Nombre} registrada.";
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Dashboard()
        {
            var lista = InscripcionRepository.ObtenerInscripciones();

            var modelo = new DashboardInscripcionViewModel
            {
                Total = lista.Count,

                PorTaller = lista
                    .GroupBy(x => x.Taller)
                    .Select(g => new ConteoTaller
                    {
                        Taller = g.Key,
                        Cantidad = g.Count()
                    })
                    .ToList(),

                PorNivel = lista
                    .GroupBy(x => x.NivelExperiencia)
                    .Select(g => new ConteoNivel
                    {
                        Nivel = g.Key,
                        Cantidad = g.Count()
                    })
                    .ToList(),

                Proximos = lista
                    .Where(x => x.FechaTaller >= DateTime.Today)
                    .OrderBy(x => x.FechaTaller)
                    .Take(5)
                    .ToList(),

                Recientes = lista
                    .TakeLast(5)
                    .ToList()
            };

            return View(modelo);
        }
    }
}