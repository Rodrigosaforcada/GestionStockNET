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
        private ProductoRepository _productoRepositoryEF;
        private readonly CompraRepository _compraRepository;
        private readonly VentaRepository _ventaRepository;

        public ProductoBusiness()
        {
            _productoRepositoryEF = new ProductoRepository();
            _compraRepository = new CompraRepository(); // Repositorio de compras
            _ventaRepository = new VentaRepository();   // Repositorio de ventas
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
       
        public int CalcularStockActual(int productoId)
        {
            // Obtener la cantidad total comprada
            int totalCompras = _compraRepository.GetTotalComprasPorProducto(productoId);

            // Obtener la cantidad total vendida
            int totalVentas = _ventaRepository.GetTotalVentasPorProducto(productoId);

            // Calcular el stock actual
            int stockActual = totalCompras - totalVentas;

            return stockActual;
        }

    }
    }

