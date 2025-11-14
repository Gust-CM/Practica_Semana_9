using PracticaSemana9.Models;

namespace PracticaSemana9.Data
{
    public static class InscripcionRepository
    {
        private static readonly List<Inscripcion> _inscripciones = new();

        public static IReadOnlyList<Inscripcion> ObtenerInscripciones() => _inscripciones.AsReadOnly();

        public static void AgregarInscripcion(Inscripcion inscripcion) => _inscripciones.Add(inscripcion);
    }
}