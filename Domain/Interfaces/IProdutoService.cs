using DDD.Sales.Domain.Entities;

namespace DDD.Sales.Domain.Interfaces
{
    public interface IProdutoService: ICrudService<Produto>
    {
        decimal GetPrice(int id);
    }
}