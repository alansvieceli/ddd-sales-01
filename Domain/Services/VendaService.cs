using System.Collections.Generic;
using DDD.Sales.Domain.DTO;
using DDD.Sales.Domain.Interfaces;
using DDD.Sales.Domain.Repository;

namespace DDD.Sales.Domain.Services
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _repository;
        private readonly IVendaProdutosRepository _repositoryVendaProdutos;

        public VendaService(IVendaRepository repository, IVendaProdutosRepository repositoryVendaProdutos)
        {
            this._repository = repository;
            this._repositoryVendaProdutos = repositoryVendaProdutos;
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

        public IEnumerable<VendaProdutosDto> ListaGrafico()
        {
            return this._repositoryVendaProdutos.ListaGrafico();
        }
    }
}