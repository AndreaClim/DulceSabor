using System.ComponentModel.DataAnnotations;
namespace DulceSabor.Models
{
    public class pedido_linea
    {
        [Key]
        public int id_pedidoL { get; set; }
        public int id_cliente { get; set; }
        public string estado { get; set; }

    }
}
