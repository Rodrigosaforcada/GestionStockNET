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
    }
}
