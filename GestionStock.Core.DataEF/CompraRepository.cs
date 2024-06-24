using GestionStock.Core.Configuration;
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
        private readonly Config _config;
        public CompraRepository(Config config) 
        { 
            _config = config; 
        }

        public CompraResult GetAll()
        {
            var result = new CompraResult();

            using (var db = new GestionStockContext(_config))
            {
                result.Compras = db.Compras.ToList();
            }

            return result;
        }
        public GenericResult CreateCompra(Compra compra)
        {
            using (var db = new GestionStockContext(_config))
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
            using (var db = new GestionStockContext(_config))
            {
                var compra = from comp in db.Compras
                               where comp.compraId == compraId
                             select comp;

                return compra.FirstOrDefault();
            }
        }
        public GenericResult UpdateAsync(Compra compra)
        {
            using (var db = new GestionStockContext(_config))
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

            using (var db = new GestionStockContext(_config))
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
    }
}
