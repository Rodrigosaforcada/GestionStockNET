using GestionStock.Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Core.DataEF
{
    public class VentaRepository
    {
        public VentaRepository() { }

        public VentaResult GetAll()
        {
            var result = new VentaResult();

            using (var db = new GestionStockContext())
            {
                result.Ventas = db.Ventas.ToList();
            }

            return result;
        }
        public GenericResult CreateCompra(Venta venta)
        {
            using (var db = new GestionStockContext())
            {
                db.Add(venta);
                db.SaveChanges();
            }
            var result = new GenericResult();
            result.IsSuccessful = true;
            return result;
        }
        public Venta GetAsync(int ventaId)
        {
            using (var db = new GestionStockContext())
            {
                var venta = from vent in db.Ventas
                             where vent.ventaId == ventaId
                            select vent;

                return venta.FirstOrDefault();
            }
        }
        public GenericResult UpdateAsync(Venta venta)
        {
            using (var db = new GestionStockContext())
            {
                db.Attach(venta);
                db.Entry(venta).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                db.SaveChanges();
            }
            var result = new GenericResult();
            result.IsSuccessful = true;
            return result;
        }
        public GenericResult DeleteAsync(int ventaId)
        {
            var result = new GenericResult();

            using (var db = new GestionStockContext())
            {
                var venta = from vent in db.Ventas
                            where vent.ventaId == ventaId
                            select vent;

                var entntyEntry = db.Ventas.Remove(venta.FirstOrDefault());

                db.SaveChanges();
            }

            result.IsSuccessful = true;

            return result;
        }
        public int GetTotalVentasPorProducto(int productoId)
        {
            using (var db = new GestionStockContext())
            {
                return db.Ventas
                    .Where(v => v.productoId == productoId)
                    .Sum(v => v.cantidad);
            }
        }
    }
}
