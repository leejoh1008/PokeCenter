namespace PokeCenter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessageUpdtee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Message", "Title", c => c.String(nullable: false));
            AddColumn("dbo.Message", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Message", "Email");
            DropColumn("dbo.Message", "Title");
        }
    }
}
