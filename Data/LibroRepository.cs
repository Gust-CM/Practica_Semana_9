using PracticaSemana9.Models;

namespace PracticaSemana9.Data
{
    public static class LibroRepository
    {
        private static readonly List<Libro> _libros = new();

        public static IReadOnlyList<Libro> ObtenerLibros() => _libros.AsReadOnly();

        public static bool ExisteCodigo(string codigo) =>
            _libros.Any(l => l.CodigoInterno.Equals(codigo, StringComparison.OrdinalIgnoreCase));

        public static void AgregarLibro(Libro libro)
        {
            _libros.Add(libro);
        }
    }
}