using System.Collections.Generic;
using System.Linq;
using DDD.Sales.Domain.Entities;
using DDD.Sales.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace DDD.Sales.Repository
{
    public abstract class Repository<T> : DbContext, IRepository<T>
        where T: class, new()
    {
        DbContext _context;
        DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            this._context = context;
            this._dbSet = this._context.Set<T>();
        }
        
        public void Create(T entity)
        {
            throw new System.NotImplementedException();
        }

        public T Read(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> Read()
        {
            //return this._dbSet.ToList();
            return this._dbSet.ToList();
        }
    }
}