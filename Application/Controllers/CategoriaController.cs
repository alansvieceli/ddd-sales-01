using DDD.Sales.Application.Models;
using DDD.Sales.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Sales.Application.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaAppService _service;

        public CategoriaController(ICategoriaAppService service)
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
        public IActionResult Cadastro(CategoriaViewModel view)
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
        
    }
    
}