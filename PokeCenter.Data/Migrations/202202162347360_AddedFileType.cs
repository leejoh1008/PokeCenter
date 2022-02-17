namespace PokeCenter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFileType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PGame", "FileName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PGame", "FileName");
        }
    }
}
