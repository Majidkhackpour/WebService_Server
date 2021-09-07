namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buildings_Building", "TelegramCount", c => c.Int(nullable: false));
            AddColumn("dbo.Buildings_Building", "DivarCount", c => c.Int(nullable: false));
            AddColumn("dbo.Buildings_Building", "SheypoorCount", c => c.Int(nullable: false));
            AddColumn("dbo.Buildings_Building", "AdvertiseType", c => c.Short());
            AddColumn("dbo.Buildings_Building", "DivarTitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buildings_Building", "DivarTitle");
            DropColumn("dbo.Buildings_Building", "AdvertiseType");
            DropColumn("dbo.Buildings_Building", "SheypoorCount");
            DropColumn("dbo.Buildings_Building", "DivarCount");
            DropColumn("dbo.Buildings_Building", "TelegramCount");
        }
    }
}
