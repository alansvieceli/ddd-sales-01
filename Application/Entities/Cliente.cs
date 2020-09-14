using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Cliente
    {
        [Key]
        public int?  Codigo { get; set; }
        public String Nome { get; set; }
        public String CNPJ_CPF { get; set; }
        public String Email { get; set; }
        public String Telefone { get; set; }
        
        public ICollection<Venda> Vendas { get; set; }
    }
}