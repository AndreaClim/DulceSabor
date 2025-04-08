using System.ComponentModel.DataAnnotations;

namespace DulceSabor.Models
{
    public class item
    {
        [Key]
        public int id_item { get; set; }
        public int id_combo { get; set; }
        public int id_plato { get; set; }
        public string? estado { get; set; }

    }
}
