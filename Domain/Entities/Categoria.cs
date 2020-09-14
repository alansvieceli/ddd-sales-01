using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DDD.Sales.Domain.Entities
{
    public class Categoria
    {
        [Key]
        public int?  Codigo { get; set; }
        public String Descricao { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}