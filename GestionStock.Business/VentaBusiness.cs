using GestionStock.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Core.Business
{
    public class VentaBusiness
    {
        private readonly Core.DataEF.VentaRepository _ventaRepositoryEF;
        public VentaBusiness(Core.DataEF.VentaRepository ventaRepositoryEF)
        {
            _ventaRepositoryEF = ventaRepositoryEF;
        }
        public VentaResult GetAll()
        {
            return _ventaRepositoryEF.GetAll();
        }
        public GenericResult CreateVenta(DateTime fecha, int productoId, int cantidad, int usuarioId)
        {
            Venta nuevaVenta = new Venta();
            int cantidadVentas = GetAll().Ventas.Count();
            List<Venta> ventas = GetAll().Ventas;
            int ultimoId = 0;
            foreach (Venta vent in ventas)
            {
                if (vent.ventaId > ultimoId)
                {
                    ultimoId = vent.ventaId;
                }
            }
            nuevaVenta.ventaId = ultimoId + 1;
            nuevaVenta.fecha = fecha;
            nuevaVenta.productoId = productoId;
            nuevaVenta.cantidad = cantidad;
            nuevaVenta.usuarioId = usuarioId;

            return _ventaRepositoryEF.CreateCompra(nuevaVenta);
        }
        public Venta GetAsync(int ventaId)
        {
            return _ventaRepositoryEF.GetAsync(ventaId);
        }
        public GenericResult UpdateAsync(Venta venta)
        {
            return _ventaRepositoryEF.UpdateAsync(venta);
        }
        public GenericResult DeleteAsync(int ventaId)
        {
            return _ventaRepositoryEF.DeleteAsync(ventaId);
        }
    }
}
