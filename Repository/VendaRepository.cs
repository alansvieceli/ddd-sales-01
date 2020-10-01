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
            return base.DbSet.Include( p => p.Cliente).AsNoTracking().ToList();
        }

        public override void Delete(int id)
        {
            //excluir no VendaProdutos
            var listaProdutos = this.DbSet
                .Include(v => v.Produtos)
                .Where(y => y.Codigo == id)
                .AsNoTracking()
                .ToList();

            foreach (var produto in listaProdutos)
            {
                 VendaProdutos vp = new VendaProdutos()
                {
                    CodigoVenda = id,
                    CodigoProduto = (int) produto.Codigo
                };
                var dbSetVp = this.Context.Set<VendaProdutos>();
                dbSetVp.Attach(vp);
                dbSetVp.Remove(vp);
                this.Context.SaveChanges();
            }
            
            //excluir a venda
            base.Delete(id);
        }
    }
}