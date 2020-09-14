using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DDD.Sales.Application.Models
{
    public class ProdutoViewModel
    {
        public int?  Codigo { get; set; }
        [Required(ErrorMessage = "Faltou definir descrição.")]
        public String Descricao { get; set; }
        [Required(ErrorMessage = "Faltou definir quantidade.")]
        public double Quantidade { get; set; }
        [Required(ErrorMessage = "Faltou definir valor unitário do produto.")]
        [Range(0.1, Double.PositiveInfinity, ErrorMessage = "Valor deve ser positivo")]
        [DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        public decimal Valor { get; set; }
        [Required(ErrorMessage = "Faltou definir categoria do produto.")]
        public int? CodigoCategoria { get; set; }
        public IEnumerable<SelectListItem> ListaCategorias { get; set; }
    }
}