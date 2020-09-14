using System;
using System.Collections.Generic;
using System.Linq;
using DDD.Sales.Application.DAL;
using DDD.Sales.Application.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Domain.Controllers
{
    public class VendaController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public VendaController(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Venda> lista = this._context.Venda.Include( x => x.Cliente).ToList();
            this._context.Dispose();
            return View(lista);
        }
        
        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            VendaViewModel viewModel = new VendaViewModel();
            viewModel.ListaClientes = GetListaClientes();
            viewModel.ListaProdutos = GetListaProdutos();
            if (id != null)
            {
                var entidade = this._context.Venda.Where(x => x.Codigo == id).FirstOrDefault();
                viewModel.Codigo = entidade.Codigo;
                viewModel.Data = entidade.Data;
                viewModel.Total = entidade.Total;
                viewModel.CodigoCliente = entidade.CodigoCliente;
            }
            
            return View(viewModel);
        }
        
        [HttpPost]
        public IActionResult Cadastro(VendaViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                Venda obj = new Venda()
                {
                    Codigo = entidade.Codigo,
                    Data = (DateTime) entidade.Data,
                    Total = entidade.Total,
                    CodigoCliente = (int) entidade.CodigoCliente,
                    Produtos = JsonConvert.DeserializeObject<ICollection<VendaProdutos>>(entidade.JsonProdutos)
                };

                if (entidade.Codigo == null)
                {
                    //this._context.Venda.Add(obj);
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
                entidade.ListaClientes = GetListaClientes();
                entidade.ListaProdutos = GetListaProdutos();
                return View(entidade);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var entidade = this._context.Venda.Where(x => x.Codigo == id).FirstOrDefault();
            this._context.Attach(entidade);
            this._context.Remove(entidade);
            this._context.SaveChanges();
            return RedirectToAction("Index");
        }

        private IEnumerable<SelectListItem> GetListaProdutos()
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            lista.Add(new SelectListItem()
            {
                Value = String.Empty,
                Text = String.Empty
            });

            foreach (var item in this._context.Produto.ToList())
            {
                lista.Add(new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Descricao
                });
            }

            return lista;
        }
        
        private IEnumerable<SelectListItem> GetListaClientes()
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            lista.Add(new SelectListItem()
            {
                Value = String.Empty,
                Text = String.Empty
            });

            foreach (var item in this._context.Cliente.ToList())
            {
                lista.Add(new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Nome
                });
            }

            return lista;
        }
        
    }
}