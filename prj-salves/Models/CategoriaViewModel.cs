using System;
using System.ComponentModel.DataAnnotations;

namespace prj_sales.Models
{
    public class CategoriaViewModel
    {
        public int?  Codigo { get; set; }
        [Required(ErrorMessage = "Faltou definir descrição da categoria")]
        public String Descricao { get; set; }
    }
}