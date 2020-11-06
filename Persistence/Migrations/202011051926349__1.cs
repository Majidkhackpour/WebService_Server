namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerLogs",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        SideName = c.String(maxLength: 100),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Name = c.String(maxLength: 500),
                        CompanyName = c.String(maxLength: 500),
                        NationalCode = c.String(maxLength: 50),
                        AppSerial = c.String(maxLength: 100),
                        Address = c.String(maxLength: 500),
                        PostalCode = c.String(maxLength: 100),
                        Tell1 = c.String(maxLength: 50),
                        Tell2 = c.String(maxLength: 50),
                        Tell3 = c.String(maxLength: 50),
                        Tell4 = c.String(maxLength: 50),
                        Email = c.String(maxLength: 100),
                        Description = c.String(),
                        ExpireDate = c.DateTime(nullable: false),
                        UserGuid = c.Guid(nullable: false),
                        Account = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserName = c.String(maxLength: 100),
                        Password = c.String(maxLength: 100),
                        SiteUrl = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        UserGuid = c.Guid(nullable: false),
                        ContractCode = c.String(maxLength: 50),
                        Version = c.String(maxLength: 50),
                        LearningCount = c.Int(nullable: false),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        PrdGuid = c.Guid(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 200),
                        Code = c.String(maxLength: 50),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BckUpPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.Receptions",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        UserGuid = c.Guid(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Type = c.Short(nullable: false),
                        ResidNo = c.String(maxLength: 50),
                        PeygiriNo = c.String(maxLength: 50),
                        SafeBoxGuid = c.Guid(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.SafeBoxes",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 200),
                        Type = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.SmsLogs",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        UserGuid = c.Guid(nullable: false),
                        Sender = c.String(maxLength: 100),
                        Reciver = c.String(maxLength: 100),
                        Message = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MessageId = c.Long(nullable: false),
                        StatusText = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.SmsPanels",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 200),
                        Sender = c.String(maxLength: 200),
                        API = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.UserLogs",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        UserGuid = c.Guid(nullable: false),
                        Type = c.Short(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 200),
                        UserName = c.String(maxLength: 200),
                        Password = c.String(maxLength: 500),
                        Mobile = c.String(maxLength: 20),
                        Email = c.String(maxLength: 100),
                        IsBlock = c.Boolean(nullable: false),
                        Type = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.UserLogs");
            DropTable("dbo.SmsPanels");
            DropTable("dbo.SmsLogs");
            DropTable("dbo.SafeBoxes");
            DropTable("dbo.Receptions");
            DropTable("dbo.Products");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerLogs");
        }
    }
}
