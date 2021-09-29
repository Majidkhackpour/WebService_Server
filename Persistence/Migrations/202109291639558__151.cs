namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _151 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buildings_Building", "WhatsAppCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buildings_Building", "WhatsAppCount");
        }
    }
}
