using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Actividad4LengProg3.Models.Database
{
    public class Recintos
    {
        [Required]
        [Key]
        public string Codigo { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Direccion { get; set; }

    }

}