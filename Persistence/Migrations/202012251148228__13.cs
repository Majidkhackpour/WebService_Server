namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ErrorLogs",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        AndroidIme = c.String(maxLength: 200),
                        ClassName = c.String(maxLength: 100),
                        CpuSerial = c.String(maxLength: 100),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(),
                        ExceptionError = c.String(),
                        ExceptionMessage = c.String(),
                        ExceptionType = c.String(),
                        Fatal = c.Boolean(nullable: false),
                        FuncName = c.String(maxLength: 200),
                        GroupingID = c.Int(nullable: false),
                        HardSerial = c.String(maxLength: 100),
                        LKSerial = c.Long(nullable: false),
                        RefrencedID = c.Int(nullable: false),
                        ScreenShot = c.String(maxLength: 200),
                        Source = c.Int(nullable: false),
                        StackTrace = c.String(),
                        FlowStackTrace = c.String(),
                        Time = c.String(maxLength: 50),
                        Version = c.String(maxLength: 10),
                        Ip = c.String(maxLength: 50),
                        Path = c.String(maxLength: 200),
                        LoggerVersion = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Guid);
            
            AddColumn("dbo.Customers", "isBlock", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "isWebServiceBlock", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "isWebServiceBlock");
            DropColumn("dbo.Customers", "isBlock");
            DropTable("dbo.ErrorLogs");
        }
    }
}
