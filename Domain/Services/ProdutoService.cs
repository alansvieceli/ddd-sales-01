using System.Collections.Generic;
using DDD.Sales.Domain.Interfaces;
using DDD.Sales.Domain.Repository;

namespace DDD.Sales.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            this._repository = repository;
        }
        
        public IEnumerable<Entities.Produto> Listagem()
        {
            return this._repository.Read();
        }

        public Entities.Produto CarregarRegistro(int id)
        {
            return this._repository.Read(id);
        }

        public void Cadastrar(Entities.Produto produto)
        {
            this._repository.Create(produto);
        }

        public void Excluir(int id)
        {
            this._repository.Delete(id);
        }

        public decimal GetPrice(int id)
        {
            return this._repository.GetPrice(id);
        }
    }
}