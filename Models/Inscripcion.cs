using System.ComponentModel.DataAnnotations;

namespace PracticaSemana9.Models
{
    public enum Taller
    {
        CSharp = 1,
        Python = 2,
        Web = 3,
        BasesDeDatos = 4,
        Otro = 5
    }

    public enum Nivel
    {
        Principiante = 1,
        Intermedio = 2,
        Avanzado = 3
    }

    public class Inscripcion
    {
        [Required, StringLength(60, MinimumLength = 2)]
        public string Nombre { get; set; } = string.Empty;

        [Required, StringLength(60, MinimumLength = 2)]
        public string Apellidos { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Correo { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^\d{8,}$", ErrorMessage = "Debe contener al menos 8 dígitos.")]
        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "Seleccione un taller válido.")]
        public Taller? Taller { get; set; }

        [Required]
        [Display(Name = "Nivel de experiencia")]
        public Nivel? NivelExperiencia { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha del taller")]
        public DateTime? FechaTaller { get; set; }

        [Display(Name = "Acepta términos y condiciones")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Debe aceptar los términos.")]
        public bool AceptaTerminos { get; set; }
    }
}
