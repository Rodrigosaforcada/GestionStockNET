using GestionStock.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Core.Business
{
    public class CompraBusiness
    {
        private Core.DataEF.CompraRepository _compraRepositoryEF;
        public CompraBusiness()
        {
            _compraRepositoryEF = new GestionStock.Core.DataEF.CompraRepository();
        }
        public CompraResult GetAll()
        {
            return _compraRepositoryEF.GetAll();
        }
        public GenericResult CreateCompra(DateTime fecha, int productoId, int cantidad, int usuarioId)
        {
            Compra nuevaCompra = new Compra();
            int cantidadCompras = GetAll().Compras.Count();
            List<Compra> compras = GetAll().Compras;
            int ultimoId = 0;
            foreach (Compra com in compras)
            {
                if (com.compraId > ultimoId)
                {
                    ultimoId = com.compraId;
                }
            }
            nuevaCompra.compraId = ultimoId + 1;
            nuevaCompra.fecha = fecha;
            nuevaCompra.productoId = productoId;
            nuevaCompra.cantidad = cantidad;
            nuevaCompra.usuarioId = usuarioId;

            return _compraRepositoryEF.CreateCompra(nuevaCompra);
        }
        public Compra GetAsync(int compraId)
        {
            return _compraRepositoryEF.GetAsync(compraId);
        }
        public GenericResult UpdateAsync(Compra compra)
        {
            return _compraRepositoryEF.UpdateAsync(compra);
        }
        public GenericResult DeleteAsync(int compraId)
        {
            return _compraRepositoryEF.DeleteAsync(compraId);
        }
    }
}
