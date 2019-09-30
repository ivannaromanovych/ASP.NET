namespace ConsoleApp1.Entities
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EFContext : DbContext
    {
        public EFContext() : base("ZipCode")
        {
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}