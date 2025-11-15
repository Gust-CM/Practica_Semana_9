using System;
using System.ComponentModel.DataAnnotations;

namespace PracticaSemana9.Models
{
    public enum CategoriaLibro
    {
        [Display(Name = "Programación")]
        Programacion = 1,

        [Display(Name = "Redes")]
        Redes = 2,

        [Display(Name = "Bases de Datos")]
        BasesDeDatos = 3,

        [Display(Name = "Inteligencia Artificial")]
        IA = 4,

        [Display(Name = "Otro")]
        Otro = 5
    }

    public class Libro
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Por favor, digite el titulo del libro")]
        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El título debe tener al menos 3 caracteres.")]
        public string Titulo { get; set; } = string.Empty;

        [Display(Name = "Por favor, digite el nombre del Autor")]
        [Required(ErrorMessage = "El autor es obligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El autor debe tener al menos 3 caracteres.")]
        public string Autor { get; set; } = string.Empty;

        [Display(Name = "Por favor, seleccione la categoría")]
        [Required(ErrorMessage = "Debe seleccionar una categoría.")]
        public CategoriaLibro Categoria { get; set; }

        [Display(Name = "Por favor, digite el año de publicacion")]
        [Required(ErrorMessage = "El año de publicación es obligatorio.")]
        [Range(1900, 2100, ErrorMessage = "El año de publicación debe estar entre 1900 y el año actual.")]
        [AnioNoFuturo(ErrorMessage = "El año de publicación no puede ser futuro.")]
        public int AnioPublicacion { get; set; }

        [Display(Name = "Por favor digite el numero de paginas que tiene el libro")]
        [Required(ErrorMessage = "El número de páginas es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El número de páginas debe ser mayor que 0.")]
        public int NumeroPaginas { get; set; }

        [Display(Name = "Por favor, digite el codigo interno | Ejemplo LIB-001")]
        [Required(ErrorMessage = "El codigo interno es obligatorio.")]
        [RegularExpression(@"^LIB-\d{3}$", ErrorMessage = "El codigo interno debe tener el formato LIB-### (por ejemplo, LIB-001).")]
        public string CodigoInterno { get; set; } = string.Empty;

        [Display(Name = "Por favor, marque la casilla si el libro se encuentra disponible")]
        [Required(ErrorMessage = "Debe indicar si el libro está disponible.")]
        public bool Disponible { get; set; }
    }

    // Validación personalizada para impedir años futuros
    public class AnioNoFuturoAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is int anio)
                return anio <= DateTime.Now.Year;

            return true;
        }
    }
}
