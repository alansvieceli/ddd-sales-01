using System;
using System.Collections.Generic;

namespace DDD.Sales.Domain.Entities
{
    public class Cliente : EntityBase
    {
        public String Nome { get; set; }
        public String CNPJ_CPF { get; set; }
        public String Email { get; set; }
        public String Telefone { get; set; }
        
        public ICollection<Venda> Vendas { get; set; }
    }
}