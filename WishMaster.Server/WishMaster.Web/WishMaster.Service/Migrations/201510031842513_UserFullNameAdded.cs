namespace WishMaster.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserFullNameAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.User", "FullName", c => c.String(maxLength: 60));
        }
        
        public override void Down()
        {
            DropColumn("public.User", "FullName");
        }
    }
}
