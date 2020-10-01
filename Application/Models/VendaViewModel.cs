using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DDD.Sales.Application.Models
{
    public class VendaViewModel
    {
        public int?  Codigo { get; set; }
        [Required(ErrorMessage = "Informe a data da venda.")]
        public DateTime? Data { get; set; }
        [Required(ErrorMessage = "Informe o Cliente.")]
        public int? CodigoCliente { get; set; }
        public string DescricaoCliente { get; set; }
        public IEnumerable<SelectListItem> ListaClientes { get; set; }
        public IEnumerable<SelectListItem> ListaProdutos { get; set; }
        public String JsonProdutos { get; set; }
        public decimal Total { get; set; }
        
    }
}