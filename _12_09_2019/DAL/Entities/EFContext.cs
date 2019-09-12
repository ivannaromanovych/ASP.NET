namespace DAL.Entities
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EFContext : DbContext
    {
        public EFContext() : base("DogConnection")
        {
        }
        public DbSet<Dog> Dogs { get; set; }
    }
}