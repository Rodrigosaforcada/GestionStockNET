using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionStock.Core.DataEF;
using GestionStock.Core.Entities;

namespace GestionStock.Core.Business
{
    public class CategoriaBusiness
    {
        private Core.DataEF.CategoriaRepository _categoriaRepositoryEF;
        public CategoriaBusiness()
        {
            _categoriaRepositoryEF = new GestionStock.Core.DataEF.CategoriaRepository();
        }
        public CategoriaResult GetAll()
        {
            return _categoriaRepositoryEF.GetAll();
        }
        public GenericResult CreateCategoria(string nombreNuevaCategoria)
        {
            Categoria nuevoCategoria = new Categoria();
            int cantidadCategorias = GetAll().Categorias.Count();
            List<Categoria> categorias = GetAll().Categorias;
            int ultimoId = 0;
            foreach (Categoria cat in categorias)
            {
                if (cat.categoriaId > ultimoId)
                {
                    ultimoId = cat.categoriaId;
                }
            }
            nuevoCategoria.categoriaId = ultimoId + 1;
            nuevoCategoria.nombre = nombreNuevaCategoria;

            return _categoriaRepositoryEF.CreateCategoria(nuevoCategoria);
        }
        public Categoria GetAsync(int categoriaId)
        {
            return _categoriaRepositoryEF.GetAsync(categoriaId);
        }
        public GenericResult UpdateAsync(Categoria categoria)
        {
            return _categoriaRepositoryEF.UpdateAsync(categoria);
        }
        public GenericResult DeleteAsync(int usuarioId)
        {
            return _categoriaRepositoryEF.DeleteAsync(usuarioId);
        }
    }
}
