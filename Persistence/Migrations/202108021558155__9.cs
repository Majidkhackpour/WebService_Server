namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department_BackUpLogs",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        FileName = c.String(maxLength: 500),
                        FileLength = c.Double(nullable: false),
                        URL = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Department_BackUpLogs");
        }
    }
}
