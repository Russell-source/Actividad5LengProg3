using Actividad4LengProg3.Models;
using Actividad4LengProg3.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        // 🔹 Mostrar formulario de registro
        public IActionResult Index()
        {
            ViewBag.Carreras = new SelectList(_context.Carreras.ToList(), "Nombre", "Nombre");
            ViewBag.Recintos = new SelectList(_context.Recintos.ToList(), "Nombre", "Nombre");
            return View(new EstudianteViewModel());
        }

        // 🔹 Registrar estudiante
        [HttpPost]
        public IActionResult Registrar(EstudianteViewModel estudiante)
        {
            if (estudiante.EstaBecado && estudiante.PorcentajeBeca == null)
                ModelState.AddModelError("PorcentajeBeca", "Debe ingresar el porcentaje de beca.");

            if (string.IsNullOrWhiteSpace(estudiante.Celular))
                ModelState.AddModelError("Celular", "Debe ingresar el número de celular.");

            if (ModelState.IsValid)
            {
                var nuevoEstudiante = new Estudiantes
                {
                    NombreCompleto = estudiante.NombreCompleto,
                    Matricula = estudiante.Matricula,
                    Celular = estudiante.Celular,
                    Carrera = estudiante.Carrera,
                    Recinto = estudiante.Recinto,
                    EstaBecado = estudiante.EstaBecado,
                    PorcentajeBeca = estudiante.PorcentajeBeca
                };

                _context.Estudiantes.Add(nuevoEstudiante);
                _context.SaveChanges();

                return RedirectToAction("Lista");
            }

            ViewBag.Carreras = new SelectList(_context.Carreras.ToList(), "Nombre", "Nombre");
            ViewBag.Recintos = new SelectList(_context.Recintos.ToList(), "Nombre", "Nombre");
            return View("Index", estudiante);
        }

        // 🔹 Mostrar lista de estudiantes
        public IActionResult Lista()
        {
            var estudiantes = _context.Estudiantes.ToList();
            return View(estudiantes);
        }

        // 🔹 Mostrar formulario de edición
        public IActionResult Editar(string matricula)
        {
            var estudiante = _context.Estudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudiante == null) return NotFound();

            var viewModel = new EstudianteViewModel
            {
                NombreCompleto = estudiante.NombreCompleto,
                Matricula = estudiante.Matricula,
                Celular = estudiante.Celular,
                Carrera = estudiante.Carrera,
                Recinto = estudiante.Recinto,
                EstaBecado = estudiante.EstaBecado,
                PorcentajeBeca = estudiante.PorcentajeBeca
            };

            ViewBag.Carreras = new SelectList(_context.Carreras.ToList(), "Nombre", "Nombre", estudiante.Carrera);
            ViewBag.Recintos = new SelectList(_context.Recintos.ToList(), "Nombre", "Nombre", estudiante.Recinto);
            return View(viewModel);
        }

        // 🔹 Guardar edición
        [HttpPost]
        public IActionResult Editar(EstudianteViewModel estudiante)
        {
            if (estudiante.EstaBecado && estudiante.PorcentajeBeca == null)
                ModelState.AddModelError("PorcentajeBeca", "Debe ingresar el porcentaje de beca.");

            if (string.IsNullOrWhiteSpace(estudiante.Celular))
                ModelState.AddModelError("Celular", "Debe ingresar el número de celular.");

            if (ModelState.IsValid)
            {
                var entity = _context.Estudiantes.FirstOrDefault(e => e.Matricula == estudiante.Matricula);
                if (entity != null)
                {
                    entity.NombreCompleto = estudiante.NombreCompleto;
                    entity.Celular = estudiante.Celular;
                    entity.Carrera = estudiante.Carrera;
                    entity.Recinto = estudiante.Recinto;
                    entity.EstaBecado = estudiante.EstaBecado;
                    entity.PorcentajeBeca = estudiante.PorcentajeBeca;
                    _context.SaveChanges();
                }

                return RedirectToAction("Lista");
            }

            ViewBag.Carreras = new SelectList(_context.Carreras.ToList(), "Nombre", "Nombre", estudiante.Carrera);
            ViewBag.Recintos = new SelectList(_context.Recintos.ToList(), "Nombre", "Nombre", estudiante.Recinto);
            return View(estudiante);
        }

        // 🔹 Eliminar estudiante
        public IActionResult Eliminar(string matricula)
        {
            var entity = _context.Estudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (entity != null)
            {
                _context.Estudiantes.Remove(entity);
                _context.SaveChanges();
            }

            return RedirectToAction("Lista");
        }
    }
}
