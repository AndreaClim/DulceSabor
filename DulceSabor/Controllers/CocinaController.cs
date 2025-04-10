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

            
            ViewBag.Pedidos = pedidos;
            ViewBag.PedidosLinea = pedidosLinea;

            return View();
        }
        public IActionResult Detalle(int id)
        {
            
            var detalles = _context.detalle_pedido
                .Where(d => d.id_pedido == id)
                .ToList();

            
            var platos = _context.platos.ToList();

         
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


            return View(detalles);
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

        [HttpPost]
        public IActionResult CambiarEstadoDetallePedido(int id)
        {
            var detalle = _context.detalle_pedido.FirstOrDefault(d => d.id_detalle == id);
            if (detalle != null)
            {
               
                detalle.estado = detalle.estado == "En proceso" ? "Finalizado" : "En proceso";
                _context.SaveChanges();

                var todosEnProceso = _context.detalle_pedido
                    .Where(d => d.id_pedido == detalle.id_pedido)
                    .All(d => d.estado == "En proceso");

                
                var todosFinalizados = _context.detalle_pedido
                    .Where(d => d.id_pedido == detalle.id_pedido)
                    .All(d => d.estado == "Finalizado");

                
                if (todosEnProceso)
                {
                    var pedido = _context.pedidos.FirstOrDefault(p => p.id_pedido == detalle.id_pedido);
                    if (pedido != null)
                    {
                        pedido.estado = "En proceso";
                        _context.SaveChanges();
                    }
                }
                else if (todosFinalizados)
                {
                    var pedido = _context.pedidos.FirstOrDefault(p => p.id_pedido == detalle.id_pedido);
                    if (pedido != null)
                    {
                        pedido.estado = "Finalizado";
                        _context.SaveChanges();
                    }
                }
                else
                {
                    var pedido = _context.pedidos.FirstOrDefault(p => p.id_pedido == detalle.id_pedido);
                    if (pedido != null)
                    {
                        pedido.estado = "Solicitado";
                        _context.SaveChanges();
                    }
                }
            }

            return RedirectToAction("Detalle", new { id = detalle.id_pedido });
        }



        [HttpPost]
        public IActionResult CambiarEstadoDetalleLinea(int id)
        {
            var detalle = _context.detalle_linea.FirstOrDefault(d => d.id_dpedido == id);
            if (detalle != null)
            {
              
                detalle.estado = detalle.estado == "En proceso" ? "Finalizado" : "En proceso";
                _context.SaveChanges();

                
                var todosEnProceso = _context.detalle_linea
                    .Where(d => d.id_pedidoL == detalle.id_pedidoL)
                    .All(d => d.estado == "En proceso");

                var todosFinalizados = _context.detalle_linea
                    .Where(d => d.id_pedidoL == detalle.id_pedidoL)
                    .All(d => d.estado == "Finalizado");

                if (todosEnProceso)
                {
                    var pedido = _context.pedido_linea.FirstOrDefault(p => p.id_pedidoL == detalle.id_pedidoL);
                    if (pedido != null)
                    {
                        pedido.estado = "En proceso"; 
                        _context.SaveChanges();
                    }
                }
               
                else if (todosFinalizados)
                {
                    var pedido = _context.pedido_linea.FirstOrDefault(p => p.id_pedidoL == detalle.id_pedidoL);
                    if (pedido != null)
                    {
                        pedido.estado = "Finalizado"; 
                        _context.SaveChanges();
                    }
                }
                else
                {
                   
                    var pedido = _context.pedido_linea.FirstOrDefault(p => p.id_pedidoL == detalle.id_pedidoL);
                    if (pedido != null)
                    {
                        pedido.estado = "Solicitado"; 
                        _context.SaveChanges();
                    }
                }
            }

            return RedirectToAction("DetalleL", new { id = detalle.id_pedidoL });
        }



    }

}
