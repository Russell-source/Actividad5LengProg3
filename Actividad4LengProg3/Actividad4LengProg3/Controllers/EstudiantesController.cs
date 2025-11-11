using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Actividad4LengProg3.Models.Database;
using Actividad4LengProg3.Models;
using System.Collections.Generic;
using System.Linq;

namespace Actividad4LengProg3.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly AppDbContext _context;

        public EstudiantesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() => View(new EstudianteViewModel());

        [HttpPost]
        public IActionResult Registrar(EstudianteViewModel estudiante)
        {
            if (estudiante.EstaBecado && estudiante.PorcentajeBeca == null)
                ModelState.AddModelError("PorcentajeBeca", "Debe ingresar el porcentaje de beca.");

            if (ModelState.IsValid)
            {
                var nuevoEstudiante = new Estudiantes
                {
                    Matricula = estudiante.Matricula,
                    NombreCompleto = estudiante.NombreCompleto,
                    Carrera = estudiante.Carrera,
                    Recinto = estudiante.Recinto,
                    CorreoInstitucional = estudiante.CorreoInstitucional,
                    Celular = estudiante.Celular,
                    Telefono = estudiante.Telefono,
                    Direccion = estudiante.Direccion,
                    FechaNacimiento = estudiante.FechaNacimiento,
                    Genero = estudiante.Genero,
                    Turno = estudiante.Turno,
                    EstaBecado = estudiante.EstaBecado,
                    PorcentajeBeca = estudiante.PorcentajeBeca
                };

                _context.Estudiantes.Add(nuevoEstudiante);
                _context.SaveChanges();

                return RedirectToAction("Lista");
            }

            return View("Index", estudiante);
        }

        public IActionResult Lista()
        {
            var estudiantes = _context.Estudiantes.ToList();
            return View(estudiantes);
        }

        public IActionResult Editar(string matricula)
        {
            var estudiante = _context.Estudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudiante == null)
                return NotFound();

            return View(estudiante);
        }

        [HttpPost]
        public IActionResult Editar(Estudiantes estudiante)
        {
            if (ModelState.IsValid)
            {
                _context.Estudiantes.Update(estudiante);
                _context.SaveChanges();
                return RedirectToAction("Lista");
            }

            return View(estudiante);
        }

        public IActionResult Eliminar(string matricula)
        {
            var estudiante = _context.Estudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudiante != null)
            {
                _context.Estudiantes.Remove(estudiante);
                _context.SaveChanges();
            }

            return RedirectToAction("Lista");
        }
    }
}
