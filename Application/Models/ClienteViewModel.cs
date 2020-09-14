using System;
using System.ComponentModel.DataAnnotations;

namespace DDD.Sales.Application.Models
{
    public class ClienteViewModel
    {
        public int?  Codigo { get; set; }
        [Required(ErrorMessage = "Faltou definir Nome.")]
        public String Nome { get; set; }
        [Required(ErrorMessage = "Faltou definir CNPJ/CPF.")]
        public String CNPJ_CPF { get; set; }
        [Required(ErrorMessage = "Faltou definir E-mail.")]
        public String Email { get; set; }
        [Required(ErrorMessage = "Faltou definir Telefone.")]
        public String Telefone { get; set; }
    }
}