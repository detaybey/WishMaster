namespace WishMaster.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApprovedAddedToTransaction : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Transaction", "Approved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("public.Transaction", "Approved");
        }
    }
}
