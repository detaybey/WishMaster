namespace WishMaster.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuantityToOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Order", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("public.Order", "Quantity");
        }
    }
}
