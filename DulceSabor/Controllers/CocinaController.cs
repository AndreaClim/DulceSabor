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

            var pedidosLinea = _context.pedido_linea
                .Where(pl => pl.estado == "Solicitado")
                .ToList();

            // Pasamos ambos conjuntos de datos al ViewBag
            ViewBag.Pedidos = pedidos;
            ViewBag.PedidosLinea = pedidosLinea;

            return View();
        }
        public IActionResult Detalle(int id)
        {
            // Obtén los detalles del pedido con el id proporcionado
            var detalles = _context.detalle_pedido
                .Where(d => d.id_pedido == id)
                .ToList();

            // Obtener todos los platos para asociar con los detalles
            var platos = _context.platos.ToList();

            // Pasar tanto los detalles como los platos a la vista
            ViewBag.Platos = platos;
            return View(detalles);
        }
        public IActionResult DetalleL(int id)
        {
            var detalles = _context.detalle_linea
                .Where(d => d.id_pedidoL == id)
                .ToList();

            var items = _context.item.ToList();
            var platos = _context.platos.ToList();

            ViewBag.Items = items;
            ViewBag.Platos = platos;
            ViewBag.IdPedidoLinea = id;

            return View("DetalleL", detalles);
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
