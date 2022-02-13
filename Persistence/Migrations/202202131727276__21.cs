namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _21 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Buildings_BuildingGallery", "ServerStatus");
            DropColumn("dbo.Buildings_BuildingGallery", "ServerDeliveryDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Buildings_BuildingGallery", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Buildings_BuildingGallery", "ServerStatus", c => c.Short(nullable: false));
        }
    }
}
