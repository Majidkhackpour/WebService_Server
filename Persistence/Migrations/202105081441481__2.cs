namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buildings_Advisor", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_Banks", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_Pardakht", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_Reception", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_Building", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_Kol", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_Moein", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_Sanad", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_SanadDetail", "HardSerial", c => c.String());
            AddColumn("dbo.Buildings_Tafsil", "HardSerial", c => c.String());
            DropColumn("dbo.Buildings_Advisor", "HardSrial");
            DropColumn("dbo.Buildings_Banks", "HardSrial");
            DropColumn("dbo.Buildings_Pardakht", "HardSrial");
            DropColumn("dbo.Buildings_Reception", "HardSrial");
            DropColumn("dbo.Buildings_Building", "HardSrial");
            DropColumn("dbo.Buildings_Kol", "HardSrial");
            DropColumn("dbo.Buildings_Moein", "HardSrial");
            DropColumn("dbo.Buildings_Sanad", "HardSrial");
            DropColumn("dbo.Buildings_SanadDetail", "HardSrial");
            DropColumn("dbo.Buildings_Tafsil", "HardSrial");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Buildings_Tafsil", "HardSrial", c => c.String());
            AddColumn("dbo.Buildings_SanadDetail", "HardSrial", c => c.String());
            AddColumn("dbo.Buildings_Sanad", "HardSrial", c => c.String());
            AddColumn("dbo.Buildings_Moein", "HardSrial", c => c.String());
            AddColumn("dbo.Buildings_Kol", "HardSrial", c => c.String());
            AddColumn("dbo.Buildings_Building", "HardSrial", c => c.String());
            AddColumn("dbo.Buildings_Reception", "HardSrial", c => c.String());
            AddColumn("dbo.Buildings_Pardakht", "HardSrial", c => c.String());
            AddColumn("dbo.Buildings_Banks", "HardSrial", c => c.String());
            AddColumn("dbo.Buildings_Advisor", "HardSrial", c => c.String());
            DropColumn("dbo.Buildings_Tafsil", "HardSerial");
            DropColumn("dbo.Buildings_SanadDetail", "HardSerial");
            DropColumn("dbo.Buildings_Sanad", "HardSerial");
            DropColumn("dbo.Buildings_Moein", "HardSerial");
            DropColumn("dbo.Buildings_Kol", "HardSerial");
            DropColumn("dbo.Buildings_Building", "HardSerial");
            DropColumn("dbo.Buildings_Reception", "HardSerial");
            DropColumn("dbo.Buildings_Pardakht", "HardSerial");
            DropColumn("dbo.Buildings_Banks", "HardSerial");
            DropColumn("dbo.Buildings_Advisor", "HardSerial");
        }
    }
}
