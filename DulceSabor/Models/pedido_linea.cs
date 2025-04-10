using System.ComponentModel.DataAnnotations;
namespace DulceSabor.Models
{
    public class pedido_linea
    {
        [Key]
        public int id_pedidoL { get; set; }
        public int id_cliente { get; set; }
        public DateTime fechapedido { get; set; }
        public string estado { get; set; }
        public string? metodo_pago { get; set; }
        public decimal total { get; set; }
        public Boolean facturado { get; set; }
        public DateTime fechafactura { get; set; }
        public decimal subtotal { get; set; }

    }
}
