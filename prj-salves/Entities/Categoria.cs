﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prj_sales.Entities
{
    public class Categoria
    {
        [Key]
        public int?  Codigo { get; set; }
        public String Descricao { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}