using System.Diagnostics;
using DulceSabor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DulceSabor.Controllers
{
    public class HomeController : Controller
    {
        private readonly DsContext _context;

        public HomeController(DsContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginCajero(string nombre, string apellido)
        {
            var empleado = _context.Empleados
     .FirstOrDefault(e =>
         (e.nombre ?? "").Trim().ToLower() == (nombre ?? "").Trim().ToLower() &&
         (e.apellido ?? "").Trim().ToLower() == (apellido ?? "").Trim().ToLower() &&
         (e.rol ?? "").Trim().ToLower() == "Cajero");


            if (empleado != null)
            {
                return RedirectToAction("Index", "Cajero");
            }

            ViewBag.Error = "Nombre o apellido incorrecto.";
            return View("Login");
        }



        [HttpPost]
        public IActionResult LoginCocina()
        {
            return RedirectToAction("Index", "Cocina");
        }
    }
}