using System.Collections.Generic;
using System.Linq;
using DDD.Sales.Domain.Entities;
using DDD.Sales.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace DDD.Sales.Repository
{
    public abstract class Repository<T> : DbContext, IRepository<T>
        where T: EntityBase, new()
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
            if (entity.Codigo == null)
            {
                this._dbSet.Add(entity);
            }
            else
            {
                this._context.Entry(entity).State = EntityState.Modified;
            }
            this._context.SaveChanges();
        }

        public T Read(int id)
        {
            return this._dbSet.FirstOrDefault(x => x.Codigo == id);
        }

        public void Delete(int id)
        {
            var entidade = this._dbSet.FirstOrDefault(x => x.Codigo == id);
            if (entidade != null) {
                this._dbSet.Attach(entidade);
                this._dbSet.Remove(entidade);
                this._context.SaveChanges();
            }
        }

        public IEnumerable<T> Read()
        {
            return this._dbSet.AsNoTracking().ToList();
        }
    }
}