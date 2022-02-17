namespace PokeCenter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPCardProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PCard", "FileName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PCard", "FileName");
        }
    }
}
