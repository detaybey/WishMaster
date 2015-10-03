namespace WishMaster.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FraudLogsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.StolenLog",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Flag = c.String(maxLength: 1),
                        FlagDesc = c.String(maxLength: 10),
                        CardId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Card", t => t.CardId, cascadeDelete: true)
                .Index(t => t.CardId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.StolenLog", "CardId", "public.Card");
            DropIndex("public.StolenLog", new[] { "CardId" });
            DropTable("public.StolenLog");
        }
    }
}
