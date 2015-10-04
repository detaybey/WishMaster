namespace WishMaster.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CountryCodeAddedToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Product", "CountryCode", c => c.String(maxLength: 2));
        }
        
        public override void Down()
        {
            DropColumn("public.Product", "CountryCode");
        }
    }
}
