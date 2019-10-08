namespace IHelloBelkaContract.Entities
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EFContext : DbContext
    {
        public EFContext()
            : base("name=EFContext")
        {
        }
        public DbSet<User> users { get; set; }
    }

}