using System.ComponentModel.DataAnnotations;

namespace DulceSabor.Models
{
    public class Empleados
    {
        [Key]
        public int id_empleado { get; set; }

        public string nombre { get; set; }
        public string apellido { get; set; }
        public string rol { get; set; }
    }
}
