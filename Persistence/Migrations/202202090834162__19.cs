namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _19 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Buildings_Advisor", newName: "Buildings_BuildingWindow");
            CreateTable(
                "dbo.Buildings_BuildingReview",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        BuildingGuid = c.Guid(nullable: false),
                        UserGuid = c.Guid(nullable: false),
                        CustometGuid = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Report = c.String(),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });
            
            CreateTable(
                "dbo.Buildings_BuildingZoncan",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });
            
            AddColumn("dbo.Buildings_Building", "VahedNo", c => c.Int(nullable: false));
            AddColumn("dbo.Buildings_Building", "ZoncanGuid", c => c.Guid());
            AddColumn("dbo.Buildings_Building", "WindowGuid", c => c.Guid());
            DropColumn("dbo.Buildings_BuildingWindow", "Address");
            DropColumn("dbo.Buildings_Building", "TelegramCount");
            DropColumn("dbo.Buildings_Building", "WhatsAppCount");
            DropColumn("dbo.Buildings_Building", "DivarCount");
            DropColumn("dbo.Buildings_Building", "SheypoorCount");
            DropTable("dbo.Buildings_Banks");
            DropTable("dbo.Buildings_Pardakht");
            DropTable("dbo.Buildings_Reception");
            DropTable("dbo.Buildings_Contract");
            DropTable("dbo.Buildings_Kol");
            DropTable("dbo.Buildings_Moein");
            DropTable("dbo.Buildings_Sanad");
            DropTable("dbo.Buildings_SanadDetail");
            DropTable("dbo.Buildings_Tafsil");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Buildings_Tafsil",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                        Name = c.String(),
                        Code = c.String(),
                        Description = c.String(),
                        HesabType = c.Int(nullable: false),
                        DateM = c.DateTime(nullable: false),
                        Account = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccountFirst = c.Decimal(nullable: false, precision: 18, scale: 2),
                        isSystem = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });
            
            CreateTable(
                "dbo.Buildings_SanadDetail",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                        MasterGuid = c.Guid(nullable: false),
                        MoeinGuid = c.Guid(nullable: false),
                        TafsilGuid = c.Guid(nullable: false),
                        Debit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Credit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                    })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });
            
            CreateTable(
                "dbo.Buildings_Sanad",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                        DateM = c.DateTime(nullable: false),
                        Description = c.String(),
                        Number = c.Long(nullable: false),
                        SanadStatus = c.Short(nullable: false),
                        UserGuid = c.Guid(nullable: false),
                        SanadType = c.Short(nullable: false),
                    })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });
            
            CreateTable(
                "dbo.Buildings_Moein",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                        Name = c.String(),
                        Code = c.String(),
                        KolGuid = c.Guid(nullable: false),
                        DateM = c.DateTime(nullable: false),
                        Account = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });
            
            CreateTable(
                "dbo.Buildings_Kol",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                        Name = c.String(),
                        HesabGroup = c.Int(nullable: false),
                        Code = c.String(),
                        Account = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });
            
            CreateTable(
                "dbo.Buildings_Contract",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                        DateM = c.DateTime(nullable: false),
                        Code = c.Long(nullable: false),
                        CodeInArchive = c.String(),
                        IsTemp = c.Boolean(nullable: false),
                        FirstSideGuid = c.Guid(nullable: false),
                        SecondSideGuid = c.Guid(nullable: false),
                        BuildingGuid = c.Guid(nullable: false),
                        UserGuid = c.Guid(nullable: false),
                        Term = c.Int(),
                        FromDate = c.DateTime(),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MinorPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CheckNo = c.String(),
                        BankName = c.String(),
                        Shobe = c.String(),
                        SarResid = c.String(),
                        DischargeDate = c.DateTime(nullable: false),
                        SetDocDate = c.DateTime(),
                        SetDocPlace = c.String(),
                        SarQofli = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Delay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        Type = c.Short(nullable: false),
                        BazaryabGuid = c.Guid(),
                        BazaryabPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SanadNumber = c.Long(nullable: false),
                        fBabat = c.Short(nullable: false),
                        sBabat = c.Short(nullable: false),
                        FirstDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SecondDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FirstTax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FirstAvarez = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SecondTax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SecondAvarez = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FirstTotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SecondTotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });
            
            CreateTable(
                "dbo.Buildings_Reception",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                        Number = c.Long(nullable: false),
                        DateM = c.DateTime(nullable: false),
                        Description = c.String(),
                        TafsilGuid = c.Guid(nullable: false),
                        MoeinGuid = c.Guid(nullable: false),
                        UserGuid = c.Guid(nullable: false),
                        SanadNumber = c.Long(nullable: false),
                        SumCheck = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SumHavale = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SumNaqd = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });
            
            CreateTable(
                "dbo.Buildings_Pardakht",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                        TafsilGuid = c.Guid(nullable: false),
                        MoeinGuid = c.Guid(nullable: false),
                        DateM = c.DateTime(nullable: false),
                        Description = c.String(),
                        UserGuid = c.Guid(nullable: false),
                        Number = c.Long(nullable: false),
                        SanadNumber = c.Long(nullable: false),
                        SumCheckMoshtari = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SumCheckShakhsi = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SumHavale = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SumNaqd = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });
            
            CreateTable(
                "dbo.Buildings_Banks",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                        Shobe = c.String(),
                        CodeShobe = c.String(),
                        HesabNumber = c.String(),
                        Description = c.String(),
                        DateM = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });
            
            AddColumn("dbo.Buildings_Building", "SheypoorCount", c => c.Int(nullable: false));
            AddColumn("dbo.Buildings_Building", "DivarCount", c => c.Int(nullable: false));
            AddColumn("dbo.Buildings_Building", "WhatsAppCount", c => c.Int(nullable: false));
            AddColumn("dbo.Buildings_Building", "TelegramCount", c => c.Int(nullable: false));
            AddColumn("dbo.Buildings_BuildingWindow", "Address", c => c.String());
            DropColumn("dbo.Buildings_Building", "WindowGuid");
            DropColumn("dbo.Buildings_Building", "ZoncanGuid");
            DropColumn("dbo.Buildings_Building", "VahedNo");
            DropTable("dbo.Buildings_BuildingZoncan");
            DropTable("dbo.Buildings_BuildingReview");
            RenameTable(name: "dbo.Buildings_BuildingWindow", newName: "Buildings_Advisor");
        }
    }
}
