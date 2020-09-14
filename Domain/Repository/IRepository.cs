using System.Collections.Generic;

namespace DDD.Sales.Domain.Repository
{
    public interface IRepository<T>
        where T: class
    {
        void Create(T entity);
        T Read(int id);
        void Delete(int id);
        IEnumerable<T> Read();
    }
}