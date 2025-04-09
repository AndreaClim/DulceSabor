using Microsoft.AspNetCore.Mvc;
using DulceSabor.Models;

namespace DulceSabor.Controllers
{
    public class CajeroController : Controller
    {
        private readonly DsContext _context;

        public CajeroController(DsContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cuentasAbiertas = _context.pedidos
                .Where(p => p.estado == "Solicitado")
                .ToList();

            Console.WriteLine($"Número de pedidos pendientes: {cuentasAbiertas.Count}"); // Para depuración

            return View(cuentasAbiertas);
        }

    }

}
