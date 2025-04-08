using System.ComponentModel.DataAnnotations;
namespace DulceSabor.Models
{
    public class platos
    {
        [Key]
        public int id_plato { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
    }
}
