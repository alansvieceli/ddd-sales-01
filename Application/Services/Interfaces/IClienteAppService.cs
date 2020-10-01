using System.Collections.Generic;
using DDD.Sales.Application.Models;

namespace DDD.Sales.Application.Services.Interfaces
{
    public interface IClienteAppService
    {
        IEnumerable<ClienteViewModel> Listagem();

        ClienteViewModel Carregar(int? id);
        
        void Cadastrar(ClienteViewModel entidade);

        public void Excluir(int id);
    }
}