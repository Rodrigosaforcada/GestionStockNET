using GestionStock.Core.Entities;

namespace WebAppGestionStock.Models
{
    public class ProductoListViewModel
    {
        public string Nombre { get; set; }
        public string Cantidad { get; set; }
        public ProductoResult ProductosResult { get; set; }
    }
}
