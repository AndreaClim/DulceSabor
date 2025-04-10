using System.ComponentModel.DataAnnotations;
namespace DulceSabor.Models
{
    public class detalle_linea
    {
        [Key]
        public int id_dpedido { get; set; }
        public int id_pedidoL { get; set; }
        public int id_item { get; set; }
        public decimal precio_unitario { get; set; }    
        public string estado { get; set; }
    }
}
