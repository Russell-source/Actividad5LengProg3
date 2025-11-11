using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Actividad4LengProg3.Models.Database
{
    public class Carreras
    {
        [Required]
        [Key]
        public string Codigo { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public int CantidadCreditos { get; set; }


        [Required]
        public int CantidadMaterias { get; set; }
    }
}