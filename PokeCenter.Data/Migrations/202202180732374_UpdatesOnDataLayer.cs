namespace PokeCenter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatesOnDataLayer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PGame", "FileContent", c => c.Binary(nullable: false));
            DropColumn("dbo.PGame", "GameImage");
            DropColumn("dbo.PGame", "FileName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PGame", "FileName", c => c.String(nullable: false));
            AddColumn("dbo.PGame", "GameImage", c => c.Binary(nullable: false));
            DropColumn("dbo.PGame", "FileContent");
        }
    }
}
