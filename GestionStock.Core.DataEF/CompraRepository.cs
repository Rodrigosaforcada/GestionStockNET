using GestionStock.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Core.DataEF
{
    public class CompraRepository
    {
        public CompraRepository() { }

        public CompraResult GetAll()
        {
            var result = new CompraResult();

            using (var db = new GestionStockContext())
            {
                result.Compras = db.Compras.ToList();
            }

            return result;
        }
        public GenericResult CreateCompra(Compra compra)
        {
            using (var db = new GestionStockContext())
            {
                db.Add(compra);
                db.SaveChanges();
            }
            var result = new GenericResult();
            result.IsSuccessful = true;
            return result;
        }
        public Compra GetAsync(int compraId)
        {
            using (var db = new GestionStockContext())
            {
                var compra = from comp in db.Compras
                               where comp.compraId == compraId
                             select comp;

                return compra.FirstOrDefault();
            }
        }
        public GenericResult UpdateAsync(Compra compra)
        {
            using (var db = new GestionStockContext())
            {
                db.Attach(compra);
                db.Entry(compra).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                db.SaveChanges();
            }
            var result = new GenericResult();
            result.IsSuccessful = true;
            return result;
        }
        public GenericResult DeleteAsync(int compraId)
        {
            var result = new GenericResult();

            using (var db = new GestionStockContext())
            {
                var compra = from comp in db.Compras
                             where comp.compraId == compraId
                             select comp;

                var entntyEntry = db.Compras.Remove(compra.FirstOrDefault());

                db.SaveChanges();
            }

            result.IsSuccessful = true;

            return result;
        }

        public int GetTotalComprasPorProducto(int productoId)
        {
            using (var db = new GestionStockContext())
            {
                return db.Compras
                    .Where(c => c.productoId == productoId)
                    .Sum(c => c.cantidad);
            }
        }
    }
}
