namespace PokeCenter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _byte : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PCard", "CardImage", c => c.Binary(nullable: false));
            AddColumn("dbo.PGame", "GameImage", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PGame", "GameImage");
            DropColumn("dbo.PCard", "CardImage");
        }
    }
}
