using System.Collections.Generic;
using DDD.Sales.Domain.Entities;

namespace DDD.Sales.Domain.Interfaces
{
    public interface ICategoriaService
    {
        IEnumerable<Categoria> Listagem();
        Categoria CarregarRegistro(int id);
        void Cadastrar(Categoria categoria);
        void Excluir(int id);
    }
}