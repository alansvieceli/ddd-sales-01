using System;
using System.ComponentModel.DataAnnotations;

namespace DDD.Sales.Application.Models
{
    public class CategoriaViewModel
    {
        public int?  Codigo { get; set; }
        [Required(ErrorMessage = "Faltou definir descrição da categoria.")]
        public String Descricao { get; set; }
    }
}