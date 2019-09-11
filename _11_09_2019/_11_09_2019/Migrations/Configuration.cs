namespace _11_09_2019.Migrations
{
    using _11_09_2019.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_11_09_2019.Entities.EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(_11_09_2019.Entities.EFContext context)
        {
            for (int i = 1; i <= 5; i++)
            {
                context.Users.AddOrUpdate(t => t.Id,
                    new User()
                    {
                        Name = "user " + i,
                        Email = "ivankaromanovych12@gmail.com"
                    });
            }
        }
    }
}
