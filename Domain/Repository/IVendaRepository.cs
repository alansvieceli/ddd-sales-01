using System.Collections.Generic;
using DDD.Sales.Domain.Entities;

namespace DDD.Sales.Domain.Repository
{
    public interface IVendaRepository : IRepository<Venda>
    {
        new IEnumerable<Venda> Read();

        new void Delete(int id);
    }
}