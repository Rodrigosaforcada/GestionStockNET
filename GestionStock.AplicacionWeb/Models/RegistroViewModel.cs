using System.ComponentModel.DataAnnotations;

namespace GestionStock.AplicacionWeb.Models
{
    public class RegistroViewModel
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }
    }
}
