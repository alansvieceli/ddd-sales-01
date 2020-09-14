using System.Collections.Generic;
using System.Linq;
using DDD.Sales.Application.DAL;
using DDD.Sales.Application.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Domain.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public ClienteController(ApplicationDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Cliente> lista = this._context.Cliente.ToList();
            this._context.Dispose();
            return View(lista);
        }
        
        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            ClienteViewModel viewModel = new ClienteViewModel();
            if (id != null)
            {
                var entidade = this._context.Cliente.Where(x => x.Codigo == id).FirstOrDefault();
                viewModel.Codigo = entidade.Codigo;
                viewModel.Nome = entidade.Nome;
                viewModel.CNPJ_CPF = entidade.CNPJ_CPF;
                viewModel.Email = entidade.Email;
                viewModel.Telefone = entidade.Telefone;
            }
            return View(viewModel);
        }
        
        [HttpPost]
        public IActionResult Cadastro(ClienteViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                Cliente obj = new Cliente()
                {
                    Codigo = entidade.Codigo,
                    Nome = entidade.Nome,
                    CNPJ_CPF = entidade.CNPJ_CPF,
                    Email = entidade.Email,
                    Telefone = entidade.Telefone
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
            var entidade = this._context.Cliente.Where(x => x.Codigo == id).FirstOrDefault();
            this._context.Attach(entidade);
            this._context.Remove(entidade);
            this._context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}