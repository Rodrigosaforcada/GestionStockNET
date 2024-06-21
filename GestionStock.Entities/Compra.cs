using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Core.Entities
{
    [Table("Compra")]
    public class Compra
    {
        [Key]
        public int compraId { get; set; }
        [Column("Fecha")]
        public DateTime fecha { get; set; }
        [Column("ProductoId")]
        public int productoId { get; set; }
        [Column("Cantidad")]
        public int cantidad { get; set; }
        [Column("UsuarioId")]
        public int usuarioId { get; set; }
    }
}
