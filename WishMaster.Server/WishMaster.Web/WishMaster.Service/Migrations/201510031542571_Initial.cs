namespace WishMaster.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Card",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        OwnerId = c.Long(nullable: false),
                        Number = c.String(maxLength: 20),
                        ExpMonth = c.String(maxLength: 2),
                        ExpYear = c.String(maxLength: 4),
                        CCV = c.String(maxLength: 3),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.User", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "public.FraudLog",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Score = c.Int(nullable: false),
                        CardId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Card", t => t.CardId, cascadeDelete: true)
                .Index(t => t.CardId);
            
            CreateTable(
                "public.User",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Email = c.String(maxLength: 50),
                        Nick = c.String(maxLength: 20),
                        Password = c.String(maxLength: 14),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.Order",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Created = c.DateTime(nullable: false),
                        SellerId = c.Long(nullable: false),
                        CustomerId = c.Long(nullable: false),
                        ProductId = c.Long(nullable: false),
                        State = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.User", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("public.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("public.User", t => t.SellerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ProductId)
                .Index(t => t.SellerId);
            
            CreateTable(
                "public.Product",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Desc = c.String(maxLength: 255),
                        UsdPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryId = c.Long(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        EarliestShipDate = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        SellerId = c.Long(nullable: false),
                        Lat = c.Single(nullable: false),
                        Lng = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("public.User", t => t.SellerId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.SellerId);
            
            CreateTable(
                "public.Category",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.Transaction",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Hash = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        OrderId = c.Long(nullable: false),
                        CardId = c.Long(nullable: false),
                        UsdAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Order", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("public.Card", t => t.CardId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.CardId);
            
            CreateTable(
                "public.Score",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        UserId = c.Long(nullable: false),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.Transaction", "CardId", "public.Card");
            DropForeignKey("public.Score", "UserId", "public.User");
            DropForeignKey("public.Product", "SellerId", "public.User");
            DropForeignKey("public.Order", "SellerId", "public.User");
            DropForeignKey("public.Transaction", "OrderId", "public.Order");
            DropForeignKey("public.Order", "ProductId", "public.Product");
            DropForeignKey("public.Product", "CategoryId", "public.Category");
            DropForeignKey("public.Order", "CustomerId", "public.User");
            DropForeignKey("public.Card", "OwnerId", "public.User");
            DropForeignKey("public.FraudLog", "CardId", "public.Card");
            DropIndex("public.Transaction", new[] { "CardId" });
            DropIndex("public.Score", new[] { "UserId" });
            DropIndex("public.Product", new[] { "SellerId" });
            DropIndex("public.Order", new[] { "SellerId" });
            DropIndex("public.Transaction", new[] { "OrderId" });
            DropIndex("public.Order", new[] { "ProductId" });
            DropIndex("public.Product", new[] { "CategoryId" });
            DropIndex("public.Order", new[] { "CustomerId" });
            DropIndex("public.Card", new[] { "OwnerId" });
            DropIndex("public.FraudLog", new[] { "CardId" });
            DropTable("public.Score");
            DropTable("public.Transaction");
            DropTable("public.Category");
            DropTable("public.Product");
            DropTable("public.Order");
            DropTable("public.User");
            DropTable("public.FraudLog");
            DropTable("public.Card");
        }
    }
}
