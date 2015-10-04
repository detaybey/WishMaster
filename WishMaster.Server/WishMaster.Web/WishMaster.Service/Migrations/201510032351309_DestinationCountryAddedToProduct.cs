namespace WishMaster.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DestinationCountryAddedToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Product", "DestinationCountry", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("public.Product", "DestinationCountry");
        }
    }
}
