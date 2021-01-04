namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Androids",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        IMEI = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Androids");
        }
    }
}
