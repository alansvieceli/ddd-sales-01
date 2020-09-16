using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDD.Sales.Domain.Entities
{
    public class Produto : EntityBase
    {
        public String Descricao { get; set; }
        public double Quantidade { get; set; }
        public decimal Valor { get; set; }
        
        [ForeignKey("Categoria")]
        public int CodigoCategoria { get; set; }
        public Categoria Categoria { get; set; }
        
        public ICollection<VendaProdutos> Vendas { get; set; }
    }
}