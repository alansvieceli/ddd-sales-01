using System.Collections.Generic;
using DDD.Sales.Domain.Entities;
using DDD.Sales.Domain.Interfaces;
using DDD.Sales.Domain.Repository;

namespace DDD.Sales.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            this._repository = repository;
        }
        
        public IEnumerable<Cliente> Listagem()
        {
            return this._repository.Read();
        }

        public Cliente CarregarRegistro(int id)
        {
            return this._repository.Read(id);
        }

        public void Cadastrar(Cliente cliente)
        {
            this._repository.Create(cliente);
        }

        public void Excluir(int id)
        {
            this._repository.Delete(id);
        }
    }
}