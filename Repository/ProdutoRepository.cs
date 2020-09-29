using System.Collections.Generic;
using System.Linq;
using DDD.Sales.Domain.Entities;
using DDD.Sales.Domain.Repository;
using DDD.Sales.Repository.DAL;
using Microsoft.EntityFrameworkCore;

namespace DDD.Sales.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    
    {
        public ProdutoRepository(ApplicationDbContext context) : base(context)
        {
        }
        
        public new IEnumerable<Produto> Read()
        {
            return base._dbSet.Include( p => p.Categoria).AsNoTracking().ToList();
        }

        public decimal GetPrice(int id)
        {
            return base._dbSet.Where(x => x.Codigo == id).Select(x => x.Valor).FirstOrDefault();
        }
    }
}