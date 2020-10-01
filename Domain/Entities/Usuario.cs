using System;
using System.ComponentModel.DataAnnotations;

namespace DDD.Sales.Domain.Entities
{
    public class Usuario : EntityBase
    {
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }
    }
}