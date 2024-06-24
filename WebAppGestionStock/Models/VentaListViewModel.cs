using GestionStock.Core.Entities;

namespace WebAppGestionStock.Models
{
    public class VentaListViewModel
    {
        public string Titulo { get; set; }
        public string Cantidad { get; set; }
        public VentaResult VentaResult { get; set; }
    }
}
