namespace _11_09_2019.Entities
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EFContext : DbContext
    {
        public EFContext()
            : base("name=Users")
        {
        }
        public DbSet<User> Users { get; set; }
    }
}