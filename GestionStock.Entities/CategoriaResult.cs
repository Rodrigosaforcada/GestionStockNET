﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Core.Entities
{
    public class CategoriaResult
    {
        public List<Categoria> Categorias { get; set; }
        public string Message { get; set; }
        public bool HasError { get; set; }
    }
}
