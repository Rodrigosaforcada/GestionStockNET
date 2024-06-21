using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Core.Entities
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public int categoriaId { get; set; }
        [Column("Nombre")]
        public string nombre { get; set; }
    }
}
