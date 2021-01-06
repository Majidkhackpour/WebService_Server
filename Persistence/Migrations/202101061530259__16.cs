namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _16 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuildingOptions",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        HardSerial = c.String(nullable: false, maxLength: 128),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => new { t.Guid, t.HardSerial });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BuildingOptions");
        }
    }
}
