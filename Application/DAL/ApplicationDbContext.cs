using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDD.Sales.Application.DAL
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<VendaProdutos> VendaProdutos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Produto>()
                .Property(p => p.Valor)
                .HasColumnType("decimal(9,2)");
            
            modelBuilder.Entity<Venda>()
                .Property(p => p.Total)
                .HasColumnType("decimal(9,2)");

            modelBuilder.Entity<VendaProdutos>()
                .HasKey(vp => new {vp.CodigoVenda, vp.CodigoProduto});

            modelBuilder.Entity<VendaProdutos>()
                .HasOne(x => x.Venda)
                .WithMany(x => x.Produtos)
                .HasForeignKey( x => x.CodigoVenda);

            modelBuilder.Entity<VendaProdutos>()
                .HasOne(x => x.Produto)
                .WithMany(x => x.Vendas)
                .HasForeignKey(x => x.CodigoProduto);
            
            modelBuilder.Entity<VendaProdutos>()
                .Property(p => p.ValorTotal)
                .HasColumnType("decimal(9,2)");
            
            modelBuilder.Entity<VendaProdutos>()
                .Property(p => p.ValorUnitario)
                .HasColumnType("decimal(9,2)");

        }
    }
}