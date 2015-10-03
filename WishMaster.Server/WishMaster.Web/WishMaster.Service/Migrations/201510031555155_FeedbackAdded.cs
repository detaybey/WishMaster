namespace WishMaster.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FeedbackAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Feedback",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        StarCount = c.Short(nullable: false),
                        Comment = c.String(),
                        UserId = c.Long(nullable: false),
                        OrderId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Order", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("public.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.Feedback", "UserId", "public.User");
            DropForeignKey("public.Feedback", "OrderId", "public.Order");
            DropIndex("public.Feedback", new[] { "UserId" });
            DropIndex("public.Feedback", new[] { "OrderId" });
            DropTable("public.Feedback");
        }
    }
}
