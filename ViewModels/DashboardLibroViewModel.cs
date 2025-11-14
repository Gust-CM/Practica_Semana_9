using System.Collections.Generic;
using PracticaSemana9.Models;

namespace PracticaSemana9.ViewModels
{
    public class DashboardLibroViewModel
    {
        public int Total { get; set; }
        public int Disponibles { get; set; }
        public int NoDisponibles { get; set; }
        public List<ConteoCategoria> PorCategoria { get; set; } = new();
        public List<Libro> Ultimos { get; set; } = new();
    }

    public class ConteoCategoria
    {
        public CategoriaLibro? Categoria { get; set; }
        public int Cantidad { get; set; }
    }
}