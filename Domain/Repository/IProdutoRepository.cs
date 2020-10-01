using System.Collections.Generic;
using DDD.Sales.Domain.Entities;

namespace DDD.Sales.Domain.Repository
{
    public interface IProdutoRepository : IRepository<Produto>
    {
         new IEnumerable<Produto> Read();

         decimal GetPrice(int id);

    }
}