using GestionStock.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Core.DataEF
{
    internal class GestionStockContext : DbContext
    {
        private readonly string CONNECTIONSTRING = "Persist Security Info=True;Initial Catalog=Prog3RecurGoya;Data Source=LAPTOPLOCAL1234\\SQLEXPRESS; Application Name=DemoApp;Integrated Security=True;TrustServerCertificate=True;";

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Venta> Ventas { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTIONSTRING);
        }
    }
}
