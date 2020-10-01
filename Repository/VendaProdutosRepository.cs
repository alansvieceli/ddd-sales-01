using System.Collections.Generic;
using System.Linq;
using DDD.Sales.Domain.DTO;
using DDD.Sales.Domain.Interfaces;
using DDD.Sales.Repository.DAL;
using Microsoft.EntityFrameworkCore;

namespace DDD.Sales.Repository
{
    public class VendaProdutosRepository: DbContext, IVendaProdutosRepository
    {
        private readonly ApplicationDbContext _context;
        
        public VendaProdutosRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<VendaProdutosDto> ListaGrafico()
        {
            return this._context.VendaProdutos
                .Include(vp => vp.Produto)
                .AsEnumerable()
                .GroupBy(vp => vp.CodigoProduto)
                .Select(grp => new VendaProdutosDto 
                {
                    CodigoProduto = grp.First().CodigoProduto,
                    Descricao = grp.First().Produto.Descricao,
                    TotalVendido = grp.Sum( z => z.Quantidade)
                    
                }).ToList();
        }
    }
}