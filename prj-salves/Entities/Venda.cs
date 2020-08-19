using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prj_sales.Entities
{
    public class Venda
    {
        [Key]
        public int?  Codigo { get; set; }
        public DateTime Data { get; set; }
        public decimal Total { get; set; }
        [ForeignKey("Cliente")]
        public int CodigoCliente { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<VendaProdutos> Produtos { get; set; }
    }
}