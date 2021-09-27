namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Department_Scrapper", "FloorCover", c => c.String());
            AddColumn("dbo.Department_Scrapper", "Colling", c => c.String());
            AddColumn("dbo.Department_Scrapper", "Hitting", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Department_Scrapper", "Hitting");
            DropColumn("dbo.Department_Scrapper", "Colling");
            DropColumn("dbo.Department_Scrapper", "FloorCover");
        }
    }
}
