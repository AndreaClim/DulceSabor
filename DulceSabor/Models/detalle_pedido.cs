using System.ComponentModel.DataAnnotations;
namespace DulceSabor.Models
{
    public class detalle_pedido
    {
        [Key]
        public int id_detalle { get; set; }
        public int id_pedido { get; set; }
        public int id_plato { get; set; }
        public string? comentarios { get; set; }
       
    }
}
