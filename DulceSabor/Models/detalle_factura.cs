using System.ComponentModel.DataAnnotations;    
namespace DulceSabor.Models
{
    public class detalle_factura
    {
        [Key]
        public int id_detalle { get; set; }
        public int id_factura { get; set; }
        public int id_plato { get; set; }
        public int id_detalle_pedido { get; set; }
        public int id_dpedido { get; set; }
        public int cantidad { get; set; }
        public decimal precio_unitario { get; set; }
        public decimal subtotal { get; set; }
    }
}
