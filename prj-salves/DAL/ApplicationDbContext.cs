using Microsoft.EntityFrameworkCore;
using prj_sales.Entities;

namespace prj_sales.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<VendaProdutos> VendaProdutos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VendaProdutos>()
                .HasKey(vp => new {vp.CodigoVenda, vp.CodigoProduto});

            modelBuilder.Entity<VendaProdutos>()
                .HasOne(x => x.Venda)
                .WithMany(x => x.Produtos)
                .HasForeignKey( x => x.CodigoVenda);
            
            modelBuilder.Entity<VendaProdutos>()
                .HasOne(x => x.Produto)
                .WithMany(x => x.Vendas)
                .HasForeignKey( x => x.CodigoProduto);

        }
    }
}