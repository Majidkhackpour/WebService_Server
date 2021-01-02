namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _14 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuildingAccountTypes",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        HardSerial = c.String(nullable: false, maxLength: 128),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => new { t.Guid, t.HardSerial });
            
            CreateTable(
                "dbo.BuildingConditions",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        HardSerial = c.String(nullable: false, maxLength: 128),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => new { t.Guid, t.HardSerial });
            
            CreateTable(
                "dbo.BuildingGalleries",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        HardSerial = c.String(nullable: false, maxLength: 128),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        BuildingGuid = c.Guid(nullable: false),
                        ImageName = c.String(),
                    })
                .PrimaryKey(t => new { t.Guid, t.HardSerial });
            
            CreateTable(
                "dbo.BuildingGardeshHesabs",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        HardSerial = c.String(nullable: false, maxLength: 128),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        PeopleGuid = c.Guid(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Type = c.Short(nullable: false),
                        Babat = c.Short(nullable: false),
                        Description = c.String(),
                        ParentGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Guid, t.HardSerial });
            
            CreateTable(
                "dbo.BuildingPardakhts",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        HardSerial = c.String(nullable: false, maxLength: 128),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Payer = c.Guid(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        NaqdPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BankPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FishNo = c.String(),
                        Check = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CheckNo = c.String(),
                        SarResid = c.String(),
                        BankName = c.String(),
                    })
                .PrimaryKey(t => new { t.Guid, t.HardSerial });
            
            CreateTable(
                "dbo.BuildingReceptions",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        HardSerial = c.String(nullable: false, maxLength: 128),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Receptor = c.Guid(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        NaqdPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BankPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FishNo = c.String(),
                        Check = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CheckNo = c.String(),
                        SarResid = c.String(),
                        BankName = c.String(),
                    })
                .PrimaryKey(t => new { t.Guid, t.HardSerial });
            
            CreateTable(
                "dbo.BuildingRelatedOptions",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        HardSerial = c.String(nullable: false, maxLength: 128),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        BuildinGuid = c.Guid(nullable: false),
                        BuildingOptionGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Guid, t.HardSerial });
            
            CreateTable(
                "dbo.BuildingRequestRegions",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        HardSerial = c.String(nullable: false, maxLength: 128),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        RequestGuid = c.Guid(nullable: false),
                        RegionGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Guid, t.HardSerial });
            
            CreateTable(
                "dbo.BuildingRequests",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        HardSerial = c.String(nullable: false, maxLength: 128),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        AskerGuid = c.Guid(nullable: false),
                        UserGuid = c.Guid(nullable: false),
                        SellPrice1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellPrice2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HasVam = c.Boolean(),
                        RahnPrice1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RahnPrice2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EjarePrice1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EjarePrice2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PeopleCount = c.Short(),
                        HasOwner = c.Boolean(),
                        ShortDate = c.Boolean(),
                        RentalAutorityGuid = c.Guid(),
                        CityGuid = c.Guid(nullable: false),
                        BuildingTypeGuid = c.Guid(nullable: false),
                        Masahat1 = c.Int(nullable: false),
                        Masahat2 = c.Int(nullable: false),
                        RoomCount = c.Int(nullable: false),
                        BuildingAccountTypeGuid = c.Guid(nullable: false),
                        BuildingConditionGuid = c.Guid(nullable: false),
                        ShortDesc = c.String(),
                    })
                .PrimaryKey(t => new { t.Guid, t.HardSerial });
            
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        HardSerial = c.String(nullable: false, maxLength: 128),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Code = c.String(),
                        OwnerGuid = c.Guid(nullable: false),
                        UserGuid = c.Guid(nullable: false),
                        SellPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VamPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QestPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Dang = c.Int(nullable: false),
                        DocumentType = c.Guid(),
                        Tarakom = c.Short(),
                        RahnPrice1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RahnPrice2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EjarePrice1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EjarePrice2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RentalAutorityGuid = c.Guid(),
                        IsShortTime = c.Boolean(),
                        IsOwnerHere = c.Boolean(),
                        PishTotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PishPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeliveryDate = c.DateTime(),
                        PishDesc = c.String(),
                        MoavezeDesc = c.String(),
                        MosharekatDesc = c.String(),
                        Masahat = c.Int(nullable: false),
                        ZirBana = c.Int(nullable: false),
                        CityGuid = c.Guid(nullable: false),
                        RegionGuid = c.Guid(nullable: false),
                        Address = c.String(),
                        BuildingConditionGuid = c.Guid(nullable: false),
                        Side = c.Int(nullable: false),
                        BuildingTypeGuid = c.Guid(nullable: false),
                        ShortDesc = c.String(),
                        BuildingAccountTypeGuid = c.Guid(nullable: false),
                        MetrazhTejari = c.Single(nullable: false),
                        BuildingViewGuid = c.Guid(nullable: false),
                        FloorCoverGuid = c.Guid(nullable: false),
                        KitchenServiceGuid = c.Guid(nullable: false),
                        Water = c.Short(nullable: false),
                        Barq = c.Short(nullable: false),
                        Gas = c.Short(nullable: false),
                        Tell = c.Short(nullable: false),
                        TedadTabaqe = c.Int(nullable: false),
                        TabaqeNo = c.Int(nullable: false),
                        VahedPerTabaqe = c.Int(nullable: false),
                        MetrazhKouche = c.Single(nullable: false),
                        ErtefaSaqf = c.Single(nullable: false),
                        Hashie = c.Single(nullable: false),
                        SaleSakht = c.String(),
                        DateParvane = c.String(),
                        ParvaneSerial = c.String(),
                        BonBast = c.Boolean(nullable: false),
                        MamarJoda = c.Boolean(nullable: false),
                        RoomCount = c.Int(nullable: false),
                        BuildingStatus = c.Short(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => new { t.Guid, t.HardSerial });
            
            CreateTable(
                "dbo.BuildingTypes",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        HardSerial = c.String(nullable: false, maxLength: 128),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => new { t.Guid, t.HardSerial });
            
            CreateTable(
                "dbo.BuildingUsers",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        HardSerial = c.String(nullable: false, maxLength: 128),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        Access = c.String(),
                        SecurityQuestion = c.Short(nullable: false),
                        AnswerQuestion = c.String(),
                        Email = c.String(),
                        Mobile = c.String(),
                        Account = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccountFirst = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.Guid, t.HardSerial });
            
            CreateTable(
                "dbo.BuildingViews",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        HardSerial = c.String(nullable: false, maxLength: 128),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => new { t.Guid, t.HardSerial });
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        HardSerial = c.String(nullable: false, maxLength: 128),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(),
                        StateGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Guid, t.HardSerial });
            
            CreateTable(
                "dbo.ContractFinances",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        HardSerial = c.String(nullable: false, maxLength: 128),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        ConGuid = c.Guid(nullable: false),
                        fBabat = c.Short(nullable: false),
                        sBabat = c.Short(nullable: false),
                        FirstDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SecondDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FirstAddedValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SecondAddedValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FirstTotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SecondTotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.Guid, t.HardSerial });
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        HardSerial = c.String(nullable: false, maxLength: 128),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        DateM = c.DateTime(nullable: false),
                        Code = c.Long(nullable: false),
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
                        BazaryabGuid = c.Guid(nullable: false),
                        BazaryabPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.Guid, t.HardSerial });
            
            CreateTable(
                "dbo.DocumentTypes",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        HardSerial = c.String(nullable: false, maxLength: 128),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => new { t.Guid, t.HardSerial });
            
            CreateTable(
                "dbo.FloorCovers",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        HardSerial = c.String(nullable: false, maxLength: 128),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => new { t.Guid, t.HardSerial });
            
            CreateTable(
                "dbo.Hazines",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        HardSerial = c.String(nullable: false, maxLength: 128),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(),
                        Account = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccountFirst = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.Guid, t.HardSerial });
            
            CreateTable(
                "dbo.KitchenServices",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        HardSerial = c.String(nullable: false, maxLength: 128),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => new { t.Guid, t.HardSerial });
            
            CreateTable(
                "dbo.PeopleGroups",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        HardSerial = c.String(nullable: false, maxLength: 128),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(),
                        ParentGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Guid, t.HardSerial });
            
            CreateTable(
                "dbo.Peoples",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        HardSerial = c.String(nullable: false, maxLength: 128),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                        NationalCode = c.String(),
                        IdCode = c.String(),
                        FatherName = c.String(),
                        PlaceBirth = c.String(),
                        DateBirth = c.String(),
                        Address = c.String(),
                        IssuedFrom = c.String(),
                        PostalCode = c.String(),
                        GroupGuid = c.Guid(nullable: false),
                        Account = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccountFirst = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.Guid, t.HardSerial });
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        HardSerial = c.String(nullable: false, maxLength: 128),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(),
                        CityGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Guid, t.HardSerial });
            
            CreateTable(
                "dbo.RentalAuthorities",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        HardSerial = c.String(nullable: false, maxLength: 128),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => new { t.Guid, t.HardSerial });
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        HardSerial = c.String(nullable: false, maxLength: 128),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => new { t.Guid, t.HardSerial });
            
            CreateTable(
                "dbo.SyncedDatas",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        ObjectGuid = c.Guid(nullable: false),
                        HardSerial = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SyncedDatas");
            DropTable("dbo.States");
            DropTable("dbo.RentalAuthorities");
            DropTable("dbo.Regions");
            DropTable("dbo.Peoples");
            DropTable("dbo.PeopleGroups");
            DropTable("dbo.KitchenServices");
            DropTable("dbo.Hazines");
            DropTable("dbo.FloorCovers");
            DropTable("dbo.DocumentTypes");
            DropTable("dbo.Contracts");
            DropTable("dbo.ContractFinances");
            DropTable("dbo.Cities");
            DropTable("dbo.BuildingViews");
            DropTable("dbo.BuildingUsers");
            DropTable("dbo.BuildingTypes");
            DropTable("dbo.Buildings");
            DropTable("dbo.BuildingRequests");
            DropTable("dbo.BuildingRequestRegions");
            DropTable("dbo.BuildingRelatedOptions");
            DropTable("dbo.BuildingReceptions");
            DropTable("dbo.BuildingPardakhts");
            DropTable("dbo.BuildingGardeshHesabs");
            DropTable("dbo.BuildingGalleries");
            DropTable("dbo.BuildingConditions");
            DropTable("dbo.BuildingAccountTypes");
        }
    }
}
