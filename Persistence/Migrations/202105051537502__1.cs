namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buildings_Advisor",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        HardSrial = c.String(),
                        Status = c.Boolean(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });
            
            CreateTable(
                "dbo.Department_Androids",
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
            
            CreateTable(
                "dbo.Buildings_Banks",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        HardSrial = c.String(),
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
            
            CreateTable(
                "dbo.Buildings_BuildingAccountType",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        HardSerial = c.String(),
                        Status = c.Boolean(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });
            
            CreateTable(
                "dbo.Buildings_BuildingCondition",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        HardSerial = c.String(),
                        Status = c.Boolean(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });
            
            CreateTable(
                "dbo.Buildings_BuildingGallery",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        HardSerial = c.String(),
                        Modified = c.DateTime(nullable: false),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                        BuildingGuid = c.Guid(nullable: false),
                        ImageName = c.String(),
                    })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });
            
            CreateTable(
                "dbo.Buildings_BuildingOptions",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        HardSerial = c.String(),
                        Status = c.Boolean(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });
            
            CreateTable(
                "dbo.Buildings_Pardakht",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        HardSrial = c.String(),
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
                "dbo.Buildings_PhoneBook",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        HardSerial = c.String(),
                        Status = c.Boolean(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                        Name = c.String(),
                        Tell = c.String(),
                        Group = c.Short(nullable: false),
                        ParentGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });
            
            CreateTable(
                "dbo.Buildings_Reception",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        HardSrial = c.String(),
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
                "dbo.Buildings_BuildingRelatedOptions",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        HardSerial = c.String(),
                        Modified = c.DateTime(nullable: false),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                        BuildinGuid = c.Guid(nullable: false),
                        BuildingOptionGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });
            
            CreateTable(
                "dbo.Buildings_BuildingRequestRegions",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        HardSerial = c.String(),
                        Modified = c.DateTime(nullable: false),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                        RequestGuid = c.Guid(nullable: false),
                        RegionGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });
            
            CreateTable(
                "dbo.Buildings_BuildingRequests",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        HardSerial = c.String(),
                        Status = c.Boolean(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
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
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });
            
            CreateTable(
                "dbo.Buildings_Building",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        HardSrial = c.String(),
                        Status = c.Boolean(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
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
                        Priority = c.Short(nullable: false),
                        IsArchive = c.Boolean(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });
            
            CreateTable(
                "dbo.Buildings_BuildingTypes",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        HardSerial = c.String(),
                        Status = c.Boolean(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });
            
            CreateTable(
                "dbo.Buildings_Users",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        HardSerial = c.String(),
                        Status = c.Boolean(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                        Name = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        Access = c.String(),
                        SecurityQuestion = c.Short(nullable: false),
                        AnswerQuestion = c.String(),
                        Email = c.String(),
                        Mobile = c.String(),
                    })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });
            
            CreateTable(
                "dbo.Buildings_BuildingViews",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        HardSerial = c.String(),
                        Status = c.Boolean(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });
            
            CreateTable(
                "dbo.Buildings_Cities",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        HardSerial = c.String(),
                        Status = c.Boolean(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                        Name = c.String(),
                        StateGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });
            
            CreateTable(
                "dbo.Buildings_Contract",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        HardSerial = c.String(),
                        Status = c.Boolean(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
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
                "dbo.Department_CustomerLog",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        Side = c.Int(nullable: false),
                        Description = c.String(),
                        Parent = c.Guid(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.Department_Customers",
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
                        HardSerial = c.String(maxLength: 100),
                        LkSerial = c.String(maxLength: 500),
                        isBlock = c.Boolean(nullable: false),
                        isWebServiceBlock = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.Buildings_DocumentType",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        HardSerial = c.String(),
                        Status = c.Boolean(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });
            
            CreateTable(
                "dbo.Department_ErrorLog",
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
            
            CreateTable(
                "dbo.Buildings_FloorCover",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        HardSerial = c.String(),
                        Status = c.Boolean(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });
            
            CreateTable(
                "dbo.Buildings_KitchenService",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        HardSerial = c.String(),
                        Status = c.Boolean(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });
            
            CreateTable(
                "dbo.Buildings_Kol",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        HardSrial = c.String(),
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
                "dbo.Buildings_Moein",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        HardSrial = c.String(),
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
                "dbo.Department_Order",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        UserGuid = c.Guid(nullable: false),
                        ContractCode = c.String(maxLength: 50),
                        LearningCount = c.Int(nullable: false),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.Department_OrderDetail",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        OrderGuid = c.Guid(nullable: false),
                        PrdGuid = c.Guid(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.Department_Pardakht",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Payer = c.Guid(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        NaqdPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NaqdSafeBoxGuid = c.Guid(nullable: false),
                        BankSafeBoxGuid = c.Guid(nullable: false),
                        BankPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FishNo = c.String(maxLength: 100),
                        Check = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CheckNo = c.String(maxLength: 100),
                        SarResid = c.String(maxLength: 20),
                        BankName = c.String(maxLength: 100),
                        UserGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.Buildings_PeopleGroup",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        HardSerial = c.String(),
                        Status = c.Boolean(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                        Name = c.String(),
                        ParentGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });
            
            CreateTable(
                "dbo.Buildings_Peoples",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        HardSerial = c.String(),
                        Status = c.Boolean(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
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
                    })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });
            
            CreateTable(
                "dbo.Department_Product",
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
                "dbo.Department_Reception",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Receptor = c.Guid(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        NaqdPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NaqdSafeBoxGuid = c.Guid(nullable: false),
                        BankPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BankSafeBoxGuid = c.Guid(nullable: false),
                        FishNo = c.String(maxLength: 100),
                        Check = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CheckNo = c.String(maxLength: 100),
                        SarResid = c.String(maxLength: 20),
                        BankName = c.String(maxLength: 100),
                        UserGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.Buildings_Regions",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        HardSerial = c.String(),
                        Modified = c.DateTime(nullable: false),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(),
                        CityGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });
            
            CreateTable(
                "dbo.Buildings_RentalAuthorities",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        HardSerial = c.String(),
                        Modified = c.DateTime(nullable: false),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });
            
            CreateTable(
                "dbo.Department_SafeBox",
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
                "dbo.Buildings_Sanad",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        HardSrial = c.String(),
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
                "dbo.Buildings_SanadDetail",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        HardSrial = c.String(),
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
                "dbo.Department_SmsLog",
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
                "dbo.Department_SmsPanel",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 200),
                        Sender = c.String(maxLength: 200),
                        API = c.String(maxLength: 500),
                        IsCurrent = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.Buildings_States",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        HardSerial = c.String(),
                        Status = c.Boolean(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => new { t.Guid, t.CustomerGuid });
            
            CreateTable(
                "dbo.Department_SyncedData",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        ObjectGuid = c.Guid(nullable: false),
                        HardSerial = c.String(),
                        Type = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.Buildings_Tafsil",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        CustomerGuid = c.Guid(nullable: false),
                        HardSrial = c.String(),
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
                "dbo.Department_Users",
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
            DropTable("dbo.Department_Users");
            DropTable("dbo.Buildings_Tafsil");
            DropTable("dbo.Department_SyncedData");
            DropTable("dbo.Buildings_States");
            DropTable("dbo.Department_SmsPanel");
            DropTable("dbo.Department_SmsLog");
            DropTable("dbo.Buildings_SanadDetail");
            DropTable("dbo.Buildings_Sanad");
            DropTable("dbo.Department_SafeBox");
            DropTable("dbo.Buildings_RentalAuthorities");
            DropTable("dbo.Buildings_Regions");
            DropTable("dbo.Department_Reception");
            DropTable("dbo.Department_Product");
            DropTable("dbo.Buildings_Peoples");
            DropTable("dbo.Buildings_PeopleGroup");
            DropTable("dbo.Department_Pardakht");
            DropTable("dbo.Department_OrderDetail");
            DropTable("dbo.Department_Order");
            DropTable("dbo.Buildings_Moein");
            DropTable("dbo.Buildings_Kol");
            DropTable("dbo.Buildings_KitchenService");
            DropTable("dbo.Buildings_FloorCover");
            DropTable("dbo.Department_ErrorLog");
            DropTable("dbo.Buildings_DocumentType");
            DropTable("dbo.Department_Customers");
            DropTable("dbo.Department_CustomerLog");
            DropTable("dbo.Buildings_Contract");
            DropTable("dbo.Buildings_Cities");
            DropTable("dbo.Buildings_BuildingViews");
            DropTable("dbo.Buildings_Users");
            DropTable("dbo.Buildings_BuildingTypes");
            DropTable("dbo.Buildings_Building");
            DropTable("dbo.Buildings_BuildingRequests");
            DropTable("dbo.Buildings_BuildingRequestRegions");
            DropTable("dbo.Buildings_BuildingRelatedOptions");
            DropTable("dbo.Buildings_Reception");
            DropTable("dbo.Buildings_PhoneBook");
            DropTable("dbo.Buildings_Pardakht");
            DropTable("dbo.Buildings_BuildingOptions");
            DropTable("dbo.Buildings_BuildingGallery");
            DropTable("dbo.Buildings_BuildingCondition");
            DropTable("dbo.Buildings_BuildingAccountType");
            DropTable("dbo.Buildings_Banks");
            DropTable("dbo.Department_Androids");
            DropTable("dbo.Buildings_Advisor");
        }
    }
}
