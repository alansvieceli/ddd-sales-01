using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDD.Sales.Domain.Entities
{
    public class Venda : EntityBase
    {
        public DateTime Data { get; set; }
        public decimal Total { get; set; }
        [ForeignKey("Cliente")]
        public int CodigoCliente { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<VendaProdutos> Produtos { get; set; }
    }
}