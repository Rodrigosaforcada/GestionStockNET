using System.ComponentModel.DataAnnotations;

namespace GestionStock.AplicacionWeb.Models
{
    public class LoginViewModel
    {
        [Required]
        public int Nombre { get; set; }

        [Required]
        public string Contrasena { get; set; }
    }
}
