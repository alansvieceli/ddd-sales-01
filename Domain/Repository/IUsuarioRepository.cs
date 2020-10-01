using DDD.Sales.Domain.DTO;
using DDD.Sales.Domain.Entities;

namespace DDD.Sales.Domain.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario GetLogin(string email, string senha);
    }
}