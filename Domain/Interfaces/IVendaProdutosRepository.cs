using System.Collections.Generic;
using DDD.Sales.Domain.DTO;

namespace DDD.Sales.Domain.Interfaces
{
    public interface IVendaProdutosRepository
    {
        IEnumerable<VendaProdutosDto> ListaGrafico();
    }
}