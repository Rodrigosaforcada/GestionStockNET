using GestionStock.Core.Entities;

namespace WebAppGestionStock.Models
{
    public class CompraListViewModel
    {
        public string Titulo { get; set; }
        public string Cantidad { get; set; }
        public CompraResult ComprasResult { get; set; }
    }
}
