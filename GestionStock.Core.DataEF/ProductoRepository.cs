using GestionStock.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Core.DataEF
{
    public class ProductoRepository
    {
        public ProductoRepository() { }

        public ProductoResult GetAll()
        {
            var result = new ProductoResult();

            using (var db = new GestionStockContext())
            {
                result.Productos = db.Productos.ToList();
            }

            return result;
        }
        public GenericResult CreateProducto(Producto producto)
        {
            using (var db = new GestionStockContext())
            {
                db.Add(producto);
                db.SaveChanges();
            }
            var result = new GenericResult();
            result.IsSuccessful = true;
            return result;
        }
        public Producto GetAsync(int productoId)
        {
            using (var db = new GestionStockContext())
            {
                var producto = from prod in db.Productos
                               where prod.productoId == productoId
                               select prod;

                return producto.FirstOrDefault();
            }
        }
        public GenericResult UpdateAsync(Producto producto)
        {
            using (var db = new GestionStockContext())
            {
                db.Attach(producto);
                db.Entry(producto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                db.SaveChanges();
            }
            var result = new GenericResult();
            result.IsSuccessful = true;
            return result;
        }
        public GenericResult DeleteAsync(int productoId)
        {
            var result = new GenericResult();

            using (var db = new GestionStockContext())
            {
                var producto = from prod in db.Productos
                                where prod.productoId == productoId
                               select prod;

                var entntyEntry = db.Productos.Remove(producto.FirstOrDefault());

                db.SaveChanges();
            }

            result.IsSuccessful = true;

            return result;
        }

        
    }
}
