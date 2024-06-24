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
        private readonly GestionStock.Core.DataEF.CompraRepository _compraRepositoryEF;
        public CompraBusiness(GestionStock.Core.DataEF.CompraRepository compraRepositoryEF)
        {
            _compraRepositoryEF = compraRepositoryEF;
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

            DateTime fechaIngresada = new DateTime(fecha.Year, fecha.Month, fecha.Day);
            DateTime fechaActual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            TimeSpan diferenciaDeDias = fechaIngresada - fechaActual;
            double dif = -7.0;
            if (diferenciaDeDias.TotalDays < dif || diferenciaDeDias.TotalDays > 0)
            {
                GenericResult diasError = new GenericResult();
                diasError.HasError = true;
                diasError.Message = "No se puede asignar una fecha con mas de 7 dias de anterioridad o que sea posterior al dia de hoy.";
                return diasError;
            }

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
