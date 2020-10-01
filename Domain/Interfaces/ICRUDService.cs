using System.Collections.Generic;
using DDD.Sales.Domain.Entities;

namespace DDD.Sales.Domain.Interfaces
{
    public interface ICrudService<T>
        where T : EntityBase

    {
        IEnumerable<T> Listagem();
        T CarregarRegistro(int id);
        void Cadastrar(T categoria);
        void Excluir(int id);
    }
}