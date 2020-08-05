﻿using System;
using System.ComponentModel.DataAnnotations;

namespace prj_sales.Entities
{
    public class Usuario
    {
        [Key]
        public int?  Codigo { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }
    }
}