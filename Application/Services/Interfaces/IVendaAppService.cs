using System.Collections.Generic;
using DDD.Sales.Application.Models;
using DDD.Sales.Domain.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DDD.Sales.Application.Services.Interfaces
{
    public interface IVendaAppService
    {
        IEnumerable<VendaViewModel> Listagem();

        VendaViewModel Carregar(int? id);
        
        void Cadastrar(VendaViewModel entidade);

        public void Excluir(int id);

        IEnumerable<SelectListItem> GetListaProdutos();

        IEnumerable<SelectListItem> GetListaClientes();
        
        IEnumerable<VendaProdutosDto> ListaGrafico();
    }
}