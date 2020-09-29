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

    }
}