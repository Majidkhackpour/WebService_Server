namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buildings_BuildingOptions", "IsFullOption", c => c.Boolean(nullable: false));
            AddColumn("dbo.Buildings_Building", "Tabdil", c => c.Boolean());
            AddColumn("dbo.Buildings_Building", "ReformArea", c => c.Single(nullable: false));
            AddColumn("dbo.Buildings_Building", "BuildingPermits", c => c.Boolean());
            AddColumn("dbo.Buildings_Building", "WidthOfPassage", c => c.Single(nullable: false));
            AddColumn("dbo.Buildings_Building", "VillaType", c => c.Short());
            AddColumn("dbo.Buildings_Building", "CommericallLicense", c => c.Short());
            AddColumn("dbo.Buildings_Building", "SuitableFor", c => c.String());
            AddColumn("dbo.Buildings_Building", "WallCovering", c => c.String());
            AddColumn("dbo.Buildings_Building", "TreeCount", c => c.Int(nullable: false));
            AddColumn("dbo.Buildings_Building", "ConstructionStage", c => c.Short());
            AddColumn("dbo.Buildings_Building", "Parent", c => c.Short());
            AddColumn("dbo.Department_Scrapper", "Parent", c => c.Short(nullable: false));
            AlterColumn("dbo.Buildings_Building", "BuildingConditionGuid", c => c.Guid());
            AlterColumn("dbo.Buildings_Building", "Side", c => c.Int());
            AlterColumn("dbo.Buildings_Building", "BuildingViewGuid", c => c.Guid());
            AlterColumn("dbo.Buildings_Building", "FloorCoverGuid", c => c.Guid());
            AlterColumn("dbo.Buildings_Building", "KitchenServiceGuid", c => c.Guid());
            AlterColumn("dbo.Buildings_Building", "Water", c => c.Short());
            AlterColumn("dbo.Buildings_Building", "Barq", c => c.Short());
            AlterColumn("dbo.Buildings_Building", "Gas", c => c.Short());
            AlterColumn("dbo.Buildings_Building", "Tell", c => c.Short());
            DropColumn("dbo.Buildings_Building", "RahnPrice2");
            DropColumn("dbo.Buildings_Building", "EjarePrice2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Buildings_Building", "EjarePrice2", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Buildings_Building", "RahnPrice2", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Buildings_Building", "Tell", c => c.Short(nullable: false));
            AlterColumn("dbo.Buildings_Building", "Gas", c => c.Short(nullable: false));
            AlterColumn("dbo.Buildings_Building", "Barq", c => c.Short(nullable: false));
            AlterColumn("dbo.Buildings_Building", "Water", c => c.Short(nullable: false));
            AlterColumn("dbo.Buildings_Building", "KitchenServiceGuid", c => c.Guid(nullable: false));
            AlterColumn("dbo.Buildings_Building", "FloorCoverGuid", c => c.Guid(nullable: false));
            AlterColumn("dbo.Buildings_Building", "BuildingViewGuid", c => c.Guid(nullable: false));
            AlterColumn("dbo.Buildings_Building", "Side", c => c.Int(nullable: false));
            AlterColumn("dbo.Buildings_Building", "BuildingConditionGuid", c => c.Guid(nullable: false));
            DropColumn("dbo.Department_Scrapper", "Parent");
            DropColumn("dbo.Buildings_Building", "Parent");
            DropColumn("dbo.Buildings_Building", "ConstructionStage");
            DropColumn("dbo.Buildings_Building", "TreeCount");
            DropColumn("dbo.Buildings_Building", "WallCovering");
            DropColumn("dbo.Buildings_Building", "SuitableFor");
            DropColumn("dbo.Buildings_Building", "CommericallLicense");
            DropColumn("dbo.Buildings_Building", "VillaType");
            DropColumn("dbo.Buildings_Building", "WidthOfPassage");
            DropColumn("dbo.Buildings_Building", "BuildingPermits");
            DropColumn("dbo.Buildings_Building", "ReformArea");
            DropColumn("dbo.Buildings_Building", "Tabdil");
            DropColumn("dbo.Buildings_BuildingOptions", "IsFullOption");
        }
    }
}
