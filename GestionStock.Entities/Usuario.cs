using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace GestionStock.Core.Entities
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int usuarioId { get; set; }
        [Column("Nombre")]
        public string nombre { get; set; }
        [Column("Hash")]
        public string hash { get; set; }
        [Column("Salt")]
        public string salt { get; set; }

        public override string ToString()
        {
            return $"{nombre}";
        }

    }
}
