using GestionStock.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Core.DataEF
{
    public class CategoriaRepository
    {
        public CategoriaRepository() { }

        public CategoriaResult GetAll()
        {
            var result = new CategoriaResult();

            using (var db = new GestionStockContext())
            {
                result.Categorias = db.Categorias.ToList();
            }

            return result;
        }
        public GenericResult CreateCategoria(Categoria categoria)
        {
            using (var db = new GestionStockContext())
            {
                db.Add(categoria);
                db.SaveChanges();
            }
            var result = new GenericResult();
            result.IsSuccessful = true;
            return result;
        }
        public Categoria GetAsync(int categoriaId)
        {
            using (var db = new GestionStockContext())
            {
                var categoria = from cat in db.Categorias
                              where cat.categoriaId == categoriaId
                                select cat;

                return categoria.FirstOrDefault();
            }
        }
        public GenericResult UpdateAsync(Categoria categoria)
        {
            using (var db = new GestionStockContext())
            {
                db.Attach(categoria);
                db.Entry(categoria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                db.SaveChanges();
            }
            var result = new GenericResult();
            result.IsSuccessful = true;
            return result;
        }
        public GenericResult DeleteAsync(int categoriaId)
        {
            var result = new GenericResult();

            using (var db = new GestionStockContext())
            {
                var categoria = from cat in db.Categorias
                              where cat.categoriaId == categoriaId
                                select cat;

                var entntyEntry = db.Categorias.Remove(categoria.FirstOrDefault());

                db.SaveChanges();
            }

            result.IsSuccessful = true;

            return result;
        }
    }
}
