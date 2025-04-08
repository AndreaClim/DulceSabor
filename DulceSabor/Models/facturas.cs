using System.ComponentModel.DataAnnotations;
namespace DulceSabor.Models
{
    public class facturas
    {
        [Key]
        public int id_factura { get; set; }
        public DateTime fecha_factura { get; set; }
        public decimal total { get; set; }
        public string? tipo { get; set; }
        //si en linea o local
        public string metodo_pago { get; set; } 
    }
}
