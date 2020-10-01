using DDD.Sales.Application.Models;
using DDD.Sales.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Sales.Application.Controllers
{
    public class VendaController : Controller
    {
        private readonly IVendaAppService _service;
        
        public VendaController(IVendaAppService service)
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
            var view = new VendaViewModel();
            if (id != null) {
                return View(this._service.Carregar(id));
            }

            view.ListaClientes = this._service.GetListaClientes();
            view.ListaProdutos = this._service.GetListaProdutos();
            return View(view);
            
        }
        
        [HttpPost]
        public IActionResult Cadastro(VendaViewModel view)
        {
            
            if (ModelState.IsValid)
            {
                this._service.Cadastrar(view);
            }
            else
            {
                view.ListaClientes = this._service.GetListaClientes();
                view.ListaProdutos = this._service.GetListaProdutos();
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