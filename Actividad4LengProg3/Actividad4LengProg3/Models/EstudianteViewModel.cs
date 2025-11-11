using System;
using System.ComponentModel.DataAnnotations;

namespace Actividad4LengProg3.Models
{
    public class EstudianteViewModel
    {
        [Required(ErrorMessage = "El nombre completo es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres.")]
        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "La matrícula es obligatoria.")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "La matrícula debe tener entre 6 y 15 caracteres.")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una carrera.")]
        public string Carrera { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un recinto.")]
        public string Recinto { get; set; }

        [Required(ErrorMessage = "El correo institucional es obligatorio.")]
        [EmailAddress(ErrorMessage = "Debe ingresar un correo válido.")]
        [StringLength(100, ErrorMessage = "El correo no puede exceder 100 caracteres.")]
        public string CorreoInstitucional { get; set; }

        [Required(ErrorMessage = "El número de celular es obligatorio.")]
        [Phone(ErrorMessage = "Debe ingresar un número de celular válido.")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "El celular debe tener al menos 10 dígitos.")]
        public string Celular { get; set; }

        [Phone(ErrorMessage = "Debe ingresar un número de teléfono válido.")]
        [StringLength(15)]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria.")]
        [StringLength(200, ErrorMessage = "La dirección no puede exceder 200 caracteres.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Debe ingresar la fecha de nacimiento.")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        public string Genero { get; set; }

        public string Turno { get; set; }

        public bool EstaBecado { get; set; }

        [Range(0, 100, ErrorMessage = "El porcentaje debe estar entre 0 y 100.")]
        public int? PorcentajeBeca { get; set; }
    }
}


        

   