namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department_Scrapper",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Title = c.String(),
                        Number = c.String(),
                        State = c.String(),
                        City = c.String(),
                        Region = c.String(),
                        BuildingType = c.String(),
                        Masahat = c.Int(nullable: false),
                        SaleSakht = c.String(),
                        RoomCount = c.Int(nullable: false),
                        Evelator = c.Boolean(nullable: false),
                        Parking = c.Boolean(nullable: false),
                        Store = c.Boolean(nullable: false),
                        Balcony = c.Boolean(nullable: false),
                        RahnPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EjarePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RentalAuthority = c.String(),
                        TabaqeCount = c.Int(nullable: false),
                        TabaqeNo = c.Int(nullable: false),
                        Description = c.String(),
                        VahedPerTabaqe = c.Int(nullable: false),
                        BuildingSide = c.String(),
                        ImagesList = c.String(),
                    })
                .PrimaryKey(t => t.Guid);
            
            AddColumn("dbo.Buildings_Building", "Lenght", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buildings_Building", "Lenght");
            DropTable("dbo.Department_Scrapper");
        }
    }
}
