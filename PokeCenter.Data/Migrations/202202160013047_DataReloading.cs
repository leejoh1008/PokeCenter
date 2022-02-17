namespace PokeCenter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataReloading : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Message", "Receiver", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Message", "Receiver");
            AddForeignKey("dbo.Message", "Receiver", "dbo.ApplicationUser", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Message", "Receiver", "dbo.ApplicationUser");
            DropIndex("dbo.Message", new[] { "Receiver" });
            AlterColumn("dbo.Message", "Receiver", c => c.String(nullable: false));
        }
    }
}
