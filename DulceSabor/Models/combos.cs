using System.ComponentModel.DataAnnotations;    
namespace DulceSabor.Models
{
    public class combos
    {
        [Key]
        public int id_combo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public int id_plato { get; set; }
    }
}

