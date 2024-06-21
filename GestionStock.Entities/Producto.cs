using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Core.Entities
{
    [Table("Producto")]
    public class Producto
    {
            [Key]
            public int productoId { get; set; }
            [Column("Nombre")]
            public string nombre { get; set; }
            [Column("CategoriaId")]
            public int categoriaId { get; set; }
            [Column("Habilitado")]
            public bool habilitado { get; set; }
    }
}
