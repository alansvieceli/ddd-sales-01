using DDD.Sales.Application.Models;
using DDD.Sales.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Sales.Application.Controllers
{
    public class ProdutoController : Controller
    {
        
        private readonly IProdutoAppService _service;
        
        public ProdutoController(IProdutoAppService service)
        {
            this._service = service;
        }
        
        public IActionResult Index()
        {
            return View(this._service.Listagem());
        }
        
        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            return View(this._service.Carregar(id));
        }
        
        [HttpPost]
        public IActionResult Cadastro(ProdutoViewModel view)
        {
            if (ModelState.IsValid)
            {
                this._service.Cadastrar(view);
            }
            else
            {
                return View(view);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            this._service.Excluir(id);
            return RedirectToAction("Index");
        }

        [HttpGet("Produto/ValorUnitario/{id}")]
        public decimal GetValorProduto(int id)
        {
            return this._service.GetPrice(id);
        }
    }
}