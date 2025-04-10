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

            var pedidosLinea = _context.pedido_linea
                 .Where(p => p.estado == "Pendiente")
                .ToList();


            var viewModel = new PedidosViewModel
            {
                pedidos = cuentasAbiertas,
                pedidos_linea = pedidosLinea
            };

            return View(viewModel); // ✅ Ahora sí coincide con la vista

        }

    }

}
