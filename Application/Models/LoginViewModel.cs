using System;
using System.ComponentModel.DataAnnotations;

namespace DDD.Sales.Application.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o e-mail.")]
        public String  Email { get; set; }
        [Required(ErrorMessage = "Informe a senha.")]
        public String Senha { get; set; }
    }
}