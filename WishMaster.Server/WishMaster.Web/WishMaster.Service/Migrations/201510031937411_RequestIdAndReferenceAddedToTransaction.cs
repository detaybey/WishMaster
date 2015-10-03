namespace WishMaster.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequestIdAndReferenceAddedToTransaction : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Transaction", "RequestId", c => c.Int());
            AddColumn("public.Transaction", "TransactionReference", c => c.Long());
        }
        
        public override void Down()
        {
            DropColumn("public.Transaction", "TransactionReference");
            DropColumn("public.Transaction", "RequestId");
        }
    }
}
