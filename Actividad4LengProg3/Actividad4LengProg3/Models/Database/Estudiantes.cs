using System.ComponentModel.DataAnnotations;

namespace Actividad4LengProg3.Models.Database
{
    public class Estudiantes
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        [StringLength(100)]
        public string NombreCompleto { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 6)]
        public string Matricula { get; set; }

        [Required]
        public string Carrera { get; set; }

        [Required]
        public string Recinto { get; set; }

        [Required]
        [EmailAddress]
        public string CorreoInstitucional { get; set; }

        [Phone]
        [MinLength(10)]
        public string Celular { get; set; }

        [Phone]
        public string Telefono { get; set; }

        [Required]
        [StringLength(200)]
        public string Direccion { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        public string Genero { get; set; }
        public string Turno { get; set; }

        public bool EstaBecado { get; set; }

        [Range(0, 100)]
        public int? PorcentajeBeca { get; set; }
    }
}
