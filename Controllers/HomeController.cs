using Microsoft.AspNetCore.Mvc;
using TodoWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace TodoWebApp.Controllers
{
    public class HomeController : Controller
    {
        // Lista estática en memoria para practicar (luego puedes usar DB)
        private static List<Tarea> tareas = new List<Tarea>();

        public IActionResult Index()
        {
            return View(tareas);
        }

        [HttpPost]
        public IActionResult Agregar(string descripcion)
        {
            if (!string.IsNullOrWhiteSpace(descripcion))
            {
                int nuevoId = tareas.Count > 0 ? tareas.Max(t => t.Id) + 1 : 1;
                tareas.Add(new Tarea { Id = nuevoId, Descripcion = descripcion, Completada = false });
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var tarea = tareas.FirstOrDefault(t => t.Id == id);
            if (tarea != null) tareas.Remove(tarea);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult MarcarComoCompletada(int id)
        {
            var tarea = tareas.FirstOrDefault(t => t.Id == id);
            if (tarea != null) tarea.Completada = true;

            return RedirectToAction("Index");
        }
    }
}

