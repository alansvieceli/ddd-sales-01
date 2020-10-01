using System.Collections.Generic;
using DDD.Sales.Domain.Interfaces;
using DDD.Sales.Domain.Repository;

namespace DDD.Sales.Domain.Services
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
            return this._repository.Read(id);
        }

        public void Cadastrar(Entities.Categoria categoria)
        {
            this._repository.Create(categoria);
        }

        public void Excluir(int id)
        {
            this._repository.Delete(id);
        }
    }
}