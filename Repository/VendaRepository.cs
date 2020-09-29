using System.Collections.Generic;
using System.Linq;
using DDD.Sales.Domain.Entities;
using DDD.Sales.Domain.Repository;
using DDD.Sales.Repository.DAL;
using Microsoft.EntityFrameworkCore;

namespace DDD.Sales.Repository
{
    public class VendaRepository : Repository<Venda>, IVendaRepository
    
    {
        public VendaRepository(ApplicationDbContext context) : base(context)
        {
        }
        
        public new IEnumerable<Venda> Read()
        {
            return base._dbSet.Include( p => p.Cliente).AsNoTracking().ToList();
        }
    }
}