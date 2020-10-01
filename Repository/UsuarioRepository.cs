using System.Linq;
using DDD.Sales.Domain.Entities;
using DDD.Sales.Domain.Repository;
using DDD.Sales.Repository.DAL;

namespace DDD.Sales.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {
            
        }

        public Usuario GetLogin(string email, string senha)
        {
            return base.DbSet.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}