using GestionStock.Core.Configuration;
using GestionStock.Core.DataEF;
using GestionStock.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Core.Business
{
    public class ProductoBusiness
    {
        private readonly Core.DataEF.ProductoRepository _productoRepositoryEF;
        public ProductoBusiness(Core.DataEF.ProductoRepository productoRepositoryEF)
        {
            _productoRepositoryEF = productoRepositoryEF;
        }
        public ProductoResult GetAll()
        {
            return _productoRepositoryEF.GetAll();
        }
        public GenericResult CreateProducto(string nombreNuevoProducto, int categoriaId)
        {
            Producto nuevoProducto = new Producto();
            int cantidadProductos = GetAll().Productos.Count();
            List<Producto> productos = GetAll().Productos;
            int ultimoId = 0;
            foreach (Producto prod in productos)
            {
                if(prod.nombre == nombreNuevoProducto)
                {
                    GenericResult nombreRepetido = new GenericResult();
                    nombreRepetido.HasError = true;
                    nombreRepetido.Message = "El nombre ya existe en el sistema, elija otro distinto.";
                    return nombreRepetido;
                }
                if (prod.productoId > ultimoId)
                {
                    ultimoId = prod.productoId;
                }
            }
            nuevoProducto.productoId = ultimoId + 1;
            nuevoProducto.nombre = nombreNuevoProducto;
            nuevoProducto.categoriaId = categoriaId;
            nuevoProducto.habilitado = false;

            return _productoRepositoryEF.CreateProducto(nuevoProducto);
        }
        public Producto GetAsync(int productoId)
        {
            return _productoRepositoryEF.GetAsync(productoId);
        }
        public GenericResult UpdateAsync(Producto producto)
        {
            return _productoRepositoryEF.UpdateAsync(producto);
        }
        public GenericResult DeleteAsync(int productoId)
        {
            return _productoRepositoryEF.DeleteAsync(productoId);
        }
        public int GetStockProducto(int productoId)
        {
            var _config = new Config();
            _config.ConnectionString = "Persist Security Info=True;Initial Catalog=Prog3RecurGoya;Data Source=LAPTOPLOCAL1234\\SQLEXPRESS; Application Name=DemoApp;Integrated Security=True;TrustServerCertificate=True;";

            var _compraRepositoryEF = new GestionStock.Core.DataEF.CompraRepository(_config);
            var _ventaRepositoryEF = new GestionStock.Core.DataEF.VentaRepository(_config);

            CompraBusiness compraResultConsulta = new CompraBusiness(_compraRepositoryEF);
            VentaBusiness ventaResultConsulta = new VentaBusiness(_ventaRepositoryEF);
            List<Compra> compras = compraResultConsulta.GetAll().Compras;
            List<Venta> ventas = ventaResultConsulta.GetAll().Ventas;

            int totalCompras = 0;
            foreach (Compra compra in compras)
            {
                if(compra.productoId == productoId)
                {
                    totalCompras += compra.cantidad;
                }
            }
            int totalVentas = 0;
            foreach (Venta venta in ventas)
            {
                if (venta.productoId == productoId)
                {
                    totalVentas += venta.cantidad;
                }
            }
            int stockProducto = totalCompras - totalVentas;

            return stockProducto;
        }
    }
}
