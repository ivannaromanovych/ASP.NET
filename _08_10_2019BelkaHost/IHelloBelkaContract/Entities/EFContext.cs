namespace IHelloBelkaContract.Entities
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EFContext : DbContext
    {
        public EFContext()
            : base("EFContext")
        {
        }
        public DbSet<User> users { get; set; }
    }

}