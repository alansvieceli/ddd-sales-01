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
            /*
            CategoriaViewModel viewModel = new CategoriaViewModel();
            if (id != null)
            {
                var entidade = this._context.Categoria.Where(x => x.Codigo == id).FirstOrDefault();
                viewModel.Codigo = entidade.Codigo;
                viewModel.Descricao = entidade.Descricao;
            }
            */
            return View(new CategoriaViewModel());
        }
/*
        [HttpPost]
        public IActionResult Cadastro(CategoriaViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                Categoria obj = new Categoria()
                {
                    Codigo = entidade.Codigo,
                    Descricao = entidade.Descricao
                };

                if (entidade.Codigo == null)
                {
                    this._context.Add(obj);
                }
                else
                {
                    this._context.Entry(obj).State = EntityState.Modified;
                }

                this._context.SaveChanges();
            }
            else
            {
                return View(entidade);
            }

            return RedirectToAction("Index");
        }
*/
        [HttpGet]
        public IActionResult Excluir(int id)
        {
            /*
            var entidade = this._context.Categoria.Where(x => x.Codigo == id).FirstOrDefault();
            this._context.Attach(entidade);
            this._context.Remove(entidade);
            this._context.SaveChanges();
            */
            return RedirectToAction("Index");
        }
        
    }
    
}