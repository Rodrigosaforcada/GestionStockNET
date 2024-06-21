using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Core.Entities
{
    [Table("Venta")]
    public class Venta
    {
        [Key]
        public int ventaId { get; set; }
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
