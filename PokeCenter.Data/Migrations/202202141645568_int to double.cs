namespace PokeCenter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inttodouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PCard", "CardPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.PGame", "GamePrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PGame", "GamePrice", c => c.Int(nullable: false));
            AlterColumn("dbo.PCard", "CardPrice", c => c.Int(nullable: false));
        }
    }
}
