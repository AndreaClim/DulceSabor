using Microsoft.AspNetCore.Mvc;
using DulceSabor.Models;

namespace DulceSabor.Controllers
{
    public class CocinaController : Controller
    {
        private readonly DsContext _context;

        public CocinaController(DsContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var pedidos = _context.pedidos
                .Where(p => p.estado == "Solicitado")
                .ToList();

            return View(pedidos);
        }

        public IActionResult Detalle(int id)
        {
            var pedido = _context.pedidos.FirstOrDefault(p => p.id_pedido == id);
            return View(pedido);
        }

        [HttpPost]
        public IActionResult ActualizarEstado(int id)
        {
            var pedido = _context.pedidos.FirstOrDefault(p => p.id_pedido == id);
            if (pedido != null)
            {
                pedido.estado = "Finalizado";
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }

}
