using DulceSabor.Models;
namespace DulceSabor.Models
{
    public class PedidosViewModel
    {
        public List<pedidos> pedidos { get; set; }
        public List<pedido_linea> pedidos_linea { get; set; }
    }
}
