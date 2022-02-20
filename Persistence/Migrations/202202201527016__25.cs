namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _25 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Buildings_Building", "PishDesc");
            DropColumn("dbo.Buildings_Building", "MoavezeDesc");
            DropColumn("dbo.Buildings_Building", "MosharekatDesc");
            DropColumn("dbo.Buildings_Building", "MetrazhKouche");
            DropColumn("dbo.Buildings_Building", "DateParvane");
            DropColumn("dbo.Buildings_Building", "ParvaneSerial");
            DropColumn("dbo.Buildings_Building", "BonBast");
            DropColumn("dbo.Buildings_Building", "MamarJoda");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Buildings_Building", "MamarJoda", c => c.Boolean(nullable: false));
            AddColumn("dbo.Buildings_Building", "BonBast", c => c.Boolean(nullable: false));
            AddColumn("dbo.Buildings_Building", "ParvaneSerial", c => c.String());
            AddColumn("dbo.Buildings_Building", "DateParvane", c => c.String());
            AddColumn("dbo.Buildings_Building", "MetrazhKouche", c => c.Single(nullable: false));
            AddColumn("dbo.Buildings_Building", "MosharekatDesc", c => c.String());
            AddColumn("dbo.Buildings_Building", "MoavezeDesc", c => c.String());
            AddColumn("dbo.Buildings_Building", "PishDesc", c => c.String());
        }
    }
}
