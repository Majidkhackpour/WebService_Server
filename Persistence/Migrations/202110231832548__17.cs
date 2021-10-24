namespace Persistence.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _17 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buildings_BuildingNote",
                c => new
                {
                    Guid = c.Guid(nullable: false),
                    CustomerGuid = c.Guid(nullable: false),
                    Modified = c.DateTime(nullable: false),
                    ServerStatus = c.Short(nullable: false),
                    ServerDeliveryDate = c.DateTime(nullable: false),
                    BuildingGuid = c.Guid(nullable: false),
                    Note = c.String(),
                })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });

            CreateTable(
                "dbo.Buildings_BuildingRelatedNumber",
                c => new
                {
                    Guid = c.Guid(nullable: false),
                    CustomerGuid = c.Guid(nullable: false),
                    BuildingGuid = c.Guid(nullable: false),
                    Number = c.String(),
                })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });

            AddColumn("dbo.Department_SyncedData", "CustomerGuid", c => c.Guid(nullable: false));
            DropColumn("dbo.Buildings_Advisor", "HardSerial");
            DropColumn("dbo.Buildings_Banks", "HardSerial");
            DropColumn("dbo.Buildings_BuildingAccountType", "HardSerial");
            DropColumn("dbo.Buildings_BuildingCondition", "HardSerial");
            DropColumn("dbo.Buildings_BuildingGallery", "HardSerial");
            DropColumn("dbo.Buildings_BuildingOptions", "HardSerial");
            DropColumn("dbo.Buildings_Pardakht", "HardSerial");
            DropColumn("dbo.Buildings_PhoneBook", "HardSerial");
            DropColumn("dbo.Buildings_Reception", "HardSerial");
            DropColumn("dbo.Buildings_BuildingRelatedOptions", "HardSerial");
            DropColumn("dbo.Buildings_BuildingRequestRegions", "HardSerial");
            DropColumn("dbo.Buildings_BuildingRequests", "HardSerial");
            DropColumn("dbo.Buildings_Building", "HardSerial");
            DropColumn("dbo.Buildings_BuildingTypes", "HardSerial");
            DropColumn("dbo.Buildings_Users", "HardSerial");
            DropColumn("dbo.Buildings_BuildingViews", "HardSerial");
            DropColumn("dbo.Buildings_Cities", "HardSerial");
            DropColumn("dbo.Buildings_Contract", "HardSerial");
            DropColumn("dbo.Buildings_DocumentType", "HardSerial");
            DropColumn("dbo.Buildings_FloorCover", "HardSerial");
            DropColumn("dbo.Buildings_KitchenService", "HardSerial");
            DropColumn("dbo.Buildings_Kol", "HardSerial");
            DropColumn("dbo.Buildings_Moein", "HardSerial");
            DropColumn("dbo.Buildings_PeopleGroup", "HardSerial");
            DropColumn("dbo.Buildings_Peoples", "HardSerial");
            DropColumn("dbo.Buildings_Regions", "HardSerial");
            DropColumn("dbo.Buildings_RentalAuthorities", "HardSerial");
            DropColumn("dbo.Buildings_Sanad", "HardSerial");
            DropColumn("dbo.Buildings_SanadDetail", "HardSerial");
            DropColumn("dbo.Buildings_States", "HardSerial");
            DropColumn("dbo.Department_SyncedData", "HardSerial");
            DropColumn("dbo.Buildings_Tafsil", "HardSerial");
            DropTable("dbo.Department_SafeBox");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.Department_SafeBox",
                c => new
                {
                    Guid = c.Guid(nullable: false),
                    Modified = c.DateTime(nullable: false),
                    Status = c.Boolean(nullable: false),
                    Name = c.String(maxLength: 200),
                    Type = c.Short(nullable: false),
                })
                .PrimaryKey(t => t.Guid);

            AddColumn("dbo.Buildings_Tafsil", "HardSerial", c => c.String());
            AddColumn("dbo.Department_SyncedData", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_States", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_SanadDetail", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_Sanad", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_RentalAuthorities", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_Regions", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_Peoples", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_PeopleGroup", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_Moein", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_Kol", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_KitchenService", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_FloorCover", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_DocumentType", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_Contract", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_Cities", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_BuildingViews", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_Users", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_BuildingTypes", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_Building", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_BuildingRequests", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_BuildingRequestRegions", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_BuildingRelatedOptions", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_Reception", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_PhoneBook", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_Pardakht", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_BuildingOptions", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_BuildingGallery", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_BuildingCondition", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_BuildingAccountType", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_Banks", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_Advisor", "HardSerial", c => c.String());
            DropColumn("dbo.Department_SyncedData", "CustomerGuid");
            DropTable("dbo.Buildings_BuildingRelatedNumber");
            DropTable("dbo.Buildings_BuildingNote");
        }
    }
}
