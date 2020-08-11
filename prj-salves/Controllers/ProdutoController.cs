using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using prj_sales.DAL;
using prj_sales.Entities;
using prj_sales.Models;

namespace prj_sales.Controllers
{
    public class ProdutoController : Controller
    {
        
        private readonly ApplicationDbContext _context;
        
        public ProdutoController(ApplicationDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Produto> lista = this._context.Produto.Include(x => x.Categoria).ToList();
            this._context.Dispose();
            return View(lista);
        }
        
        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            ProdutoViewModel viewModel = new ProdutoViewModel();
            viewModel.ListaCategorias = GetListaCategorias();
            if (id != null)
            {
                var entidade = this._context.Produto.Where(x => x.Codigo == id).FirstOrDefault();
                viewModel.Codigo = entidade.Codigo;
                viewModel.Descricao = entidade.Descricao;
                viewModel.Quantidade = entidade.Quantidade;
                viewModel.Valor = entidade.Valor;
                viewModel.CodigoCategoria = entidade.CodigoCategoria;
            }
            
            return View(viewModel);
        }
        
        [HttpPost]
        public IActionResult Cadastro(ProdutoViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                Produto obj = new Produto()
                {
                    Codigo = entidade.Codigo,
                    Descricao = entidade.Descricao,
                    Quantidade = entidade.Quantidade,
                    Valor = entidade.Valor,
                    CodigoCategoria = (int) entidade.CodigoCategoria
                };

                if (entidade.Codigo == null)
                {
                    //this._context.Produto.Add(obj);
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
                entidade.ListaCategorias = GetListaCategorias();
                return View(entidade);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var entidade = this._context.Produto.Where(x => x.Codigo == id).FirstOrDefault();
            this._context.Attach(entidade);
            this._context.Remove(entidade);
            this._context.SaveChanges();
            return RedirectToAction("Index");
        }

        private IEnumerable<SelectListItem> GetListaCategorias()
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            lista.Add(new SelectListItem()
            {
                Value = String.Empty,
                Text = String.Empty
            });

            foreach (var item in this._context.Categoria.ToList())
            {
                lista.Add(new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Descricao
                });
            }

            return lista;
        }
        
    }
}