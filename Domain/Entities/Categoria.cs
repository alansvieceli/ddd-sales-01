using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DDD.Sales.Domain.Entities
{
    public class Categoria : EntityBase
    {
        public String Descricao { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}