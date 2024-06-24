using GestionStock.Core.Entities;

namespace WebAppGestionStock.Models
{
    public class UsuarioListViewModel
    {
        public string Nombre { get; set; }
        public string Cantidad { get; set; }
        public UsuarioResult UsuariosResult { get; set; }
    }
}
