namespace WishMaster.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAddressStateAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.User", "AddressState", c => c.String(maxLength: 2));
        }
        
        public override void Down()
        {
            DropColumn("public.User", "AddressState");
        }
    }
}
