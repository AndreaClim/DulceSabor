namespace DulceSabor.Models
{
    public class DetallePagoViewModel
    {
        public List<DetallePlato> Detalles { get; set; }
        public decimal Total { get; set; }
        public int IdPedido { get; set; }
        public string TipoPedido { get; set; }
    }

    public class DetallePlato
    {
        public string NombrePlato { get; set; }
        public decimal Precio { get; set; }
    }
}

