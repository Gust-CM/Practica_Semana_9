using System.Collections.Generic;
using PracticaSemana9.Models;

namespace PracticaSemana9.ViewModels
{
    public class DashboardInscripcionViewModel
    {
        public int Total { get; set; }
        public List<ConteoTaller> PorTaller { get; set; } = new();
        public List<ConteoNivel> PorNivel { get; set; } = new();
        public List<Inscripcion> Proximos { get; set; } = new();
        public List<Inscripcion> Recientes { get; set; } = new();
    }

    public class ConteoTaller
    {
        public Taller? Taller { get; set; }
        public int Cantidad { get; set; }
    }

    public class ConteoNivel
    {
        public Nivel? Nivel { get; set; }
        public int Cantidad { get; set; }
    }
}