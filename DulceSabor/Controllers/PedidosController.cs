using Microsoft.AspNetCore.Mvc;
using DulceSabor.Models;
using System.Linq;

namespace DulceSabor.Controllers
{
    public class PedidosController : Controller
    {
        private readonly DsContext _context;

        // Inyección del DbContext a través del constructor
        public PedidosController(DsContext context)
        {
            _context = context;
        }

        // Acción que devuelve la lista de pedidos a la vista
        public IActionResult Index()
        {
            // Recuperar los pedidos de la base de datos
            var pedidos = _context.pedidos.ToList(); // Recupera todos los pedidos, incluidos los estados

            return View(pedidos); // Pasa los pedidos a la vista
        }

    }
}
