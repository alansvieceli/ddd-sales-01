using System.Collections.Generic;
using DDD.Sales.Domain.Interfaces;
using DDD.Sales.Domain.Repository;

namespace DDD.Sales.Domain.Services.Categoria
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository)
        {
            this._repository = repository;
        }
        
        public IEnumerable<Entities.Categoria> Listagem()
        {
            return this._repository.Read();
        }

        public Entities.Categoria CarregarRegistro(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Cadastrar(Entities.Categoria categoria)
        {
            throw new System.NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}