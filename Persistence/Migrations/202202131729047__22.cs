namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _22 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Buildings_BuildingRelatedOptions", "ServerStatus");
            DropColumn("dbo.Buildings_BuildingRelatedOptions", "ServerDeliveryDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Buildings_BuildingRelatedOptions", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Buildings_BuildingRelatedOptions", "ServerStatus", c => c.Short(nullable: false));
        }
    }
}
