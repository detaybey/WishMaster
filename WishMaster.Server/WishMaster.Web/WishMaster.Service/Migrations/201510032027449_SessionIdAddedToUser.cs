namespace WishMaster.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SessionIdAddedToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.User", "SessionId", c => c.String(maxLength: 36));
        }
        
        public override void Down()
        {
            DropColumn("public.User", "SessionId");
        }
    }
}
