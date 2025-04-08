using System.ComponentModel.DataAnnotations;
namespace DulceSabor.Models
{
    public class detalle_plato
    {
        [Key]
        public int id_detalle { get; set; }
        public int id_plato { get; set; }
        public string ingrediente { get; set; }
    }
}
