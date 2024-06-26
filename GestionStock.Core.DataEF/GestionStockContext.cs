using GestionStock.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionStock.Core.DataEF
{
    public class GestionStockContext : DbContext
    {
        public GestionStockContext()
        {
        }

        public GestionStockContext(DbContextOptions<GestionStockContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Venta> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Aquí se configura la cadena de conexión si no está configurada
                optionsBuilder.UseSqlServer("Persist Security Info=True;Initial Catalog=Prog3RecurGoya;Data Source=(local); Application Name=DemoApp;Integrated Security=True;TrustServerCertificate=True;");
            }
        }
    }
}