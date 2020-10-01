using System.Collections.Generic;
using DDD.Sales.Domain.Entities;
using DDD.Sales.Domain.Interfaces;
using DDD.Sales.Domain.Repository;
using Infra.Helpers;

namespace DDD.Sales.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            this._repository = repository;
        }
        
        public IEnumerable<Entities.Usuario> Listagem()
        {
            return this._repository.Read();
        }

        public Entities.Usuario CarregarRegistro(int id)
        {
            return this._repository.Read(id);
        }

        public void Cadastrar(Entities.Usuario usuario)
        {
            this._repository.Create(usuario);
        }

        public void Excluir(int id)
        {
            this._repository.Delete(id);
        }

        public Usuario GetLogin(string email, string senha)
        {
            return this._repository.GetLogin(email, Criptografia.GetMd5Hash(senha));
        }
    }
}