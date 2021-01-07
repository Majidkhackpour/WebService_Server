namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _17 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuildingPhoneBooks",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        HardSerial = c.String(nullable: false, maxLength: 128),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(),
                        Tell = c.String(),
                        Group = c.Short(nullable: false),
                        ParentGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Guid, t.HardSerial });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BuildingPhoneBooks");
        }
    }
}
