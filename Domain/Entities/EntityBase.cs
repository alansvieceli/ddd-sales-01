using System.ComponentModel.DataAnnotations;

namespace DDD.Sales.Domain.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public int?  Codigo { get; set; }
    }
}