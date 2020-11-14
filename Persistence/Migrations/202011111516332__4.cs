namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerLogs", "Side", c => c.Int(nullable: false));
            AddColumn("dbo.Receptions", "Receptor", c => c.Guid(nullable: false));
            AddColumn("dbo.Receptions", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Receptions", "NaqdPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Receptions", "NaqdSafeBoxGuid", c => c.Guid(nullable: false));
            AddColumn("dbo.Receptions", "BankPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Receptions", "BankSafeBoxGuid", c => c.Guid(nullable: false));
            AddColumn("dbo.Receptions", "FishNo", c => c.String(maxLength: 100));
            AddColumn("dbo.Receptions", "Check", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Receptions", "CheckNo", c => c.String(maxLength: 100));
            AddColumn("dbo.Receptions", "SarResid", c => c.String(maxLength: 20));
            AddColumn("dbo.Receptions", "BankName", c => c.String(maxLength: 100));
            DropColumn("dbo.CustomerLogs", "SideName");
            DropColumn("dbo.Receptions", "Date");
            DropColumn("dbo.Receptions", "CustomerGuid");
            DropColumn("dbo.Receptions", "UserGuid");
            DropColumn("dbo.Receptions", "Price");
            DropColumn("dbo.Receptions", "Type");
            DropColumn("dbo.Receptions", "ResidNo");
            DropColumn("dbo.Receptions", "PeygiriNo");
            DropColumn("dbo.Receptions", "SafeBoxGuid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Receptions", "SafeBoxGuid", c => c.Guid(nullable: false));
            AddColumn("dbo.Receptions", "PeygiriNo", c => c.String(maxLength: 50));
            AddColumn("dbo.Receptions", "ResidNo", c => c.String(maxLength: 50));
            AddColumn("dbo.Receptions", "Type", c => c.Short(nullable: false));
            AddColumn("dbo.Receptions", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Receptions", "UserGuid", c => c.Guid(nullable: false));
            AddColumn("dbo.Receptions", "CustomerGuid", c => c.Guid(nullable: false));
            AddColumn("dbo.Receptions", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.CustomerLogs", "SideName", c => c.String(maxLength: 100));
            DropColumn("dbo.Receptions", "BankName");
            DropColumn("dbo.Receptions", "SarResid");
            DropColumn("dbo.Receptions", "CheckNo");
            DropColumn("dbo.Receptions", "Check");
            DropColumn("dbo.Receptions", "FishNo");
            DropColumn("dbo.Receptions", "BankSafeBoxGuid");
            DropColumn("dbo.Receptions", "BankPrice");
            DropColumn("dbo.Receptions", "NaqdSafeBoxGuid");
            DropColumn("dbo.Receptions", "NaqdPrice");
            DropColumn("dbo.Receptions", "CreateDate");
            DropColumn("dbo.Receptions", "Receptor");
            DropColumn("dbo.CustomerLogs", "Side");
        }
    }
}
