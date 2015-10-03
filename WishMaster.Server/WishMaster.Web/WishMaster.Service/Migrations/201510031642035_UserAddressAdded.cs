namespace WishMaster.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAddressAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.User", "AddressLine1", c => c.String(maxLength: 50));
            AddColumn("public.User", "AddressLine2", c => c.String(maxLength: 50));
            AddColumn("public.User", "AddressCity", c => c.String(maxLength: 25));
            AddColumn("public.User", "AddressZip", c => c.String(maxLength: 10));
            AddColumn("public.User", "AddressCountry", c => c.String(maxLength: 3));
        }
        
        public override void Down()
        {
            DropColumn("public.User", "AddressCountry");
            DropColumn("public.User", "AddressZip");
            DropColumn("public.User", "AddressCity");
            DropColumn("public.User", "AddressLine2");
            DropColumn("public.User", "AddressLine1");
        }
    }
}
