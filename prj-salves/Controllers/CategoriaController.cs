using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prj_sales.DAL;
using prj_sales.Entities;
using prj_sales.Models;

namespace prj_sales.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriaController(ApplicationDbContext context)
        {
            this._context = context;
        }
        
        public IActionResult Index()
        {
            IEnumerable<Categoria> lista = this._context.Categoria.ToList();
            this._context.Dispose();
            return View(lista);
        }
        
        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            CategoriaViewModel viewModel = new CategoriaViewModel();
            if (id != null)
            {
                var entidade = this._context.Categoria.Where(x => x.Codigo == id).FirstOrDefault();
                viewModel.Codigo = entidade.Codigo;
                viewModel.Descricao = entidade.Descricao;
            }
            return View(viewModel);
        }

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

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var entidade = this._context.Categoria.Where(x => x.Codigo == id).FirstOrDefault();
            this._context.Attach(entidade);
            this._context.Remove(entidade);
            this._context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}