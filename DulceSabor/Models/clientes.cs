using System.ComponentModel.DataAnnotations;
namespace DulceSabor.Models
{
    public class clientes
    {
        [Key]
        public int id_cliente { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string? telefono { get; set; }
    }
}
