    using System.Diagnostics;
    using DulceSabor.Models;
    using Microsoft.AspNetCore.Mvc;

    namespace DulceSabor.Controllers
    {
    public class HomeController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginCajero(string nombre, string apellido)
        {
            // Aquí podrías validar login si quieres
            return RedirectToAction("Index", "Cajero");
        }

        [HttpPost]
        public IActionResult LoginCocina()
        {
            return RedirectToAction("Index", "Cocina");
        }
    }
}
