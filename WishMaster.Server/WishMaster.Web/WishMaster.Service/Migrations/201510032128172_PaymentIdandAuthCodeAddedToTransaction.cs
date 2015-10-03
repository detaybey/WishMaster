namespace WishMaster.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentIdandAuthCodeAddedToTransaction : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Transaction", "PaymentId", c => c.String(maxLength: 20));
            AddColumn("public.Transaction", "AuthCode", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("public.Transaction", "AuthCode");
            DropColumn("public.Transaction", "PaymentId");
        }
    }
}
