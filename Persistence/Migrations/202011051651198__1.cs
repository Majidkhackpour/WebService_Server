namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
