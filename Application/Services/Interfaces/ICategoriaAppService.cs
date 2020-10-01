using System.Collections.Generic;
using DDD.Sales.Application.Models;

namespace DDD.Sales.Application.Services.Interfaces
{
    public interface ICategoriaAppService
    {
        IEnumerable<CategoriaViewModel> Listagem();

        CategoriaViewModel Carregar(int? id);
        
        void Cadastrar(CategoriaViewModel entidade);

        public void Excluir(int id);
    }
}