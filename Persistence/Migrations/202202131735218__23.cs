namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _23 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Buildings_BuildingNote", "ServerStatus");
            DropColumn("dbo.Buildings_BuildingNote", "ServerDeliveryDate");
            DropColumn("dbo.Buildings_BuildingRequestRegions", "ServerStatus");
            DropColumn("dbo.Buildings_BuildingRequestRegions", "ServerDeliveryDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Buildings_BuildingRequestRegions", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Buildings_BuildingRequestRegions", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.Buildings_BuildingNote", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Buildings_BuildingNote", "ServerStatus", c => c.Short(nullable: false));
        }
    }
}
