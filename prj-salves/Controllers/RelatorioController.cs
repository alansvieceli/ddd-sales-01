using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prj_sales.DAL;
using prj_sales.Models;

namespace prj_sales.Controllers
{
    public class RelatorioController : Controller
    {
        
        private readonly ApplicationDbContext _context;
        
        public RelatorioController(ApplicationDbContext context)
        {
            this._context = context;
        }
        
        public IActionResult Grafico()
        {

            var lista = this._context.VendaProdutos
                .Include(vp => vp.Produto)
                .AsEnumerable()
                .GroupBy(vp => vp.CodigoProduto)
                .Select(grp => new 
                {
                    CodigoProduto = grp.First().CodigoProduto,
                    Descricao = grp.First().Produto.Descricao,
                    TotalVendido = grp.Sum( z => z.Quantidade)
                    
                }).ToList();

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
            
            return View(lista);
        }
    }
}