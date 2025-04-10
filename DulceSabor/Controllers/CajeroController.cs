using Microsoft.AspNetCore.Mvc;
using DulceSabor.Models;
using System.Linq;

namespace DulceSabor.Controllers
{
    public class CajeroController : Controller
    {
        private readonly DsContext _context;

        public CajeroController(DsContext context)
        {
            _context = context;
        }

        // Mostrar la vista principal con las tablas de pedidos dfdtgsfgffgd
        public IActionResult Index()
        {
            var cuentasAbiertas = _context.pedidos
                .Where(p => p.estado == "Solicitado")
                .ToList();

            var pedidosLinea = _context.pedido_linea
                .Where(p => p.estado == "Pendiente")
                .ToList();

            var viewModel = new PedidosViewModel
            {
                pedidos = cuentasAbiertas,
                pedidos_linea = pedidosLinea
            };

            return View(viewModel);
        }
        [HttpPost]
        [HttpPost]
        public IActionResult SeleccionarMetodoPago(int idPedido, string tipoPedido, string metodoPago)
        {
            return RedirectToAction("DetallePago", new
            {
                id = idPedido,
                tipo = tipoPedido,
                metodo = metodoPago
            });
        }



        // Recibe el tipo de pago y guarda en TempData para redirigir a DetallePago
        [HttpGet]

        public IActionResult DetallePago(int id, string tipo, string metodo)
        {
            var detallePlatos = new List<DetallePlato>();

            if (tipo == "restaurante")
            {
                detallePlatos = (from d in _context.detalle_pedido
                                 join p in _context.platos on d.id_plato equals p.id_plato
                                 where d.id_pedido == id
                                 select new DetallePlato
                                 {
                                     NombrePlato = p.nombre,
                                     Precio = p.precio
                                 }).ToList();
            }
            else if (tipo == "enlinea")
            {
                detallePlatos = (from d in _context.detalle_linea
                                 join i in _context.item on d.id_item equals i.id_item
                                 join p in _context.platos on i.id_plato equals p.id_plato
                                 where d.id_pedidoL == id
                                 select new DetallePlato
                                 {
                                     NombrePlato = p.nombre,
                                     Precio = d.precio_unitario
                                 }).ToList();
            }

            var total = detallePlatos.Sum(p => p.Precio);

            var modelo = new DetallePagoViewModel
            {
                Detalles = detallePlatos,
                Total = total,
                IdPedido = id,
                TipoPedido = tipo
            };

            ViewBag.MetodoPago = metodo;

            if (TempData["pagoRealizado"] != null)
            {
                ViewBag.MensajePago = "Pago realizado con éxito.";
            }

            return View(modelo);
        }



        [HttpPost]
        [HttpPost]
        public IActionResult CobrarEfectivo(int idPedido, string tipoPedido)
        {
            if (tipoPedido == "restaurante")
            {
                var pedido = _context.pedidos.Find(idPedido);
                if (pedido != null)
                {
                    pedido.estado = "Pagado"; // Marca como pagado
                }
            }
            else if (tipoPedido == "enlinea")
            {
                var pedido = _context.pedido_linea.Find(idPedido);
                if (pedido != null)
                {
                    pedido.estado = "Pagado"; // Marca como pagado
                }
            }

            _context.SaveChanges();

            TempData["pedidoId"] = idPedido;
            TempData["tipoPedido"] = tipoPedido;
            TempData["metodoPago"] = "efectivo";
            TempData["pagoRealizado"] = "true";

            return RedirectToAction("DetallePago");
        }


        [HttpPost]
        public IActionResult CobrarTarjeta(int idPedido, string tipoPedido, string numeroTarjeta, string cvv, string expiracion)
        {
            // Aquí podrías hacer validaciones reales
            if (tipoPedido == "restaurante")
            {
                var pedido = _context.pedidos.Find(idPedido);
                if (pedido != null)
                {
                    _context.pedidos.Remove(pedido);
                }
            }
            else if (tipoPedido == "enlinea")
            {
                var pedido = _context.pedido_linea.Find(idPedido);
                if (pedido != null)
                {
                    _context.pedido_linea.Remove(pedido);
                }
            }

            _context.SaveChanges();

            TempData["pedidoId"] = idPedido;
            TempData["tipoPedido"] = tipoPedido;
            TempData["metodoPago"] = "tarjeta";
            ViewBag.MensajePago = "Pago con tarjeta realizado con éxito.";
            return RedirectToAction("DetallePago");
        }
    }
}
