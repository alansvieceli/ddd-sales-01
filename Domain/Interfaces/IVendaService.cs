using System.Collections.Generic;
using DDD.Sales.Domain.DTO;
using DDD.Sales.Domain.Entities;

namespace DDD.Sales.Domain.Interfaces
{
    public interface IVendaService: ICrudService<Venda>
    {
        IEnumerable<VendaProdutosDto> ListaGrafico();
    }
}