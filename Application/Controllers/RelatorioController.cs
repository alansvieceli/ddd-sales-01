using System;
using DDD.Sales.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Sales.Application.Controllers
{
    public class RelatorioController : Controller
    {
        
        private readonly IVendaAppService _service;
        
        public RelatorioController(IVendaAppService service)
        {
            this._service = service;
        }
        
        public IActionResult Grafico()
        {
            var lista = this._service.ListaGrafico();

            string valores = string.Empty;
            string labels = string.Empty;
            string cores = string.Empty;
            var random = new Random();

            foreach (var item in lista)
            {
                valores += item.TotalVendido.ToString() + ",";
                labels += "'" + item.Descricao + "',";
                cores += "'" + String.Format("#{0:X6}", random.Next(0x1000000)) + "',";
            }

            ViewBag.Valores = valores;
            ViewBag.Labels = labels;
            ViewBag.Cores = cores;
            
            return View(null);
        }
    }
}