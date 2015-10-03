namespace WishMaster.Service.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Entities;

    public sealed class Configuration : DbMigrationsConfiguration<WishMaster.Service.Entities.WishMasterDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WishMaster.Service.Entities.WishMasterDataContext context)
        {
            // initial categories
            context.Categories.AddOrUpdate(
              p => p.Name,
              new Category { Name = "Fashion" },
              new Category { Name = "Electronics" },
              new Category { Name = "Home & Garden" },
              new Category { Name = "Toys" },
              new Category { Name = "Kids & Baby" },
              new Category { Name = "Sports" },
              new Category { Name = "Books" },
              new Category { Name = "Music & Games" },
              new Category { Name = "Healty & Beauty" },
              new Category { Name = "Other" }
            );

            context.Users.AddOrUpdate(
                p => p.Nick,
                new User
                {
                    Nick = "system",
                    Email = "genie@wishmaster.com",
                    Password = "x",
                    AddressLine1 = "123 Main Street",
                    AddressLine2 = "",
                    AddressCity = "OFallon",
                    AddressZip = "63368",
                    AddressState = "MO",
                    AddressCountry = "USA"
                }

            );
        }
    }
}
