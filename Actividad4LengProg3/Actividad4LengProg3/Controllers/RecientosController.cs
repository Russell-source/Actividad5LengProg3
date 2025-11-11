using Microsoft.AspNetCore.Mvc;
using Actividad4LengProg3.Models;
using System.Collections.Generic;
using System.Linq;

namespace Actividad4LengProg3.Controllers
{
    public class RecintosController : Controller
    {
        private static List<RecintoViewModel> recintos = new List<RecintoViewModel>();

        public IActionResult Index() => View(recintos);

        public IActionResult Crear() => View(new RecintoViewModel());

        [HttpPost]
        public IActionResult Crear(RecintoViewModel recinto)
        {
            if (ModelState.IsValid)
            {
                recintos.Add(recinto);
                return RedirectToAction("Index");
            }
            return View(recinto);
        }

        public IActionResult Editar(string codigo)
        {
            var recinto = recintos.FirstOrDefault(r => r.Codigo == codigo);
            return recinto == null ? NotFound() : View(recinto);
        }

        [HttpPost]
        public IActionResult Editar(RecintoViewModel recinto)
        {
            var original = recintos.FirstOrDefault(r => r.Codigo == recinto.Codigo);
            if (original == null) return NotFound();

            if (ModelState.IsValid)
            {
                recintos.Remove(original);
                recintos.Add(recinto);
                return RedirectToAction("Index");
            }
            return View(recinto);
        }

        public IActionResult Eliminar(string codigo)
        {
            var recinto = recintos.FirstOrDefault(r => r.Codigo == codigo);
            if (recinto != null) recintos.Remove(recinto);
            return RedirectToAction("Index");
        }
    }
}
