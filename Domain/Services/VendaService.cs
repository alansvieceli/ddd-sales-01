using System.Collections.Generic;
using DDD.Sales.Domain.Interfaces;
using DDD.Sales.Domain.Repository;

namespace DDD.Sales.Domain.Services
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _repository;

        public VendaService(IVendaRepository repository)
        {
            this._repository = repository;
        }
        
        public IEnumerable<Entities.Venda> Listagem()
        {
            return this._repository.Read();
        }

        public Entities.Venda CarregarRegistro(int id)
        {
            return this._repository.Read(id);
        }

        public void Cadastrar(Entities.Venda cliente)
        {
            this._repository.Create(cliente);
        }

        public void Excluir(int id)
        {
            this._repository.Delete(id);
        }
    }
}