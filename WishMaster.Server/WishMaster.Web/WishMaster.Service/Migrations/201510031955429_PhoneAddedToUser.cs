namespace WishMaster.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhoneAddedToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.User", "Phone", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("public.User", "Phone");
        }
    }
}
