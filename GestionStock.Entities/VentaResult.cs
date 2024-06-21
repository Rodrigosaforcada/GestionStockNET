using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Core.Entities
{
    public class VentaResult
    {
        public List<Venta> Ventas { get; set; }
        public string Message { get; set; }
        public bool HasError { get; set; }
    }
}
