using System.Collections.Generic;
using DDD.Sales.Application.Models;

namespace DDD.Sales.Application.Services.Interfaces
{
    public interface IProdutoAppService
    {
        IEnumerable<ProdutoViewModel> Listagem();

        ProdutoViewModel Carregar(int? id);
        
        void Cadastrar(ProdutoViewModel entidade);

        public void Excluir(int id);

        decimal GetPrice(int id);
    }
}