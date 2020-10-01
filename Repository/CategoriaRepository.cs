using DDD.Sales.Domain.Entities;
using DDD.Sales.Domain.Repository;
using DDD.Sales.Repository.DAL;

namespace DDD.Sales.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}