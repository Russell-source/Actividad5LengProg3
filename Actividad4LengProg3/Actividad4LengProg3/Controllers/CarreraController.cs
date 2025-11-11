using Microsoft.AspNetCore.Mvc;
using Actividad4LengProg3.Models;
using System.Collections.Generic;
using System.Linq;

namespace Actividad4LengProg3.Controllers
{
    public class CarrerasController : Controller
    {
        private static List<CarreraViewModel> carreras = new List<CarreraViewModel>();

        public IActionResult Index() => View(carreras);

        public IActionResult Crear() => View(new CarreraViewModel());

        [HttpPost]
        public IActionResult Crear(CarreraViewModel carrera)
        {
            if (ModelState.IsValid)
            {
                carreras.Add(carrera);
                return RedirectToAction("Index");
            }
            return View(carrera);
        }

        public IActionResult Editar(string codigo)
        {
            var carrera = carreras.FirstOrDefault(c => c.Codigo == codigo);
            return carrera == null ? NotFound() : View(carrera);
        }

        [HttpPost]
        public IActionResult Editar(CarreraViewModel carrera)
        {
            var original = carreras.FirstOrDefault(c => c.Codigo == carrera.Codigo);
            if (original == null) return NotFound();

            if (ModelState.IsValid)
            {
                carreras.Remove(original);
                carreras.Add(carrera);
                return RedirectToAction("Index");
            }
            return View(carrera);
        }

        public IActionResult Eliminar(string codigo)
        {
            var carrera = carreras.FirstOrDefault(c => c.Codigo == codigo);
            if (carrera != null) carreras.Remove(carrera);
            return RedirectToAction("Index");
        }
    }
}
