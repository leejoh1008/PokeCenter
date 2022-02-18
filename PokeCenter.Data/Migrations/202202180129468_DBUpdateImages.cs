namespace PokeCenter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBUpdateImages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PCard", "FileContent", c => c.Binary());
            DropColumn("dbo.PCard", "CardImage");
            DropColumn("dbo.PCard", "FileName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PCard", "FileName", c => c.String(nullable: false));
            AddColumn("dbo.PCard", "CardImage", c => c.Binary(nullable: false));
            DropColumn("dbo.PCard", "FileContent");
        }
    }
}
