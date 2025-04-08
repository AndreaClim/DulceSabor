using System.ComponentModel.DataAnnotations;
namespace DulceSabor.Models
{
    public class mesas
    {
        [Key]
        public int id_mesa { get; set; }
        public int capacidad { get; set; }
        public string? estado { get; set; }
    }
}
