using Microsoft.EntityFrameworkCore;
namespace DulceSabor.Models
{
    public class DsContext : DbContext
    {
        public DsContext(DbContextOptions<DsContext> options) : base(options)
        {
        }
        public DbSet<clientes> clientes { get; set; }
        public DbSet<item> item { get; set; }
        public DbSet<mesas> mesas { get; set; }
        public DbSet<detalle_plato> detalle_plato { get; set; }
        public DbSet<platos> platos { get; set; }
        public DbSet<combos> combos { get; set; }
        public DbSet<detalle_factura> detalle_factura { get; set; }
        public DbSet<facturas> facturas { get; set; }
        public DbSet<detalle_pedido> detalle_pedido { get; set; }
        public DbSet<pedidos> pedidos { get; set; }
        public DbSet<detalle_linea> detalle_linea { get; set; }
        public DbSet<pedido_linea> pedido_linea { get; set; }
        public DbSet<Empleados> Empleados { get; set; }

    }
}
