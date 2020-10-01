using DDD.Sales.Application.Services.Interfaces;
using DDD.Sales.Domain.Interfaces;
using Infra.Helpers;
using Microsoft.AspNetCore.Http;

namespace DDD.Sales.Application.Services
{
    public class UsuarioAppService: IUsuarioAppService
    {
        private readonly IUsuarioService _service;
        private readonly IHttpContextAccessor _httpContext;
        
        public UsuarioAppService(IUsuarioService service, IHttpContextAccessor httpContext)
        {
            this._service = service;
            this._httpContext = httpContext;
        }

        public void VerificarLogin(int? id)
        {
            if ((id != null) && (id == 0))
            {
                this._httpContext.HttpContext.Session.Clear();
            }
        }
        
        public bool ValidarLogin(string email, string senha)
        {
            var usuario = this._service.GetLogin(email, senha);
            if (usuario != null)
            {
                //colocar os dados do usuário na sessão
                this._httpContext.HttpContext.Session.SetInt32(Sessao.USUARIO_CODIGO, (int) usuario.Codigo);
                this._httpContext.HttpContext.Session.SetString(Sessao.USUARIO_NOME, usuario.Nome);
                this._httpContext.HttpContext.Session.SetString(Sessao.USUARIO_EMAIL, usuario.Email);
                this._httpContext.HttpContext.Session.SetInt32(Sessao.LOGADO, 1);
                return true;
            }
            
            return false;
        }
    }
}