using System.ComponentModel.DataAnnotations;

namespace PracticaSemana9.Models
{
    public enum CategoriaLibro
    {
        Programacion = 1,
        Redes = 2,
        BasesDeDatos = 3,
        IA = 4,
        Otro = 5
    }

    public class Libro
    {
        [Required, StringLength(120, MinimumLength = 3)]
        public string Titulo { get; set; } = string.Empty;

        [Required, StringLength(120, MinimumLength = 3)]
        public string Autor { get; set; } = string.Empty;

        [Required]
        public CategoriaLibro? Categoria { get; set; }

        [Display(Name = "Año de publicación")]
        [Required]
        [Range(1900, 3000)]
        public int? AnioPublicacion { get; set; }

        [Display(Name = "Páginas")]
        [Required]
        [Range(1, int.MaxValue)]
        public int? NumeroPaginas { get; set; }

        [Required]
        [RegularExpression(@"^LIB-\d{3}$", ErrorMessage = "Formato LIB-###")]
        public string CodigoInterno { get; set; } = string.Empty;

        [Required]
        public bool? Disponible { get; set; }
    }
}