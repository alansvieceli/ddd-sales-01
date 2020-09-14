using System.Linq;
using DDD.Sales.Application.DAL;
using DDD.Sales.Application.Models;
using Domain.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Migrations.Internal;

namespace Domain.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public LoginController(ApplicationDbContext context, IHttpContextAccessor httpContext)
        {
            this._context = context;
            this._httpContext = httpContext;
        }
        
        public IActionResult Index(int? id)
        {
            ViewData["ErroLogin"] = string.Empty;
            if ((id != null) && (id == 0))
            {
                this._httpContext.HttpContext.Session.Clear();
            }
            return View();
        }
        
        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            ViewData["ErroLogin"] = string.Empty;
            if (ModelState.IsValid)
            {
                var senha = Criptografia.GetMd5Hash(model.Senha);
                var usuario = this._context.Usuario.Where(u => u.Email == model.Email && u.Senha == senha)
                    .FirstOrDefault();

                if (usuario == null)
                {
                    ViewData["ErroLogin"] = "E-mail ou senha são inválidos.";
                    return View(model);
                } else
                {
                    //colocar os dados do usuário na sessão
                    this._httpContext.HttpContext.Session.SetInt32(Sessao.USUARIO_CODIGO, (int) usuario.Codigo);
                    this._httpContext.HttpContext.Session.SetString(Sessao.USUARIO_NOME, usuario.Nome);
                    this._httpContext.HttpContext.Session.SetString(Sessao.USUARIO_EMAIL, usuario.Email);
                    this._httpContext.HttpContext.Session.SetInt32(Sessao.LOGADO, 1);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View(model);
            }
            
        }
    }
}