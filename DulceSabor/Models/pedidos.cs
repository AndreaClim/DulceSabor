using System.ComponentModel.DataAnnotations;
namespace DulceSabor.Models
{
    public class pedidos
    {
        [Key]
        public int id_pedido { get; set; }
        public int id_cliente { get; set; }
        public int id_mesa { get; set; }
        public DateTime fecha_pedido { get; set; }
        public string estado { get; set; }
       
    }
}
