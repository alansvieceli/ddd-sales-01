using DDD.Sales.Domain.Entities;

namespace DDD.Sales.Domain.Interfaces
{
    public interface IUsuarioService: ICrudService<Usuario>
    {
        Usuario GetLogin(string email, string senha);
    }
}