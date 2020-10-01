using DDD.Sales.Application.Models;
using DDD.Sales.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Sales.Application.Controllers
{
    public class                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               LoginController : Controller
    {
        private readonly IUsuarioAppService _service;

        public LoginController(IUsuarioAppService service)
        {
            this._service = service;
        }
        
        public IActionResult Index(int? id)
        {
            ViewData["ErroLogin"] = string.Empty;
            this._service.VerificarLogin(id);
            return View();
        }
        
        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            ViewData["ErroLogin"] = string.Empty;
            if (ModelState.IsValid)
            {
                if (this._service.ValidarLogin(model.Email, model.Senha))
                {
                    return RedirectToAction("Index", "Home");
                }
                
                ViewData["ErroLogin"] = "E-mail ou senha são inválidos.";
                return View(model);
            }
            else
            {
                return View(model);
            }
        }
    }
}