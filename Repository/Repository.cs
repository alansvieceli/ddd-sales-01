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
        protected readonly DbContext Context;
        protected readonly DbSet<T> DbSet;

        public Repository(DbContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }
        
        public virtual void Create(T entity)
        {
            if (entity.Codigo == null)
            {
                this.DbSet.Add(entity);
            }
            else
            {
                this.Context.Entry(entity).State = EntityState.Modified;
            }
            this.Context.SaveChanges();
        }

        public virtual T Read(int id)
        {
            return this.DbSet.FirstOrDefault(x => x.Codigo == id);
        }

        public virtual void Delete(int id)
        {
            var entidade = this.DbSet.FirstOrDefault(x => x.Codigo == id);
            if (entidade != null) {
                this.DbSet.Attach(entidade);
                this.DbSet.Remove(entidade);
                this.Context.SaveChanges();
            }
        }

        public virtual IEnumerable<T> Read()
        {
            return this.DbSet.AsNoTracking().ToList();
        }
    }
}