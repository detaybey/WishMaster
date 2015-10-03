namespace WishMaster.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AcceptorInfoAddedToCard : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Card", "AcceptorName", c => c.String(maxLength: 22));
            AddColumn("public.Card", "AcceptorCity", c => c.String(maxLength: 13));
            AddColumn("public.Card", "AcceptorState", c => c.String(maxLength: 2));
            AddColumn("public.Card", "AcceptorPostalCode", c => c.String(maxLength: 10));
            AddColumn("public.Card", "AcceptorCountry", c => c.String(maxLength: 3));
        }
        
        public override void Down()
        {
            DropColumn("public.Card", "AcceptorCountry");
            DropColumn("public.Card", "AcceptorPostalCode");
            DropColumn("public.Card", "AcceptorState");
            DropColumn("public.Card", "AcceptorCity");
            DropColumn("public.Card", "AcceptorName");
        }
    }
}
